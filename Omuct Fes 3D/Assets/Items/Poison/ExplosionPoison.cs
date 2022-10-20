using UnityEngine;
using System;

public class ExplosionPoison : MonoBehaviour {
    long startTime;
    public Player parent;

    private void Start() {
        startTime=GameMaster.instance.gameTime;
    }
    private void FixedUpdate() {
        long currentTime=GameMaster.instance.gameTime;
        if(currentTime-startTime>1000){
            Destroy(this.gameObject);
            return;
        }
    }
    private void OnTriggerStay(Collider other) {        
        Player player=other.GetComponent<Player>();
        if(!player)
            return;
        if(player==parent)
            return;
        player.AddEffect(new EffectPoison(500));
    }
}