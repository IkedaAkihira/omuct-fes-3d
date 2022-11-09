public class DamageSEListener: EventListener{
    public SEPlayer player;
    public DamageSEListener(SEPlayer player){
        this.player = player;
    }
    override public void OnDamaged(DamagedEvent e){
        //Debug.Log("damage");
        if(e.damageSource is SpecialDamageSource){
            switch(((SpecialDamageSource)e.damageSource).type){
                case SpecialDamageSource.TYPE_POISON:
                    player.Play("poison");
                break;
            }
        }else{
            string soundName="";
            if(e.damagedPlayer.id == 1)
                soundName = "damaged monster";
            else if(e.damagedPlayer.id == 0)
                soundName = "damaged ekipu";
            else if(e.damagedPlayer.id == 2)
                soundName = "damaged chinanago";
            player.Play(soundName);
        }
    }
}