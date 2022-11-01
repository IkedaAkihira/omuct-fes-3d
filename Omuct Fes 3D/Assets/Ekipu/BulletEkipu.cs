using UnityEngine;

public class BulletEkipu : MonoBehaviour {
    public Player parent;
    public int damage = 2;
    public int lifeTime = 100;
    public float magnification = 0.1f;

    public float defaultSize = 1f;

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
        transform.localScale = new Vector3(1f,1f,1f)*(defaultSize+(float)life*magnification);
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