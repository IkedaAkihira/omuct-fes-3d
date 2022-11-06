using UnityEngine;

[AddComponentMenu("Skills/Skill Protection")]
public class SkillProtection : Skill{
    [SerializeField,TooltipAttribute("受けるダメージを何倍にするか。\n別に普段より多くダメージ受けるようにしてもいい。")]
    float magnification = 1f;


    override protected EventListener CreateListener(){
        return new ProtectionListener(this.player,this.magnification);
    }
}