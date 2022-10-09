using UnityEngine;
using System;

public class ShootingBit : MonoBehaviour {
    int time=1000;
    public Player parent;
    public GameObject attackObject;
    public float attackForce=2000f;

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
        currentRoation=(currentRoation*rotationAsympotic+parent.cameraRotation)/(rotationAsympotic+1);
        Vector3 goalPosition=parent.transform.position+new Vector3(Mathf.Cos(currentRoation+relativeRotation),0,Mathf.Sin(currentRoation+relativeRotation));
        transform.position=(transform.position*(moveAsympotic)+goalPosition)/(moveAsympotic+1);


        if(time%10!=0)
            return;
        RaycastHit hit;
        Vector3 attackVec;
        if(
            Physics.Raycast(parent.cameraPos,parent.cameraVec3,out hit,Mathf.Infinity)
            &&hit.collider.GetComponent<Player>()!=parent
        ){
            attackVec=(hit.point-transform.position).normalized;
        }else{
            attackVec=parent.cameraVec3.normalized;
        }
        GameObject cloneObject=Instantiate(attackObject,transform.position+attackVec*2,Quaternion.identity);
        Rigidbody rb=cloneObject.GetComponent<Rigidbody>();
        rb.AddForce(attackVec*attackForce);
        BulletEkipu bullet=cloneObject.GetComponent<BulletEkipu>();
        bullet.parent=parent;

    }
}