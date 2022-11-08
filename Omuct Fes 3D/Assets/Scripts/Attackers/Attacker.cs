using UnityEngine;

[RequireComponent(typeof(Player))]
public class Attacker : MonoBehaviour {
    [SerializeField,TooltipAttribute("攻撃のクールタイム")] int attackInterval = 200;
    [SerializeField,TooltipAttribute("攻撃中の時間")] int attackingTime = 200;
    [System.NonSerialized] public long lastAttackTime;

    [System.NonSerialized] public Player p;

    private void Awake() {
        Debug.Log("Awake");
        this.p = GetComponent<Player>();
        this.lastAttackTime = -1001001001;

    }

    virtual public void Attack(){

    }

    public void DoAttack(){
        Attack();
        this.lastAttackTime = GameMaster.instance.gameTime;
        Debug.Log("done");
        Debug.Log(lastAttackTime);
    }

    public bool IsAttackable{get{return GameMaster.instance.gameTime>=lastAttackTime+attackInterval;}}
    public bool IsAttacking{get{return GameMaster.instance.gameTime<=lastAttackTime+attackingTime;}}

    

}