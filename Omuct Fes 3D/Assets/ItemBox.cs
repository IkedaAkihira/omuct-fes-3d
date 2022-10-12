using UnityEngine;
using System;

public class ItemBox : MonoBehaviour {
    List<Item>items=new List<Item>();

    void Start()
    {
        //ここに作成したItemクラスを追加していく。
        //テスト時は不要なものをコメントアウトすると良い。
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
        
        Random random=new Random();
        player.item=items[random.Next(0,items.Count)];
        Destroy(gameObject);
    }
}