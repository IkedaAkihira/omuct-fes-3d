using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

abstract public class Player : MonoBehaviour
{
    //コントローラ関係
    protected bool isPlayerAvailable = false;
    private string jumpButton="Jump";
    private string attackButton="Attack";
    private string useItemButton="UseItem";
    private string cameraHorizontalButton="CameraHorizontal";
    private string cameraVerticalButton="CameraVertical";
    private string moveVerticalButton="Vertical";
    private string moveHorizontalButton="Horizontal";

    //UI
    private Slider hpSlider;
    public Image itemImage;

    //ステータスなど
    public int maxHp=20;
    public Item item;
    public Dictionary<int,Effect>effects=new Dictionary<int, Effect>();
    public float playerSpeed = 2.0f;
    public float gravityValue = -9.81f;
    public float jumpForce = 1.0f;

    //カメラ周り
    public float cameraRotation{get;set;}
    public float cameraRotationY{get;set;}
    public Vector3 cameraVec2{get;set;}
    public Vector3 cameraVec3{get;set;}
    public Vector3 toTargetVec{get;set;}
    public Vector3 cameraPos{get;set;}

    //操作関係
    public float cameraRotationVelocity=1f;
    public float cameraRotationVelocityAssisted=0.1f;
    public float cameraRotationYVelocity=1f;
    public float cameraRotationYVelocityAssisted=0.1f;
    public float horizontal=1f;
    public float vertical=1f;
    public float th=0.2f;
    public float verticalCameraLimit = Mathf.PI/6.0f;
    //カメラの距離
    public float cameraDistance = 10.0f;

    //外部から触れないやつ
    //hp自体を触ることはできない(攻撃なら攻撃として情報を受け取りたいため)
    protected int hp;
    //カメラの位置などを管理するやつ
    private CameraMover cameraMover;
    //移動用コンポーネント
    private CharacterController controller;
    //重力系
    private Vector3 playerVelocity;
    //着地判定用
    private bool groundedPlayer;

    //移動方向を格納
    private Vector3 move;
    private Animator animator;

    
    public int attackInterval=200;
    private long lastAttackTime=0;

    protected bool isAttacking = false;

    protected bool isFocusTarget = false;

    private bool isAvailable = false;
    private Texture2D noItemTexture;
    private void Awake()
    {
        noItemTexture= Resources.Load<Texture2D>("Textures/null");
        cameraRotation = 0f;
        cameraRotationY = 0f;
        hp=maxHp;
        item=null;
        controller = this.GetComponent<CharacterController>();
        animator=GetComponent<Animator>();
        move=new Vector3(0,0,0);
        cameraVec2=new Vector3(0,0,0);
        cameraVec3=new Vector3(0,0,0);
        toTargetVec=new Vector3(0,0,0);
    }


    //操作関係はUpdateで処理してる
    private void Update()
    {
        if(!isAvailable)
            return;
        Debug.Log("aaa");
        if(IsAttackable)
            animator.SetTrigger("return");
        
        //camera rotation
        cameraRotation+=Th(Input.GetAxis(cameraHorizontalButton),th)*0.005f*((isFocusTarget)?cameraRotationVelocityAssisted:cameraRotationVelocity);
        cameraRotationY=Mathf.Min(Mathf.Max(-verticalCameraLimit,cameraRotationY+
        Th(Input.GetAxis(cameraVerticalButton),th)
        *0.01f*((isFocusTarget)?cameraRotationYVelocityAssisted:cameraRotationYVelocity)),verticalCameraLimit);

        //move
        move = cameraVec2*Input.GetAxis(moveVerticalButton)*horizontal
        +new Vector3(
            -Mathf.Sin(cameraRotation),
            0,
            Mathf.Cos(cameraRotation)
            )*Input.GetAxis(moveHorizontalButton)*vertical;
        if(move.magnitude>1.0f)
            move=move.normalized;
        move = move*move.magnitude;
        if (move != Vector3.zero && !isAttacking)
        {
            gameObject.transform.forward = move;
        }

        //jump
        if (Input.GetButtonDown(jumpButton) && groundedPlayer)
        {
            JumpEvent e = new JumpEvent(this,this.jumpForce);
            GameMaster.instance.OnJump(e);
            if(e.isAvailable)
                playerVelocity.y += e.JumpForce;
        }
        
        //attack
        if(Input.GetButtonDown(attackButton)&&IsAttackable){
            animator.SetTrigger("attack");
            gameObject.transform.forward = cameraVec2;
            AttackEvent e=new AttackEvent(this);
            GameMaster.instance.OnAttack(e);
            if(e.isAvailable){
                Attack();
                isAttacking = true;
                lastAttackTime=GameMaster.instance.gameTime;
            }
        }

        //use item
        if(Input.GetButtonDown(useItemButton)){
            if(item!=null){
                item.Use(this);
                item=null;
                this.itemImage.sprite = Sprite.Create(this.noItemTexture, new Rect(0,0,this.noItemTexture.width,this.noItemTexture.height), Vector2.zero);
            }
        }

        //update ui
        hpSlider.value=(float)hp/(float)maxHp;
    }

