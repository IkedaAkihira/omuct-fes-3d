public class RiverListener: EventListener{
    public void OnAttack(AttackEvent e){

    }
    public void OnDamaged(DamageEvent e){

    }
    public void OnUseItem(UseItemEvent e){

    }
    public void OnJump(JumpEvent e){
        if(e.player.effects.ContainsKey(EffectRiver.TYPE))
            e.Multiply(2f);
    }
    
    public void OnMove(MoveEvent e){
        
    }
}