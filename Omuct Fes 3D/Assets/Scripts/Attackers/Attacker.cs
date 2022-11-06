using UnityEngine;

[RequireComponent(typeof(Player))]
public class Attacker : MonoBehaviour {
    [SerializeField] int attackInterval = 200;
    [SerializeField] int attackingTime = 200;
    [System.NonSerialized] public long lastAttackTime=-1001001001;
    [System.NonSerialized] public bool isAttacking = false;

    virtual public void Attack(Player p){

    }

    public void DoAttack(Player p){
        Attack(p);
        isAttacking = true;
        lastAttackTime = GameMaster.instance.gameTime;
    }

    public bool IsAttackable{get{return GameMaster.instance.gameTime>=lastAttackTime+attackInterval;}}
    public bool IsAttacking{get{return GameMaster.instance.gameTime>=lastAttackTime+attackingTime;}}

    

}