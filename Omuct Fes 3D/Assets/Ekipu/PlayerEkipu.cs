using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class PlayerEkipu : Player{
    public GameObject attackObject;
    private long lastAttackTime=0;
    override protected void Attack(){
        long time=DateTime.Now.Hour * 60 *60 * 1000 + DateTime.Now.Minute * 60 * 1000 + 
    DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
        if(time<lastAttackTime+1000)
            return;
        lastAttackTime=time;
        GameObject cloneObject=Instantiate(attackObject,transform.position+cameraVec3*2,Quaternion.identity);
        Rigidbody rb=cloneObject.GetComponent<Rigidbody>();
        rb.AddForce(this.cameraVec3*1000);
    }
}