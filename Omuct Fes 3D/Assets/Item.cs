using UnityEngine;

abstract public class Item{
    public Sprite itemSprite;
    abstract public void Use(Player user);
}
