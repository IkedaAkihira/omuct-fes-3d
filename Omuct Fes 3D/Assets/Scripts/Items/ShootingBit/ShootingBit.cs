using UnityEngine;
using System;

public class ShootingBit : MonoBehaviour {
    public int time=1000;
    public int duration=50;
    public Player parent;
    public GameObject attackObject;
    public float attackForce=2000f;
    public float range=1.2f;

    public uint moveAsympotic=1;
    public uint rotationAsympotic=1;

    public float relativeRotation=Mathf.PI/2;

    public float currentRoation=0f;

    private void FixedUpdate() {
        time--;
        if(time<=0){
            Destroy(this.gameObject);
            return;
        }
        currentRoation=(currentRoation*rotationAsympotic+parent.cameraRotation+relativeRotation)/(rotationAsympotic+1);
        transform.position=parent.transform.position+new Vector3(Mathf.Cos(currentRoation),0,Mathf.Sin(currentRoation))*1.2f;


        if(time%duration!=0)
            return;
        RaycastHit hit;
        Vector3 attackVec;
        if(
            Physics.Raycast(parent.cameraPos,parent.cameraVec3,out hit,Mathf.Infinity,1<<3|1<<6)
            &&hit.collider.GetComponent<Player>()!=parent
        ){
            attackVec=(hit.point-transform.position).normalized;
        }else{
            attackVec=parent.cameraVec3.normalized;
        }
        transform.forward = attackVec;
        GameObject cloneObject=Instantiate(attackObject,transform.position+attackVec,Quaternion.identity);
        Rigidbody rb=cloneObject.GetComponent<Rigidbody>();
        rb.AddForce(attackVec*attackForce);
        BulletShootingBit bullet=cloneObject.GetComponent<BulletShootingBit>();
        bullet.parent=parent;
    }
}