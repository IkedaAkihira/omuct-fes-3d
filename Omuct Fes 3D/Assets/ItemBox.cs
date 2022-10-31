using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ItemBox : MonoBehaviour{
    List<Item> items = new List<Item>();
    List<double> itemsOccurence = new List<double>();

    bool isOpened = false;

    Animator animator;

    public int interval = 1500;

    private long lastOpenedTime = 0;
    
    void Awake(){
        animator = transform.GetChild(0).GetComponent<Animator>();
        //ここに作成したItemクラスを追加していく。
        //テスト時は不要なものをコメントアウトすると良い。
        items.Add(new ItemPoison());
        itemsOccurence.Add(1.0);
        items.Add(new ItemShootingBit());
        itemsOccurence.Add(1.0);
        items.Add(new ItemGrenade());
        itemsOccurence.Add(1.0);
        items.Add(new ItemTokeito());
        itemsOccurence.Add(1.0);
    }

    private int ChooseItem()
    {
        UnityEngine.Assertions.Assert.AreEqual(items.Count, itemsOccurence.Count);
        int num = itemsOccurence.Count;
        double weightSum = 0.0;
        for (int i = 0; i < num; i++) weightSum += itemsOccurence[i];

        System.Random random = new System.Random();
        double p = random.NextDouble() * weightSum;

        int res = 0;
        double weightPartSum = 0.0;
        for( ; res < num - 1; res++){
            weightPartSum += itemsOccurence[res];
            if (p < weightPartSum) break;
        }
        return res;
    }

    private void OnTriggerEnter(Collider other){
        if (isOpened)
            return;
        Player player = other.GetComponent<Player>();
        if (player == null)
            return;
        if (player.item != null)
            return;

        isOpened = true;
        lastOpenedTime = GameMaster.instance.gameTime;
        animator.SetTrigger("open");

        int randomIndex = ChooseItem();
        player.item = items[randomIndex];
        player.itemImage.sprite = items[randomIndex].itemSprite;
    }

    private void FixedUpdate(){
        if (isOpened && (lastOpenedTime + interval <= GameMaster.instance.gameTime)){
            isOpened = false;
            animator.SetTrigger("close");
        }
    }
}
