using UnityEngine;

public class BulletMonster : MonoBehaviour {
    public Player parent;
    public int damage = 1;
    public int lifeTime = 100;

    long startTime;

    Rigidbody rb;

    private void Start() {
        this.rb=this.GetComponent<Rigidbody>();
        this.startTime=GameMaster.instance.gameTime;
    }

    private void FixedUpdate() {
        if(GameMaster.instance.gameTime-startTime>100)
            Destroy(this.gameObject);
    }

    private void Update() {
        this.transform.Rotate( 0f, 720.0f * Time.deltaTime ,0f );
    }
    private void OnTriggerEnter(Collider other) {
        if(other.isTrigger)
            return;
        Player p=other.GetComponent<Player>();
        if(p==this.parent)
            return;
        

        if(p!=null)
            p.Damage(new DamageSource(damage));
        
        Destroy(this.gameObject);

    }
}