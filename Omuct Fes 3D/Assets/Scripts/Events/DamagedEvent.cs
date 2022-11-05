public class DamagedEvent : Event {
    public Player damagedPlayer;
    public DamageSource damageSource;
    
    public DamagedEvent(Player damagedPlayer,DamageSource damageSource){
        this.damagedPlayer=damagedPlayer;
        this.damageSource=damageSource;
    }
}
