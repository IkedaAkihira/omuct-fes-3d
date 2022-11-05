using UnityEngine;

public class SkillProtection : Skill{
    [SerializeField] float magnification;

    override protected EventListener CreateListener(){
        return new ProtectionListener(this.player,this.magnification);
    }
}