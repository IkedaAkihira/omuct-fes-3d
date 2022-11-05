using UnityEngine;

public class Bullet : MonoBehaviour {
    public Player parent;
    [SerializeField] protected int lifeTime = 100;
    protected long startTime;
    protected Rigidbody rb;

    private void Start() {
        this.rb=this.GetComponent<Rigidbody>();
        this.startTime=GameMaster.instance.gameTime;
    }

    private void FixedUpdate() {
        long life = GameMaster.instance.gameTime-startTime;
        if(life>lifeTime)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.isTrigger)
            return;
        Player p=other.GetComponent<Player>();
        if(p==this.parent)
            return;
        
        HitObject();
        

        if(p!=null){
            HitPlayer(p);
            parent.AddHitCount();
        }
        
        Destroy(this.gameObject);

    }

    virtual protected void HitPlayer(Player p){

    }

    virtual protected void HitObject(){

    }
}