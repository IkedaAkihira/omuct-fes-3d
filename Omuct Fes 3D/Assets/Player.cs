using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int id;
    protected int hp;
    public Item item;
    public GameMaster gm;
    public Dictionary<int,Effect>effects=new Dictionary<int, Effect>();
    protected void Attack(){
        AttackEvent e=new AttackEvent(this);
        gm.OnAttack(e);
    }
    public void Damage(DamageSource damageSource){
        DamageEvent e=new DamageEvent(this,damageSource);
        gm.OnDamaged(e);
        if(e.isAvailable)
            this.hp-=damageSource.amount;
    }

    
    public float playerSpeed = 2.0f;
    public float gravityValue = -9.81f;
    public float jumpForce = 1.0f;



    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float cameraRotation = 0f;
    private float cameraRotationY = 0f;

    public GameObject camera;
    public float cameraDistance = 10.0f;
    private void Start()
    {
        controller = this.GetComponent<CharacterController>();
    }

    void Update()
    {
        //camera
        cameraRotation=-Input.mousePosition.x*0.005f;

        cameraRotationY=Mathf.Min(Mathf.Max(-1.0f,(-Input.mousePosition.y)*0.01f),1.0f);

        Vector3 cameraVec2=new Vector3(
            Mathf.Cos(cameraRotation),
            0,
            Mathf.Sin(cameraRotation)
            );

        Vector3 cameraVec3=new Vector3(0,Mathf.Sin(cameraRotationY),0)+cameraVec2*Mathf.Cos(cameraRotationY);

        RaycastHit hit;

        if(Physics.Raycast(transform.position,cameraVec3,out hit,cameraDistance)){
            camera.transform.position=this.transform.position+cameraVec3*hit.distance;
        }else{
            camera.transform.position=this.transform.position+cameraVec3*cameraDistance;
        }

        camera.transform.LookAt(this.transform.position);


        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && (playerVelocity.y < 0))
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = -cameraVec2*Input.GetAxis("Vertical")
        +new Vector3(
            -Mathf.Sin(cameraRotation),
            0,
            Mathf.Cos(cameraRotation)
            )*Input.GetAxis("Horizontal");
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += jumpForce;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move((move*playerSpeed+playerVelocity) * Time.deltaTime);
    }
}
