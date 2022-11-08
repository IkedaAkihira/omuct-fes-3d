using UnityEngine;

[RequireComponent(typeof(Player))]
public class Attacker : MonoBehaviour {
    [SerializeField,TooltipAttribute("攻撃のクールタイム")] int attackInterval = 200;
    [SerializeField,TooltipAttribute("攻撃中の時間")] int attackingTime = 200;
    [System.NonSerialized] public long lastAttackTime=-1001001001;

    [System.NonSerialized] public Player p;

    private void Awake() {
        this.p = GetComponent<Player>();
    }

    virtual public void Attack(){

    }

    public void DoAttack(){
        Attack();
        lastAttackTime = GameMaster.instance.gameTime;
    }

    public bool IsAttackable{get{return GameMaster.instance.gameTime>=lastAttackTime+attackInterval;}}
    public bool IsAttacking{get{return GameMaster.instance.gameTime<=lastAttackTime+attackingTime;}}

    

}