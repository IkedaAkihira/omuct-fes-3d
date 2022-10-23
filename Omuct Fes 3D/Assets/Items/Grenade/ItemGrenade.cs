//呪文
using UnityEngine;
using System;


public class ItemGrenade : Item
{
    GameObject grenadeObject;
    public ItemGrenade(){
        this.itemImage=Resources.Load<Texture2D>("Textures/poison_effect");
        this.grenadeObject = Resources.Load("Prefabs/Grenade") as GameObject;
    }
    //この関数の中にアイテムを使った時の処理を書きます。
    public override void Use(Player user)
    {
        GameObject grenadeClone = GameObject.Instantiate(grenadeObject,user.transform.position,Quaternion.identity);
        
        BulletGrenade bulletGrenade = grenadeClone.GetComponent<BulletGrenade>();

        bulletGrenade.parent=user;
        
        //Rigidbodyコンポーネントを取得する。
        Rigidbody rb = grenadeClone.GetComponent<Rigidbody>();

        rb.AddForce(user.toTargetVec*1000f);
    }
}