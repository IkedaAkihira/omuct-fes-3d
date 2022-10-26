//呪文
using UnityEngine;
using System;


public class ItemTokeito : Item
{
    public ItemTokeito(){
        this.itemImage=Resources.Load<Texture2D>("Textures/Tokeito");
    }
    //この関数の中にアイテムを使った時の処理を書きます。
    public override void Use(Player user)
    {
        //TokeitoObjectファイルを読み込みます。作ったつもり。
        GameObject tokeitoObject = Resources.Load("Prefabs/TokeitoObject") as GameObject;

        //tokeitoObjectを具現化して、tokeitoCloneに格納する。第2引数で位置、第3引数で向きを指定する。
        GameObject tokeitoClone = GameObject.Instantiate(tokeitoObject, user.transform.position, Quaternion.identity);

        //BulletTokeitoコンポーネントを取得する。これも作ったつもり。
        BulletTokeito bulletTokeito = tokeitoClone.GetComponent<BulletTokeito>();

        //bulletPoisonにparentを設定する。
        bulletTokeito.parent = user;

        //Rigidbodyコンポーネントを取得する。
        Rigidbody rb = tokeitoClone.GetComponent<Rigidbody>();

        //poisonCloneにプレイヤーのカメラが向いている方向に力をかける。これで具現化した弾が飛んでいく。
        rb.AddForce(user.toTargetVec * 1000f);
    }
}
