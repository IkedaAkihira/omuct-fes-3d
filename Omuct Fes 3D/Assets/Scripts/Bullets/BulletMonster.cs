using UnityEngine;

public class BulletMonster : Bullet {
    [SerializeField] int damage = 1;


    private void Update() {
        this.transform.Rotate( 0f, 720.0f * Time.deltaTime ,0f );
    }
    override protected void HitPlayer(Player p){
        p.Damage(new DamageSource(damage));
    }
}