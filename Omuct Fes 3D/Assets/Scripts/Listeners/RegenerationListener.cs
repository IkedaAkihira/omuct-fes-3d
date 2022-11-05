public class RegenerationListener: EventListener{
    Player player;
    int interval;
    int amount;

    public RegenerationListener(Player player,int interval,int amount){
        this.player = player;
        this.interval = interval;
        this.amount = amount;
    }
    
    override public void OnFixedUpdate(){
        if(GameMaster.instance.gameTime%interval == 0){
            player.Damage(new DamageSource(-amount));
        }
    }
}