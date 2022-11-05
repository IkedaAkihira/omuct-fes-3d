using UnityEngine;

public class BulletShootingBit : Bullet {
    [SerializeField] int damage = 1;
    override protected void HitPlayer(Player p){
        p.Damage(new DamageSource(damage));
    }
}