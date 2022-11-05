using UnityEngine;

public class SkillRegeneration : Skill{
    [SerializeField] int interval = 200;
    [SerializeField] int amount = 1;

    override protected EventListener CreateListener(){
        return new RegenerationListener(this.player,this.interval,this.amount);
    }
}