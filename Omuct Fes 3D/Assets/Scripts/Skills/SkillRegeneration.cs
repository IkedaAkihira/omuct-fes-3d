using UnityEngine;

[AddComponentMenu("Skills/Skill Regeneration")]
public class SkillRegeneration : Skill{
    
    [SerializeField,TooltipAttribute("何秒に一回回復するか。50で1秒に一回。")] int interval = 200;
    [SerializeField,TooltipAttribute("一回の回復量")] int amount = 1;


    override protected EventListener CreateListener(){
        return new RegenerationListener(this.player,this.interval,this.amount);
    }
}