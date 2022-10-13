public class UseItemEvent : Event {
    public Player itemUser;
    public Item item;
    
    public UseItemEvent(Player itemUser,Item item){
        this.itemUser=itemUser;
        this.item=item;
    }
}