using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMonster : Player{
    public GameObject attackObject;
    public float attackForce=1000f;

    
    override protected void Attack(){
        int nutsCount=3;
        float randomSize= 0.1f;
        for(int i=0;i<nutsCount;i++){
            GameObject cloneObject=Instantiate(attackObject,transform.position,Quaternion.identity);
            Rigidbody rb=cloneObject.GetComponent<Rigidbody>();
            rb.AddForce((toTargetVec+new Vector3(
                (float)Random.value * randomSize * 2 - randomSize,
                (float)Random.value * randomSize * 2 - randomSize,
                (float)Random.value * randomSize * 2 - randomSize)
            ).normalized*attackForce);
            BulletMonster bullet=cloneObject.GetComponent<BulletMonster>();
            bullet.parent=this;
        }
    }
}