//呪文
using UnityEngine;
using System;


public class ItemRiver : Item
{
    public ItemRiver(){
        this.itemSprite = Resources.Load<Sprite>("Textures/River");
    }
    //この関数の中にアイテムを使った時の処理を書きます。
    public override void Use(Player user)
    {
        user.Damage(new DamageSource(-2));
        user.AddEffect(new EffectRiver(500));
    }
}
