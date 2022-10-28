public class ChinanagoListener: EventListener{
    public void OnMove(MoveEvent e){

    }
    public void OnAttack(AttackEvent e){

    }
    public void OnDamaged(DamageEvent e){

    }
    public void OnUseItem(UseItemEvent e){

    }
    public void OnJump(JumpEvent e){
        if(e.player is PlayerChinanago){
            e.player.animator.SetTrigger("Dive");
            PlayerChinanago chinanago = (PlayerChinanago)e.player;
            chinanago.diveTime = 50;
        }
    }
}