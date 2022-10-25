using UnityEngine;

public class BulletShootingBit : MonoBehaviour {
    public Player parent;
    private long startTime;
    private void Awake() {
        startTime=GameMaster.instance.gameTime;
    }
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

    private void FixedUpdate() {
        if(GameMaster.instance.gameTime-startTime>400)
            Destroy(this.gameObject);
    }
}