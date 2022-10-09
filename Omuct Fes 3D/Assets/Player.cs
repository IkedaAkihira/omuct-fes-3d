using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Player : MonoBehaviour
{
    public string jumpButton="Jump";
    public string attackButton="Attack";
    public string useItemButton="UseItem";
    public string cameraHorizontalButton="cameraHorizontal";
    public string cameraVerticalButton="cameraVertical";
    public string moveVerticalButton="Vertical";
    public string moveHorizontalButton="Horizontal";


    public int id;
    protected int hp=20;
    public Item item;
    public Dictionary<int,Effect>effects=new Dictionary<int, Effect>();
    

    
    public float playerSpeed = 2.0f;
    public float gravityValue = -9.81f;
    public float jumpForce = 1.0f;



    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float cameraRotation = 0f;
    public float cameraRotationY = 0f;
    private Vector3 move;
    public Vector3 cameraVec2;
    public Vector3 cameraVec3;
    public Vector3 cameraPos;

    public GameObject tpsCamera;
    CameraMover cameraMover;
    public float cameraDistance = 10.0f;
    private void Start()
    {
        item=new ItemShootingBit();
        controller = this.GetComponent<CharacterController>();
        cameraMover=tpsCamera.GetComponent<CameraMover>();
        move=new Vector3(0,0,0);
        cameraVec2=new Vector3(0,0,0);
        cameraVec3=new Vector3(0,0,0);
    }

    void Update()
    {
        //camera rotation
        cameraRotation+=Input.GetAxis(cameraHorizontalButton)*0.005f;
        cameraRotationY=Mathf.Min(Mathf.Max(-1.0f,cameraRotationY+Input.GetAxis(cameraVerticalButton)*0.01f),1.0f);

        //move
        move = cameraVec2*Input.GetAxis(moveVerticalButton)
        +new Vector3(
            -Mathf.Sin(cameraRotation),
            0,
            Mathf.Cos(cameraRotation)
            )*Input.GetAxis(moveHorizontalButton);
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        //jump
        if (Input.GetButtonDown(jumpButton) && groundedPlayer)
        {
            playerVelocity.y += jumpForce;
        }
        
        //attack
        if(Input.GetButtonDown(attackButton)){
            AttackEvent e=new AttackEvent(this);
            GameMaster.instance.OnAttack(e);
            if(e.isAvailable){
                Attack();
            }
        }

        //use item
        if(Input.GetButtonDown(useItemButton)){
            if(item!=null){
                item.Use(this);
                item=null;
            }
        }
    }

    private void FixedUpdate() {
        Debug.Log(this.hp);
        //efect
        List<int>removeEffectTypes=new List<int>();
        foreach(Effect e in effects.Values){
            e.Tick(this);
            e.time--;
            if(e.time<=0){
                removeEffectTypes.Add(e.type);
            }
        }
        foreach(int type in removeEffectTypes){
            effects.Remove(type);
        }

        //hp
        if(hp<=0){
            transform.position=new Vector3(0,10,0);
            playerVelocity=new Vector3(0,0,0);
            hp=20;
            return;
        }

        //update camera
        cameraVec2=new Vector3(
            -Mathf.Cos(cameraRotation),
            0,
            -Mathf.Sin(cameraRotation)
            );
        cameraVec3=-(new Vector3(0,Mathf.Sin(cameraRotationY),0))+cameraVec2*Mathf.Cos(cameraRotationY);
        cameraPos=this.transform.position
        -(new Vector3(0,Mathf.Sin(cameraRotationY-Mathf.PI/2),0))+cameraVec2*Mathf.Cos(cameraRotationY-Mathf.PI/2)
        +new Vector3(Mathf.Cos(cameraRotation+Mathf.PI/2),0,Mathf.Sin(cameraRotation+Mathf.PI/2));
        cameraMover.MoveCamera(cameraPos,cameraVec3,cameraDistance);
        
        //gravity
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && (playerVelocity.y < 0))
        {
            playerVelocity.y = 0f;
        }
        playerVelocity.y += gravityValue * Time.deltaTime;

        //move
        controller.Move((move*playerSpeed+playerVelocity) * Time.deltaTime);
    }
    
    abstract protected void Attack();
    public void Damage(DamageSource damageSource){
        DamageEvent e=new DamageEvent(this,damageSource);
        GameMaster.instance.OnDamaged(e);
        if(e.isAvailable)
            this.hp-=damageSource.amount;
    }

    public void AddEffect(Effect e){
        //エフェクトが存在しないなら追加し、あれば、エフェクトの持続時間を長いほうにする。
        if(!effects.ContainsKey(e.type)){
            effects.Add(e.type,e);
        }else{
            Effect pastEffect=effects.GetValueOrDefault(e.type);
            pastEffect.time=Mathf.Max(pastEffect.time,e.time);
        }
    }
}
