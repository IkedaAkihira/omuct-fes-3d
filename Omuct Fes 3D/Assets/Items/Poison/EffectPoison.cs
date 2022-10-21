using UnityEngine;

public class EffectPoison : Effect{
    //あとで調整できるように、ダメージを受ける間隔と毎回のダメージを指定している。今回は1damage/sec * 10sec = 10damage
    int interval=50;
    int damage=1;

    private ParticleSystem poisonParticle;

    //コンストラクタ　new EffectPoison(...)をやったときの処理を書いてある。
    public EffectPoison(int time)
    {
        this.time=time;
        this.poisonParticle=Resources.Load<ParticleSystem>("Prefabs/PoisonEffect");
    }

    //毎秒50回呼ばれる。
    override public void Tick(Player player)
    {
        //ゲーム内時間をintervalで割ったあまりが0の時、つまり、interval回ごとにプレイヤーにダメージを与える。
        if(GameMaster.instance.gameTime%interval==0)
        {
            //player.Damage(damageSource)でプレイヤーにダメージを与えられる。
            //damageSourceはダメージの情報を保持してる。
            player.Damage(new DamageSource(damage));
            ParticleSystem clone=GameObject.Instantiate(poisonParticle);
            clone.transform.position=player.transform.position;
        }
    }
}