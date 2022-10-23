//呪文
using UnityEngine;
using System;


public class BulletPoison : MonoBehaviour
{
    //外部からparentを設定したいので、publicにする。
    public Player parent = null;

    private GameObject explosion;

    private void Awake()
    {
        explosion=Resources.Load<GameObject>("Prefabs/PoisonArea");
    }

    //何かにあたったときの処理を行う。
    private void OnTriggerEnter(Collider other)
    {
        //相手がトリガーなら処理を終わる。
        //トリガーは、衝突判定がないが、あたったことを検知できるやつ。
        if(other.isTrigger)
            return;

        //playerがparent、つまり弾丸を出した人だったら処理を終わる。
        if(other.GetComponent<Player>()==this.parent)
            return;
        
        //弾丸自身を消す。
        Instantiate(this.explosion,this.transform.position,Quaternion.identity);
        Destroy(this.gameObject);
    }
}