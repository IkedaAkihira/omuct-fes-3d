やあみんな!!池田明平だ!!今日は僕が、アイテムを追加する方法を、説明していくね!!
# アイテムの作成
まず、Omuct Fes 3D/Assets/Items下に追加したいアイテムのファイルを作成します。
毒アイテムならItemPoison.cs、爆弾ならItemBomb.csとでもすればいいんじゃないすか。ここでは、毒アイテムを作成していきます。

ItemPoisonファイルに以下のように書き込みます。
```c#:ItemPoison.cs
//呪文
using UnityEngine;
using System;


public class ItemPoison : Item
{
    //この関数の中にアイテムを使った時の処理を書きます。
    public override void Use(Player user)
    {
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

        //poisonCloneにプレイヤーのカメラが向いている方向に力をかける。これで具現化した弾が飛んでいく。
        rb.AddForce(user.toTargetVec*1000f);
    }
}
```
次に、BulletPoison.csファイルを作成します。
```c#:BulletPoison.cs
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
```

毒エフェクト作ろうね。
```c#:EffectPoison.cs
public class EffectPoison : Effect{
    //あとで調整できるように、ダメージを受ける間隔と毎回のダメージを指定している。今回は1damage/sec * 10sec = 10damage
    int interval=50;
    int damage=1;

    //コンストラクタ　new EffectPoison(...)をやったときの処理を書いてある。
    public EffectPoison(int time)
    {
        this.time=time;
        this.interval=interval;
        this.damage=damage;
    }

    //毎秒50回呼ばれる。
    override public void Tick(Player player)
    {
        //ゲーム内時間をintervalで割ったあまりが0の時、つまり、interval回ごとにプレイヤーにダメージを与える。
        if(GameMaster.instance.gameTime%interval==0)
        {
            //player.Damage(damageSource)でプレイヤーにダメージを与えられる。
            //damageSourceはダメージの情報を保持してる。
            player.Damage(new DamageSource(damage));
        }
    }
}
```

次に、放置してたPoisonObjectを作ろう。Unity側で作業するよ。
![screenshot](https://user-images.githubusercontent.com/91947939/195354373-4f32d62d-1692-4cfb-8bdf-741afb82a492.png)

Unityで①上に任意のゲームオブジェクトを作成します。モデルとかないなら、とりあえずSphereとかでいいと思います。
次に、②でResources/Prefabsフォルダを開きます。ここに、さっき作ったオブジェクトをドラッグ&ドロップします。  
①上のオブジェクトは~~用済みなので~~削除します。
②にあるオブジェクトの名前をPoisonObjectに変更します。
PoisonObjectを開いて、③の下のほうにあるAdd ComponentからRigidbodyとBulletPoisonを追加します。  
次に、③から なんたら Colliderと書いてあるものを探し、中のIs Triggerにチェックを入れます。
また、③のRigidbodyからUse Gravityのチェックを外し、弾がまっすぐ飛ぶようにします。

これで、アイテム自体の作成は終わりです。
# アイテムの追加
アイテムを作っても、追加しないとゲーム内では使えません。

ItemBox.csを**開いて**、以下のように追記します。

```C#:ItemBox.cs
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ItemBox : MonoBehaviour {
    //省略...
    void Start()
    {
        //この行を追記する。他のitems.Addをコメントアウトすると、アイテムがPoisonのみになる。テストする際などはそれでやればよい。
        items.Add(new ItemPoison());
    }
    //省略...
}
```

これでいい。
一回Unityで実行->アイテムを取得->使うところまでやってみるとよい。
