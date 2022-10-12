using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class PlayerEkipu : Player{
    public GameObject attackObject;
    public float attackForce=1000f;
    public int attackInterval=200;
    private long lastAttackTime=0;
    override protected void Attack(){
        
        if(GameMaster.instance.gameTime<lastAttackTime+attackInterval)
            return;
        lastAttackTime=GameMaster.instance.gameTime;
        
        GameObject cloneObject=Instantiate(attackObject,transform.position+new Vector3(0f,0.5f,0f),Quaternion.identity);
        Rigidbody rb=cloneObject.GetComponent<Rigidbody>();
        rb.AddForce(playerToTargetVec*attackForce);
        BulletEkipu bullet=cloneObject.GetComponent<BulletEkipu>();
        bullet.parent=this;
    }
}