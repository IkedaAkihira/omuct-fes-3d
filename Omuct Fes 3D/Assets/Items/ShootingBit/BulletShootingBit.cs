using UnityEngine;

public class BulletShootingBit : MonoBehaviour {
    public Player parent;
    private void OnTriggerEnter(Collider other) {
        if(other.isTrigger)
            return;
        Destroy(gameObject);
        Player player=other.GetComponent<Player>();
        if(player==null)
            return;
        if(player==parent)
            return;
        player.Damage(new DamageSource(1));
    }
}