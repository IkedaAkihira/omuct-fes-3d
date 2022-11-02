using UnityEngine;

public class BulletEkipu : MonoBehaviour {
    public Player parent;
    public int damage = 2;
    public int lifeTime = 100;
    public float magnification = 0.1f;

    public float defaultSize = 1f;

    long startTime;
    public Quaternion targetRotation;
    public PlayerEkipu parentEkipu;
    public int splitRemain = 1;

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
        if(
            splitRemain > 0 &&
            GameMaster.instance.gameTime - startTime >= parentEkipu.splitInterval
        ){
            Quaternion[] rotations = new Quaternion[3];
            rotations[0] = Quaternion.Euler(
                0.0f,
                parentEkipu.attackWidthAngle + parentEkipu.attackVibration.x * (Random.value * 2.0f - 1.0f), // horizontal
                parentEkipu.attackVibration.y * (Random.value * 2.0f - 1.0f) // vertical
            );
            rotations[1] = Quaternion.identity;
            rotations[2] = Quaternion.Inverse(rotations[0]);

            
            foreach (Quaternion rawrot in rotations)
            {
                // 1. apply main rotation (rawrot)
                // 2. read cache camera rotation
                Quaternion rot = targetRotation * rawrot;

                // launch way
                Vector3 way = rot * new Vector3(-1f, 0f, 0f);

                GameObject cloneObject = Instantiate(parentEkipu.attackObject, transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
                Rigidbody rb = cloneObject.GetComponent<Rigidbody>();
                rb.AddForce(way * parentEkipu.attackForce);
                BulletEkipu bullet = cloneObject.GetComponent<BulletEkipu>();
                bullet.parent = this.parent;
                bullet.parentEkipu = this.parentEkipu;
                bullet.splitRemain = this.splitRemain - 1;
            }
            Destroy(this.gameObject);
            return;
        }
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