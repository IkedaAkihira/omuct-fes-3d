//呪文
using UnityEngine;
using System;


public class BulletPoison : MonoBehaviour
{
    //外部からparentを設定したいので、publicにする。
    public Player parent;

    //何かにあたったときの処理を行う。
    private void OnTriggerEnter(Collider other)
    {
        //相手がトリガーなら処理を終わる。
        //トリガーは、衝突判定がないが、あたったことを検知できるやつ。
        if(other.isTrigger)
            return;

        //あたったやつからPlayerを取得する。
        Player player = other.GetComponent<Player>();
        
        //playerがparent、つまり弾丸を出した人だったら処理を終わる。
        if(player==this.parent)
            return;
        
        //弾丸自身を消す。
        Destroy(this.gameObject);

        //playerがnullではない、つまり、あたった対象がplayerであれば、毒を与える。
        if(player!=null)
        {
            //AddEffectで状態異常などを与える。EffectPoisonも後で作ろうね。
            //EffectPoisonの引数はゲーム内時間(1秒で50進む)で効果時間を指定している。これは10秒。
            player.AddEffect(new EffectPoison(500));
        }
    }
}