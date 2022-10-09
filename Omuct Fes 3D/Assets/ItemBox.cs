using UnityEngine;

public class ItemBox : MonoBehaviour {
    private void Update() {
        transform.Rotate( 0f, 120.0f * Time.deltaTime ,0f );
    }
    private void OnTriggerEnter(Collider other) {
        Player player=other.GetComponent<Player>();
        if(player==null)
            return;
        if(player.item!=null)
            return;
        player.item=new ItemShootingBit();
        Destroy(gameObject);
    }
}