public class PoisonListener: EventListener{
    public void OnMove(MoveEvent e){
        if(e.player.effects.ContainsKey(EffectPoison.TYPE))
            e.Multiply(0.6f);
    }
    public void OnAttack(AttackEvent e){

    }
    public void OnDamaged(DamageEvent e){

    }
    public void OnUseItem(UseItemEvent e){

    }
    public void OnJump(JumpEvent e){
        if(e.player.effects.ContainsKey(EffectPoison.TYPE))
            e.Multiply(0.7f);
    }
}