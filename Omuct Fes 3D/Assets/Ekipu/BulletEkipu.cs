using UnityEngine;

public class BulletEkipu : MonoBehaviour {
    public GameObject explosion;
    private void OnTriggerEnter(Collider other) {
        Destroy(this.gameObject);
        Instantiate(explosion,transform.position,Quaternion.identity);
    }
}