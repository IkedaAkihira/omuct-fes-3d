using UnityEngine;

public class BulletEkipu : MonoBehaviour {
    public GameObject explosion;
    public Player parent;
    private void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
        ExplosionEkipu cloneExplosion=Instantiate(explosion,transform.position,Quaternion.identity)
        .GetComponent<ExplosionEkipu>();
        cloneExplosion.parent=parent;
    }
}