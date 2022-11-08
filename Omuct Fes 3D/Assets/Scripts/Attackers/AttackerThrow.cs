using UnityEngine;

public class AttackerThrow : Attacker{
    [SerializeField,TooltipAttribute("弾丸として使用するオブジェクト")] GameObject bulletPrefab;

    [SerializeField,TooltipAttribute("チェックを入れると、標準を合わせた敵や壁に向かって弾丸を飛ばします。\n狙撃系はチェックを入れて、投げもの系は入れないといい感じになります。")]
    bool useRaycastTargetting;
    
    [SerializeField,
    TooltipAttribute("弾丸を飛ばす方向をどれだけ乱れさせるか")]
    float randomSize;
    
    [SerializeField,TooltipAttribute("一回の射撃で何発の弾丸を発射するか(散弾の話)")]
    int bulletCount = 1;
    [SerializeField,TooltipAttribute("一回の攻撃で何回射撃するか(連射の話)")] int fireCount = 1;
    [SerializeField,TooltipAttribute("連射の間隔")] int fireInterval = 10;
    [SerializeField,TooltipAttribute("弾丸に加える力")] float bulletForce = 1000f;

    int remainingFireCount = 0;
    long nextAttackTime = -1001001001;

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
            GameObject cloneObject=Instantiate(bulletPrefab,transform.position,Quaternion.identity);
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
        return (this.useRaycastTargetting)?p.toTargetVec:p.cameraVec3;
    }
}