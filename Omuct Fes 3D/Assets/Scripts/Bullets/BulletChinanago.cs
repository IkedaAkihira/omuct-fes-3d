using UnityEngine;

public class BulletChinanago : MonoBehaviour {
    public Player parent;
    public int damage = 2;
    public int lifeTime = 100;


    long startTime;

    Rigidbody rb;

    private void Start() {
        this.rb=this.GetComponent<Rigidbody>();
        this.startTime=GameMaster.instance.gameTime;
    }

    private void FixedUpdate() {
        long life = GameMaster.instance.gameTime-startTime;
        if(life>lifeTime)
            Destroy(this.gameObject);
    }

    private void Update() {
        this.transform.Rotate( 720.0f * Time.deltaTime, 0f ,0f );
    }
    private void OnTriggerEnter(Collider other) {
        if(other.isTrigger)
            return;
        Player p=other.GetComponent<Player>();
        if(p==this.parent)
            return;
        

        if(p!=null){
            p.Damage(new DamageSource(damage));
            parent.AddHitCount();
        }
        
        Destroy(this.gameObject);

    }
}