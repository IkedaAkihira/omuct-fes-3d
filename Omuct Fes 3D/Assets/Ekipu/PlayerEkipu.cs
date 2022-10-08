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
        RaycastHit hit;
        Vector3 attackVec;
        if(
            Physics.Raycast(cameraPos,cameraVec3,out hit,Mathf.Infinity)
            &&hit.collider.GetComponent<PlayerEkipu>()!=this
        ){
            attackVec=(hit.point-transform.position).normalized;
        }else{
            attackVec=cameraVec3.normalized;
        }
        GameObject cloneObject=Instantiate(attackObject,transform.position+attackVec*2,Quaternion.identity);
        Rigidbody rb=cloneObject.GetComponent<Rigidbody>();
        rb.AddForce(attackVec*attackForce);
        BulletEkipu bullet=cloneObject.GetComponent<BulletEkipu>();
        bullet.parent=this;
    }
}