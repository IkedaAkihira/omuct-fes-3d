using UnityEngine;
using System;

public class ExplosionEkipu : MonoBehaviour {
    long startTime;
    public Player parent;

    private void Start() {
        startTime=DateTime.Now.Hour * 60 *60 * 1000 + DateTime.Now.Minute * 60 * 1000 + 
    DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
    transform.localScale=new Vector3(0f,0f,0f);
    }
    private void FixedUpdate() {
        long currentTime=(DateTime.Now.Hour * 60 *60 * 1000 + DateTime.Now.Minute * 60 * 1000 + 
        DateTime.Now.Second * 1000 + DateTime.Now.Millisecond);
        if(currentTime-startTime>1000){
        Destroy(this.gameObject);
        return;
    }
        transform.localScale=new Vector3(1f,1f,1f)*Mathf.Sin((currentTime-startTime)*0.001f*Mathf.PI/2)*10;
    }
    private void OnTriggerEnter(Collider other) {
        Debug.Log(parent);
        Player player=other.GetComponent<Player>();
        if(!player)
            return;
        if(player==parent)
            return;
        player.Damage(new DamageSource(1));
    }
}