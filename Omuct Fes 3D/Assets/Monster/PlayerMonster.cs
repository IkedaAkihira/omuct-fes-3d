using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
public class PlayerMonster : Player{
    public GameObject attackObject;
    public float attackForce=1000f;

    
    override protected void Attack(){
        int nutsCount=3;
        System.Random rand=new System.Random();
        for(int i=0;i<nutsCount;i++){
            GameObject cloneObject=Instantiate(attackObject,transform.position,Quaternion.identity);
            Rigidbody rb=cloneObject.GetComponent<Rigidbody>();
            rb.AddForce((toTargetVec+new Vector3((float)rand.NextDouble()*0.2f,(float)rand.NextDouble()*0.2f,(float)rand.NextDouble()*0.2f)).normalized*attackForce);
            BulletEkipu bullet=cloneObject.GetComponent<BulletEkipu>();
            bullet.parent=this;
        }
    }
}