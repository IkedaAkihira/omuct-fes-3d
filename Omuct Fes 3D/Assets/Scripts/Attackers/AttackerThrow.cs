using UnityEngine;

enum ShootType{
    Shoot,
    Throw,
    Fixed
}

public class AttackerThrow : Attacker{
    [SerializeField,TooltipAttribute("弾丸として使用するオブジェクト")] public Bullet bulletPrefab;

    [SerializeField,TooltipAttribute("Shoot:照準が当たっている物に向かって発射\nThrow:カメラと同じ向きに投げる\nFixed高さ固定で発射する")]
    ShootType shootType;
    
    [SerializeField,
    TooltipAttribute("弾丸を飛ばす方向をどれだけ乱れさせるか")]
    float randomSize;
    
    [SerializeField,TooltipAttribute("一回の射撃で何発の弾丸を発射するか(散弾の話)")]
    int bulletCount = 1;
    [SerializeField,TooltipAttribute("一回の攻撃で何回射撃するか(連射の話)")] int fireCount = 1;
    [SerializeField,TooltipAttribute("連射の間隔")] int fireInterval = 10;
    [SerializeField,TooltipAttribute("弾丸に加える力")] public float bulletForce = 1000f;

    int remainingFireCount = 0;
    long nextAttackTime = -1001001001;

    [SerializeField,TooltipAttribute("弾丸を縦に何度ずらすかをdegreeで指定する")] float attackRotY = 0f;

    void FixedUpdate()
    {
        if(GameMaster.instance.gameTime>=nextAttackTime && remainingFireCount>0){
            remainingFireCount--;
            nextAttackTime+=fireInterval;
            Shoot();
        }
    }

    public override void Attack()
    {
        base.Attack();
        remainingFireCount = fireCount;
        nextAttackTime = GameMaster.instance.gameTime+fireInterval;
    }

    void Shoot(){
        for(int i=0;i<bulletCount;i++){
            GameObject cloneObject=Instantiate(bulletPrefab.gameObject,transform.position,Quaternion.identity);
            Rigidbody rb=cloneObject.GetComponent<Rigidbody>();
            rb.AddForce((GetBulletVector3().normalized
            + new Vector3(
                (float)Random.value * randomSize * 2 - randomSize,
                (float)Random.value * randomSize * 2 - randomSize,
                (float)Random.value * randomSize * 2 - randomSize)) * bulletForce);
            Bullet bullet=cloneObject.GetComponent<Bullet>();
            bullet.parent=p;
        }
    }

    virtual protected Vector3 GetBulletVector3(){
        Quaternion rotQuaternion = Quaternion.Euler(0f,0f,attackRotY);
        Vector3 standardVec = new Vector3(-1f,0f,0f);
        Quaternion attackQuaternion;
        switch(shootType){
            case ShootType.Shoot:
                attackQuaternion = p.TargetVecAsQuaternion;
                break;
            case ShootType.Throw:
                attackQuaternion = p.CameraRotationAsQuaternion;
                break;
            case ShootType.Fixed:
                attackQuaternion =p.CameraRotationAsQuaternion2D;
                break;
            default:
                attackQuaternion = p.TargetVecAsQuaternion;
                break;
        }
        return attackQuaternion * rotQuaternion * standardVec;
    }
}