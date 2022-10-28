public class DamageSEListener: EventListener{
    public SEPlayer player;
    public DamageSEListener(SEPlayer player){
        this.player = player;
    }
    public void OnMove(MoveEvent e){
        
    }
    public void OnAttack(AttackEvent e){

    }
    public void OnDamaged(DamageEvent e){
        //Debug.Log("damage");
        player.Play("damage");
    }
    public void OnUseItem(UseItemEvent e){

    }
    public void OnJump(JumpEvent e){
        
    }
}