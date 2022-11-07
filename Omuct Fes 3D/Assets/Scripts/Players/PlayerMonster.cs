using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMonster : Player{
    public GameObject attackObject;
    public float attackForce=1000f;
    public float attackRotY = 20.0f;
    /*override protected void Attack(){
        int nutsCount=3;
        float randomSize= 0.1f;

        Quaternion rotOffset = Quaternion.Euler(
                0.0f,
                0.0f, // horizontal
                attackRotY // vertical
            );

        for(int i=0;i<nutsCount;i++){
            GameObject cloneObject=Instantiate(attackObject,transform.position,Quaternion.identity);
            Rigidbody rb=cloneObject.GetComponent<Rigidbody>();
            //Vector3 attackTarget = toTargetVec;
            Vector3 attackTarget = CameraRotationAsQuaternion * rotOffset * new Vector3(-1f, 0f, 0f);
            rb.AddForce((attackTarget+new Vector3(
                (float)Random.value * randomSize * 2 - randomSize,
                (float)Random.value * randomSize * 2 - randomSize,
                (float)Random.value * randomSize * 2 - randomSize)
            ).normalized*attackForce);
            BulletMonster bullet=cloneObject.GetComponent<BulletMonster>();
            bullet.parent=this;
        }
    }*/
}