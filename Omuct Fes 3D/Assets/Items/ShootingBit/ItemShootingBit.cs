using UnityEngine;
using System;

public class ItemShootingBit : Item{
    public override void Use(Player user)
    {
        GameObject bitObject=Resources.Load<GameObject>("Prefabs/ShootingBit");
        GameObject clone1=GameMaster.instance.PublicInstantiate(bitObject,user.transform.position,Quaternion.identity);
        ShootingBit bit1=clone1.GetComponent<ShootingBit>();
        bit1.parent=user;
        GameObject clone2=GameMaster.instance.PublicInstantiate(bitObject,user.transform.position,Quaternion.identity);
        ShootingBit bit2=clone2.GetComponent<ShootingBit>();
        bit2.parent=user;
        bit2.relativeRotation=-Mathf.PI/2;
    }
}