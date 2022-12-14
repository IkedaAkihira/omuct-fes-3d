using UnityEngine;
using System;

public class ExplosionEkipu : MonoBehaviour {
    long startTime;
    public Player parent;

    private void Start() {
        startTime=GameMaster.instance.gameTime;
    transform.localScale=new Vector3(0f,0f,0f);
    }
    private void FixedUpdate() {
        long currentTime=GameMaster.instance.gameTime;
        if(currentTime-startTime>25){
        Destroy(this.gameObject);
        return;
    }
        transform.localScale=new Vector3(1f,1f,1f)*(Mathf.Sin((currentTime-startTime)*0.05f*Mathf.PI/2)*1+1.2f);
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log(parent);
        Player player=other.GetComponent<Player>();
        if(!player)
            return;
        if(player==parent)
            return;
        player.AddEffect(new EffectPoison(500));
    }
}