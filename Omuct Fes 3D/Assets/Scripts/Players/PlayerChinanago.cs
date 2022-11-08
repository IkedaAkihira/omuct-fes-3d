using UnityEngine;

public class PlayerChinanago : Player {
    public int diveTime = 0;
    public int surfaceTime = 0;

        
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
    }
}