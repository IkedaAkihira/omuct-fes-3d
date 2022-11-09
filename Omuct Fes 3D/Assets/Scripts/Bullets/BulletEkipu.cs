using UnityEngine;

public class BulletEkipu : Bullet {
    [SerializeField] int damage = 2;
    public float magnification = 0.1f;

    public float defaultSize = 1f;

    Quaternion targetRotation;
    [SerializeField] int splitRemain = 1;

    [SerializeField] int splitInterval = 30;
    [SerializeField] Vector2 attackVibration = new Vector2(1.5f,1.5f);
    [SerializeField] float attackWidthAngle = 12f;

    float attackForce = 3000f;

    private void Start() {
        if(parent.attacker is AttackerThrow)
            this.attackForce = ((AttackerThrow)parent.attacker).bulletForce;
        this.targetRotation = parent.TargetVecAsQuaternion;
    }

    private void Update() {
        transform.localScale = new Vector3(1f,1f,1f)*(defaultSize+(float)(GameMaster.instance.gameTime-startTime)*magnification);

        this.transform.Rotate( 0f, 720.0f * Time.deltaTime ,0f );
        if(
            splitRemain > 0 &&
            GameMaster.instance.gameTime - startTime >= splitInterval
        ){
            Quaternion[] rotations = new Quaternion[3];
            rotations[0] = Quaternion.Euler(
                0.0f,
                attackWidthAngle + attackVibration.x * (Random.value * 2.0f - 1.0f), // horizontal
                attackVibration.y * (Random.value * 2.0f - 1.0f) // vertical
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

                GameObject cloneObject = Instantiate(this.gameObject, transform.position + new Vector3(0f, 0f, 0f), Quaternion.identity);
                Rigidbody rb = cloneObject.GetComponent<Rigidbody>();
                rb.AddForce(way * attackForce);
                BulletEkipu bullet = cloneObject.GetComponent<BulletEkipu>();
                bullet.parent = this.parent;
                bullet.splitRemain = this.splitRemain - 1;
            }
            Destroy(this.gameObject);
            return;
        }
    }

    override protected void HitPlayer(Player p){
        p.Damage(new DamageSource(damage));
    }
}