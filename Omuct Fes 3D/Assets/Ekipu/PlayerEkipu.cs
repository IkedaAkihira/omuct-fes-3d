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
        long time=DateTime.Now.Hour * 60 *60 * 1000 + DateTime.Now.Minute * 60 * 1000 + 
    DateTime.Now.Second * 1000 + DateTime.Now.Millisecond;
        if(time<lastAttackTime+attackInterval)
            return;
        lastAttackTime=time;
        RaycastHit hit;
        Vector3 attackVec;
        if(
            Physics.Raycast(transform.position+new Vector3(0f,1f,0f),cameraVec3,out hit,Mathf.Infinity)
            &&hit.collider.GetComponent<PlayerEkipu>()!=this
        ){
            attackVec=(hit.point-transform.position).normalized;
        }else{
            attackVec=cameraVec3.normalized;
        }
        GameObject cloneObject=Instantiate(attackObject,transform.position+attackVec*2,Quaternion.identity);
        Rigidbody rb=cloneObject.GetComponent<Rigidbody>();
        rb.AddForce(attackVec*attackForce);
    }
}