//呪文
using UnityEngine;
using System;

// BulletPoison のコピー

public class BulletTokeito : Bullet
{
    private void Update()
    {
        if(rb.velocity.magnitude >= 1.0e-4)
        {
            transform.forward = rb.velocity;
        }
    }

    override protected void HitObject(){
        // 当たった場所に時計塔を生やす
        Vector3 pos = transform.position + new Vector3(0.0f, 0.0f, 0.0f);
        pos.y = 0.0f;
        // RealTokeito ファイルを読み込みます。作ったつもり。
        GameObject realTokeitoObject = Resources.Load("Prefabs/RealTokeito") as GameObject;

        // tokeitoObjectを具現化して、tokeitoCloneに格納する。第2引数で位置、第3引数で向きを指定する。
        GameObject tokeitoClone = GameObject.Instantiate(realTokeitoObject, pos, Quaternion.identity);
        RealTokeito realTokeito = tokeitoClone.GetComponent<RealTokeito>();
        realTokeito.centerPos = pos + new Vector3(0.0f, 0.0f, 0.0f);

        GameMaster.instance.sePlayer.Play("tokeito");
    }
}
