using UnityEngine;

public class BulletChinanago : Bullet {
    [SerializeField] int damage = 2;

    private void Start() {
        transform.forward = rb.velocity;
    }

    private void Update() {
        this.transform.Rotate( 720.0f * Time.deltaTime, 0f ,0f );
    }

    override protected void HitPlayer(Player p){
        p.Damage(new DamageSource(damage));
    }
}