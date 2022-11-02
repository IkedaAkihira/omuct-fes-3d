//呪文
using UnityEngine;
using System;


public class ItemPoison : Item
{
    public ItemPoison(){
        this.itemSprite = Resources.Load<Sprite>("Textures/Poison");
    }
    //この関数の中にアイテムを使った時の処理を書きます。
    public override void Use(Player user)
    {
        Quaternion rotOffset = Quaternion.Euler(
            0.0f,
            0.0f, // horizontal
            -20f // vertical
        );
        //PoisonObjectファイルを読み込みます。しかし今はそんなファイル存在しないのであとで作ります。
        GameObject poisonObject = Resources.Load("Prefabs/PoisonObject") as GameObject;

        //poisonObjectを具現化して、poisonCloneに格納する。第2引数で位置、第3引数で向きを指定する。
        GameObject poisonClone = GameObject.Instantiate(poisonObject,user.transform.position,Quaternion.identity);
        
        //BulletPoisonコンポーネントを取得する。これもあとで作るやつ。
        BulletPoison bulletPoison = poisonClone.GetComponent<BulletPoison>();

        //bulletPoisonにparentを設定する。
        bulletPoison.parent=user;
        
        //Rigidbodyコンポーネントを取得する。
        Rigidbody rb = poisonClone.GetComponent<Rigidbody>();

        Vector3 attackTarget = user.CameraRotationAsQuaternion * rotOffset * new Vector3(-1f, 0f, 0f);
        //poisonCloneにプレイヤーのカメラが向いている方向に力をかける。これで具現化した弾が飛んでいく。
        rb.AddForce(attackTarget*1000f);
    }
}
