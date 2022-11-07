using UnityEngine;

public class PlayerChinanago : Player {
    public int diveTime = 0;
    public int surfaceTime = 0;

    public float attackForce=1000f;

    [SerializeField] long bubbleDuration = 5;
    [SerializeField] long maxBubbleCount = 5;
    [SerializeField] float bubbleVerticalForce = 0.5f;

    public GameObject attackObject;

    /*override protected void Attack(){
        
    }
        
    override protected void AdditionalFixed()
    {
        if(diveTime>0){
            diveTime--;
            if(diveTime == 0){
                this.animator.SetTrigger("Surface");
                this.transform.position = GameMaster.instance.GetPlayer(!this.isLeftPlayer).transform.position;
                surfaceTime = 50;
            }
        }

        if(surfaceTime>0){
            surfaceTime--;
        }

        if((GameMaster.instance.gameTime-lastAttackTime)%bubbleDuration == 0 && (GameMaster.instance.gameTime-lastAttackTime) < bubbleDuration * maxBubbleCount){
            Bubble();
        }


    }*/

    void Bubble(){
        GameObject cloneObject=Instantiate(attackObject,transform.position+new Vector3(0f,0f,0f),Quaternion.identity);
        cloneObject.transform.forward = cameraVec2;
        Rigidbody rb=cloneObject.GetComponent<Rigidbody>();
        rb.AddForce((cameraVec2+new Vector3(0f,bubbleVerticalForce,0f))*attackForce);
        BulletChinanago bullet=cloneObject.GetComponent<BulletChinanago>();
        bullet.parent=this;
    }
}