    //内部の処理はコンスタントに行いたいので、ほぼ確実に毎秒50回実行してくれるFixedUpdateで行う。
    private void FixedUpdate() {
        if(!isAvailable)
            return;
        if(IsAttackable)
            isAttacking = false;

        //プレイヤーにかかったエフェクトの処理
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

        //死んだとき
        if(hp<=0){
            transform.position=new Vector3(0,10,0);
            playerVelocity=new Vector3(0,0,0);
            effects.Clear();
            hp=maxHp;
            return;
        }

        //カメラの位置更新
        cameraVec2=new Vector3(
            -Mathf.Cos(cameraRotation),
            0,
            -Mathf.Sin(cameraRotation)
            );
        cameraVec3=-(new Vector3(0,Mathf.Sin(cameraRotationY),0))+cameraVec2*Mathf.Cos(cameraRotationY);
        cameraPos=this.transform.position
        +(-new Vector3(0,Mathf.Sin(cameraRotationY-Mathf.PI/2),0)+cameraVec2*Mathf.Cos(cameraRotationY-Mathf.PI/2))*2;
        //+new Vector3(Mathf.Cos(cameraRotation+Mathf.PI/2),0,Mathf.Sin(cameraRotation+Mathf.PI/2));
        cameraMover.MoveCamera(cameraPos,cameraVec3,cameraDistance);

        //プレイヤーからターゲットに向かう正規化されたベクトルを更新
        RaycastHit hit;
        Player targetedPlayer = null;
        if(Physics.Raycast(cameraPos,cameraVec3,out hit,Mathf.Infinity,1<<3|1<<6)){
            targetedPlayer = hit.collider.GetComponent<Player>();
            if(targetedPlayer!=this)
                toTargetVec=(hit.point-transform.position).normalized;
            else
                toTargetVec=cameraVec3.normalized;
        }else{
            toTargetVec=cameraVec3.normalized;
        }
        if(targetedPlayer!=null&&targetedPlayer!=this){
            isFocusTarget = true;
        }else{
            isFocusTarget = false;
        }
        
        //g重力の処理
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && (playerVelocity.y < 0))
        {
            playerVelocity.y = 0f;
        }
        playerVelocity.y += gravityValue * Time.deltaTime;

        //移動の処理
        MoveEvent moveEvent = new MoveEvent(this,this.playerSpeed);
        GameMaster.instance.OnMove(moveEvent);
        if(moveEvent.isAvailable)
            controller.Move((move*moveEvent.Speed+playerVelocity) * Time.deltaTime);
    }

    public int Hp{
        get {return hp;}
    }
    
    abstract protected void Attack();
    public void Damage(DamageSource damageSource){
        Debug.Log("Damaged");
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

    private float Th(float val,float th){
        return (Mathf.Abs(val)<th)?0:val;
    }

    public Player SetInputs(
        string jumpButton,
        string attackButton,
        string useItemButton,
        string cameraHorizontalButton,
        string cameraVerticalButton,
        string moveHorizontalButton,
        string moveVerticalButton
    ){
        this.jumpButton=jumpButton;
        this.attackButton=attackButton;
        this.useItemButton=useItemButton;
        this.cameraHorizontalButton=cameraHorizontalButton;
        this.cameraVerticalButton=cameraVerticalButton;
        this.moveHorizontalButton=moveHorizontalButton;
        this.moveVerticalButton=moveVerticalButton;
        return this;
    }

    public Player SetUI(Slider hpSlider,Image itemImage){
        this.hpSlider=hpSlider;
        this.itemImage=itemImage;
        return this;
    }

    public Player SetTPSCamera(CameraMover cameraMover){
        this.cameraMover=cameraMover;
        return this;
    }

    public void MakeAvailable(){
        this.isAvailable = true;
        this.itemImage.sprite = Sprite.Create(this.noItemTexture, new Rect(0,0,this.noItemTexture.width,this.noItemTexture.height), Vector2.zero);
    }
    public bool IsAttackable{get{return GameMaster.instance.gameTime>=lastAttackTime+attackInterval;}}
}
