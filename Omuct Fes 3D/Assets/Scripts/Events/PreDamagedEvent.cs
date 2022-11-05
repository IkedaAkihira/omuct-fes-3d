public class PreDamagedEvent : Event {
    public Player damagedPlayer;
    public DamageSource damageSource;
    
    public PreDamagedEvent(Player damagedPlayer,DamageSource damageSource){
        this.damagedPlayer=damagedPlayer;
        this.damageSource=damageSource;
    }
}
