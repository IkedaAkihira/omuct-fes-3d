using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Player : MonoBehaviour
{
    public int id;
    protected int hp;
    public Item item;
    public Dictionary<int,Effect>effects=new Dictionary<int, Effect>();
    

    
    public float playerSpeed = 2.0f;
    public float gravityValue = -9.81f;
    public float jumpForce = 1.0f;



    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float cameraRotation = 0f;
    private float cameraRotationY = 0f;
    private Vector3 move;
    public Vector3 cameraVec2;
    public Vector3 cameraVec3;
    public Vector3 cameraPos;

    public GameObject tpsCamera;
    CameraMover cameraMover;
    public float cameraDistance = 10.0f;
    private void Start()
    {
        controller = this.GetComponent<CharacterController>();
        cameraMover=tpsCamera.GetComponent<CameraMover>();
        move=new Vector3(0,0,0);
        cameraVec2=new Vector3(0,0,0);
        cameraVec3=new Vector3(0,0,0);
    }

    void Update()
    {
        //camera rotation
        cameraRotation=-Input.mousePosition.x*0.005f;
        cameraRotationY=Mathf.Min(Mathf.Max(-1.0f,(-Input.mousePosition.y)*0.01f),1.0f);

        //move
        move = cameraVec2*Input.GetAxis("Vertical")
        +new Vector3(
            -Mathf.Sin(cameraRotation),
            0,
            Mathf.Cos(cameraRotation)
            )*Input.GetAxis("Horizontal");
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        //jump
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += jumpForce;
        }
        
        //attack
        if(Input.GetKey(KeyCode.E)){
            AttackEvent e=new AttackEvent(this);
            GameMaster.instance.OnAttack(e);
            if(e.isAvailable){
                Attack();
            }
        }

        //use item
        if(Input.GetKey(KeyCode.Q)){
            if(item!=null){
                item.Use(this);
                item=null;
            }
        }
    }

    private void FixedUpdate() {
        //update camera
        cameraVec2=new Vector3(
            -Mathf.Cos(cameraRotation),
            0,
            -Mathf.Sin(cameraRotation)
            );
        cameraVec3=-(new Vector3(0,Mathf.Sin(cameraRotationY),0))+cameraVec2*Mathf.Cos(cameraRotationY);
        cameraPos=this.transform.position
        -(new Vector3(0,Mathf.Sin(cameraRotationY-Mathf.PI/2),0))+cameraVec2*Mathf.Cos(cameraRotationY-Mathf.PI/2);
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
}
