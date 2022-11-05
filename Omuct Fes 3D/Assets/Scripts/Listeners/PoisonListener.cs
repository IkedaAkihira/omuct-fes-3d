public class PoisonListener: EventListener{
    override public void OnMove(MoveEvent e){
        if(e.player.effects.ContainsKey(EffectPoison.TYPE))
            e.Multiply(0.6f);
    }
    override public void OnAttack(AttackEvent e){

    }
    override public void OnDamaged(DamagedEvent e){

    }

    override public void OnPreDamaged(PreDamagedEvent e){

    }
    override public void OnUseItem(UseItemEvent e){

    }
    override public void OnJump(JumpEvent e){
        if(e.player.effects.ContainsKey(EffectPoison.TYPE))
            e.Multiply(0.7f);
    }
}