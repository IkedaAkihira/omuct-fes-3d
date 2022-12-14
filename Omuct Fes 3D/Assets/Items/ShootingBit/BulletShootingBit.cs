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
        Player player=other.GetComponent<Player>();
        if(player==parent)
            return;
        Destroy(gameObject);

        if(player==null)
            return;
        player.Damage(new DamageSource(1));
    }

    private void FixedUpdate() {
        if(GameMaster.instance.gameTime-startTime>400)
            Destroy(this.gameObject);
    }
}