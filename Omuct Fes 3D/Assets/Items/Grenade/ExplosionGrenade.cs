using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ExplosionGrenade : MonoBehaviour {
    long startTime;
    HashSet<Player>blackList = new HashSet<Player>();
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
    private void OnTriggerEnter(Collider other) {        
        Player player=other.GetComponent<Player>();
        if(!player)
            return;
        if(blackList.Contains(player))
            return;
        blackList.Add(player);
        player.Damage(new DamageSource(2));
    }
}