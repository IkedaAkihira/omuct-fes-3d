//呪文
using UnityEngine;
using System;

// BulletPoison のコピー

public class BulletTokeito : MonoBehaviour
{
    //外部からparentを設定したいので、publicにする。
    public Player parent;

    private void Update()
    {
        Rigidbody rb = this.GetComponent<Rigidbody>();
        if(rb.velocity.magnitude >= 1.0e-4)
        {
            transform.forward = rb.velocity;
        }
    }

    //何かにあたったときの処理を行う。
    private void OnTriggerEnter(Collider other)
    {
        //相手がトリガーなら処理を終わる。
        //トリガーは、衝突判定がないが、あたったことを検知できるやつ。
        if (other.isTrigger)
            return;

        //あたったやつからPlayerを取得する。
        Player player = other.GetComponent<Player>();

        //playerがparent、つまり弾丸を出した人だったら処理を終わる。
        if (player == this.parent)
            return;

        //弾丸自身を消す。
        Destroy(this.gameObject);

        // 当たった場所に時計塔を生やす
        Vector3 pos = transform.position + new Vector3(0.0f, 0.0f, 0.0f);
        pos.y = 0.0f;
        // RealTokeito ファイルを読み込みます。作ったつもり。
        GameObject realTokeitoObject = Resources.Load("Prefabs/RealTokeito") as GameObject;

        // tokeitoObjectを具現化して、tokeitoCloneに格納する。第2引数で位置、第3引数で向きを指定する。
        GameObject tokeitoClone = GameObject.Instantiate(realTokeitoObject, pos, Quaternion.identity);
        RealTokeito realTokeito = tokeitoClone.GetComponent<RealTokeito>();
        realTokeito.centerPos = pos + new Vector3(0.0f, 0.0f, 0.0f);
    }
}
