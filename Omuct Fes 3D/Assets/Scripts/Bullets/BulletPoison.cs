//呪文
using UnityEngine;
using System;


public class BulletPoison : MonoBehaviour
{
    [SerializeField] private GameObject explosion;


    override protected void HitObject(){
        
        //割れる音
        GameMaster.instance.sePlayer.Play("poison explode");

        //弾丸自身を消す。
        Instantiate(this.explosion,this.transform.position,Quaternion.identity);
    }
}