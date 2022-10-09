using UnityEngine;

public class BulletEkipu : MonoBehaviour {
    public GameObject explosion;
    public Player parent;

    long startTime;

    private void Start() {
        startTime=GameMaster.instance.gameTime;
    }

    private void FixedUpdate() {
        if(GameMaster.instance.gameTime-startTime>100)
            Bomb();
    }
    private void OnTriggerEnter(Collider other) {
        if(other.isTrigger)
            return;
        Player p=other.GetComponent<Player>();
        if(p!=null&&p==parent)
            return;
        Bomb();
    }

    private void Bomb(){
        Destroy(gameObject);
        ExplosionEkipu cloneExplosion=Instantiate(explosion,transform.position,Quaternion.identity)
        .GetComponent<ExplosionEkipu>();
        cloneExplosion.parent=parent;
    }
}