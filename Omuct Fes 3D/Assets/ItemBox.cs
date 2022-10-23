using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ItemBox : MonoBehaviour {
    List<Item>  items=new List<Item>();

    bool isOpened = false;

    Animator animator;

    public int interval = 1500;

    private long lastOpenedTime = 0;
    
    void Awake()
    {
        animator = transform.GetChild(0).GetComponent<Animator>();
        //ここに作成したItemクラスを追加していく。
        //テスト時は不要なものをコメントアウトすると良い。
        items.Add(new ItemPoison());
        items.Add(new ItemShootingBit());
        items.Add(new ItemGrenade());
    }
    private void OnTriggerEnter(Collider other) {
        if(isOpened)
            return;
        Player player=other.GetComponent<Player>();
        if(player==null)
            return;
        if(player.item!=null)
            return;
        
        isOpened = true;
        lastOpenedTime = GameMaster.instance.gameTime;
        animator.SetTrigger("open");

        System.Random random=new System.Random();
        int randomIndex=random.Next(0,items.Count);
        player.item=items[randomIndex];
        player.itemImage.sprite = Sprite.Create(items[randomIndex].itemImage, new Rect(0,0,items[randomIndex].itemImage.width,items[randomIndex].itemImage.height), Vector2.zero);
    }

    private void FixedUpdate() {
        if(isOpened&&(lastOpenedTime+interval<=GameMaster.instance.gameTime)){
            isOpened = false;
            animator.SetTrigger("close");
        }
    }
}