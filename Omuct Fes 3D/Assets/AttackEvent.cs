public class AttackEvent : Event {
    public Player attacker;
    
    public AttackEvent(Player attacker){
        this.attacker=attacker;
    }
}
