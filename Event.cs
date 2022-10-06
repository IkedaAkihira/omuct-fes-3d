public class Event{
    public bool isAvailable=true;
}

public class AttackEvent : Event {
    public Player attacker;
    
    public AttackEvent(Player attacker){
        this.attacker=attacker;
    }
}
public class DamageEvent : Event {
    public Player damagedPlayer;
    public DamageSource damageSource;
    
    public DamageEvent(Player damagedPlayer,DamageSource damageSource){
        this.damagedPlayer=damagedPlayer;
        this.damageSource=damageSource;
    }
}
public class UseItemEvent : Event {
    public Player itemUser;
    public Item item;
    
    public UseItemEvent(Player itemUser,Item item){
        this.itemUser=itemUser;
        this.item=item;
    }
}