//呪文
using UnityEngine;
using System;


public class BulletGrenade : Bullet
{
    //外部からparentを設定したいので、publicにする。

    [SerializeField] private GameObject explosion;

    override protected void HitObject(){
        Instantiate(this.explosion,this.transform.position,Quaternion.identity);
        GameMaster.instance.sePlayer.Play("bomb");
    }
    
}