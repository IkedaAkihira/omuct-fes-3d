public class ProtectionListener: EventListener{
    Player player;
    float magnification;

    public ProtectionListener(Player player,float magnification){
        this.player = player;
        this.magnification = magnification;
    }
    
    override public void OnPreDamaged(PreDamagedEvent e){
        e.damageSource.amount = (int)(e.damageSource.amount*this.magnification);
    }
}