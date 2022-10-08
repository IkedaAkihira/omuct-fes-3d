using UnityEngine;
using System;

public class ItemShootingBit : Item{
    public override void Use(Player user)
    {
        var bitObject=Resources.Load<GameObject>("Prefabs/ShootingBit");
        ShootingBit bit=bitObject.GetComponent<ShootingBit>();
        bit.parent=user;
        GameMaster.instance.PublicInstantiate(bitObject,user.transform.position,Quaternion.identity);
    }
}