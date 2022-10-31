public class DamageEvent : Event {
    public Player damagedPlayer;
    public DamageSource damageSource;
    
    public DamageEvent(Player damagedPlayer,DamageSource damageSource){
        this.damagedPlayer=damagedPlayer;
        this.damageSource=damageSource;
    }
}
