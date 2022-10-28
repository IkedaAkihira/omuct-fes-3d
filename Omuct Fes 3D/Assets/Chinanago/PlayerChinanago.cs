using UnityEngine;

public class PlayerChinanago : Player {
    public int diveTime = 0;
    public int surfaceTime = 0;

    public float attackForce=1000f;

    public GameObject attackObject;
    override protected void Attack(){
        

        
        GameObject cloneObject=Instantiate(attackObject,transform.position+new Vector3(0f,0f,0f),Quaternion.identity);
        Rigidbody rb=cloneObject.GetComponent<Rigidbody>();
        rb.AddForce(toTargetVec*attackForce);
        BulletEkipu bullet=cloneObject.GetComponent<BulletEkipu>();
        bullet.parent=this;
    }
        
    override protected void AdditionalFixed()
    {
        if(diveTime>0){
            diveTime--;
            if(diveTime == 0){
                this.animator.SetTrigger("Surface");
                this.transform.position = GameMaster.instance.GetPlayer(!this.isLeftPlayer).transform.position;
                surfaceTime = 100;
            }
        }

        if(surfaceTime>0){
            surfaceTime--;
        }


    }


}