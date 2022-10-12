やあみんな!!池田明平だ!!今日は僕が、アイテムを追加する方法を、説明していくね!!

まず、Omuct Fes 3D/Assets/Items下に追加したいアイテムのファイルを作成します。
毒アイテムならItemPoison.cs、爆弾ならItemBomb.csとでもすればいいんじゃないすか。ここでは、毒アイテムを作成していきます。

ItemPoisonファイルに以下のように書き込みます。
```ItemPoison.cs:cs
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

        GameObject.Instantiate(poisonObject,user.transform.position,Quaternion.identity);
        
                
    }
}
```