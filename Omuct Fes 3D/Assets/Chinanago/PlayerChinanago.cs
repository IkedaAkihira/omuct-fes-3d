using UnityEngine;

public class PlayerChinanago : Player {
    public int diveTime = 0;
    public int surfaceTime = 0;

    override protected void Attack(){

    }
        
    void AdditionalFixed()
    {
        if(diveTime>0){
            diveTime--;
            if(diveTime == 0){
                this.transform.position= new Vector3(0f,0f,0f);
                this.animator.SetTrigger("Surface");
                surfaceTime = 50;

            }
        }


    }


}