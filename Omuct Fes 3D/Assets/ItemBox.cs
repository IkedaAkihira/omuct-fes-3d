using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class ItemBox : MonoBehaviour {
    List<Item>  items=new List<Item>();
    
    void Awake()
    {
        //ここに作成したItemクラスを追加していく。
        //テスト時は不要なものをコメントアウトすると良い。
        items.Add(new ItemPoison());
        items.Add(new ItemShootingBit());
    }
    private void Update() {
        transform.Rotate( 0f, 120.0f * Time.deltaTime ,0f );
    }
    private void OnTriggerEnter(Collider other) {
        Player player=other.GetComponent<Player>();
        if(player==null)
            return;
        if(player.item!=null)
            return;
        
        System.Random random=new System.Random();
        int randomIndex=random.Next(0,items.Count);
        player.item=items[randomIndex];
        Destroy(gameObject);
    }
}