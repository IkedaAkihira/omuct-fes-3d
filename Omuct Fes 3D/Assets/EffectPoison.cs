public class EffectPoison : Effect{
    int interval=50;
    int damage=1;
    public EffectPoison(int time){
        this.time=time;
        this.interval=interval;
        this.damage=damage;
    }
   override public void Tick(Player p){
        if(GameMaster.instance.gameTime%interval!=0)
            return;
        p.Damage(new DamageSource(damage));
    }
}