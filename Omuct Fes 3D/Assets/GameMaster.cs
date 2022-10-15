using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour,EventListener
{
    static public GameMaster instance=null;
    public long gameTime;

    Vector3[] itemBoxPositions={
        new Vector3(0f,0.5f,0f),
        new Vector3(-10f,6.5f,10f)
    };
    private void Awake() {
        this.gameTime=0;
        if(instance==null)
            instance=this;
        else
            Destroy(this.gameObject);
    }
    Player playerL;
    Player playerR;

    List<EventListener>listeners=new List<EventListener>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate() {
        this.gameTime++;
        if(gameTime%500==0){
            GameObject itemBox=Resources.Load<GameObject>("Prefabs/ItemBox");
            Instantiate(itemBox,itemBoxPositions[(new System.Random()).Next(0,2)],Quaternion.identity);
        }
    }

    public void OnAttack(AttackEvent e){
        for(int i=0;i<listeners.Count;i++){
            listeners[i].OnAttack(e);
        }
    }

    public void OnDamaged(DamageEvent e){
        for(int i=0;i<listeners.Count;i++){
            listeners[i].OnDamaged(e);
        }
    }

    public void OnUseItem(UseItemEvent e){
        for(int i=0;i<listeners.Count;i++){
            listeners[i].OnUseItem(e);
        }
    }

    public GameObject PublicInstantiate(GameObject obj,Vector3 pos,Quaternion rot){
        return Instantiate(obj,pos,rot);
    }
}
