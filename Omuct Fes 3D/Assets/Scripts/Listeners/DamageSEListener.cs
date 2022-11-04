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
        if(e.damageSource is SpecialDamageSource){
            switch(((SpecialDamageSource)e.damageSource).type){
                case SpecialDamageSource.TYPE_POISON:
                    player.Play("poison");
                break;
            }
        }else{
            string soundName="";
            if(e.damagedPlayer is PlayerMonster)
                soundName = "damaged monster";
            else if(e.damagedPlayer is PlayerEkipu)
                soundName = "damaged ekipu";
            else if(e.damagedPlayer is PlayerChinanago)
                soundName = "damaged chinanago";
            player.Play(soundName);
        }
    }
    public void OnUseItem(UseItemEvent e){

    }
    public void OnJump(JumpEvent e){
        
    }
}