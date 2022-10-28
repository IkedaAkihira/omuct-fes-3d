using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMaster : MonoBehaviour,EventListener
{
    static public GameMaster instance=null;
    public long gameTime;
    [SerializeField] private CameraMover player1Camera;
    [SerializeField] private Slider player1HPSlider;
    [SerializeField] private Image player1ItemImage;
    [SerializeField] private UIPoison player1PoisonUI;
    [SerializeField] private Slider player2HPSlider;
    [SerializeField] private CameraMover player2Camera;
    [SerializeField] private Image player2ItemImage;
    [SerializeField] private UIPoison player2PoisonUI;
    [SerializeField] private string player1JumpButton="Jump";
    [SerializeField] private string player1AttackButton="Attack";
    [SerializeField] private string player1UseItemButton="UseItem";
    [SerializeField] private string player1CameraHorizontalButton="CameraHorizontal";
    [SerializeField] private string player1CameraVerticalButton="CameraVertical";
    [SerializeField] private string player1MoveVerticalButton="Vertical";
    [SerializeField] private string player1MoveHorizontalButton="Horizontal";
    [SerializeField] private string player2JumpButton="OppJump";
    [SerializeField] private string player2AttackButton="OppAttack";
    [SerializeField] private string player2UseItemButton="OppUseItem";
    [SerializeField] private string player2CameraHorizontalButton="OppCameraHorizontal";
    [SerializeField] private string player2CameraVerticalButton="OppCameraVertical";
    [SerializeField] private string player2MoveVerticalButton="OppVertical";
    [SerializeField] private string player2MoveHorizontalButton="OppHorizontal";
    private Player playerL;
    private Player playerR;
    [SerializeField] private string[] characterPaths;
    List<EventListener>listeners=new List<EventListener>();

    public SEPlayer sePlayer;
    private void Awake() {
        GameMaster.instance=this;
        this.playerL=Resources.Load<Player>(this.characterPaths[DataTransfer.player1CharacterNumber]);
        Player pl = Instantiate(playerL.gameObject,new Vector3(0f,10f,10f),Quaternion.identity).GetComponent<Player>();
        pl.SetInputs(player1JumpButton,
            player1AttackButton,
            player1UseItemButton,
            player1CameraHorizontalButton,
            player1CameraVerticalButton,
            player1MoveHorizontalButton,
            player1MoveVerticalButton)
        .SetUI(player1HPSlider,player1ItemImage)
        .SetTPSCamera(player1Camera)
        .MakeAvailable();
        pl.SetPlayerIndex(0);

        this.playerR=Resources.Load<Player>(this.characterPaths[DataTransfer.player2CharacterNumber]);
        Player pr = Instantiate(playerR.gameObject,new Vector3(0f,10f,-10f),Quaternion.identity).GetComponent<Player>();
        pr.SetInputs(player2JumpButton,
            player2AttackButton,
            player2UseItemButton,
            player2CameraHorizontalButton,
            player2CameraVerticalButton,
            player2MoveHorizontalButton,
            player2MoveVerticalButton)
        .SetUI(player2HPSlider,player2ItemImage)
        .SetTPSCamera(player2Camera)
        .MakeAvailable();
        pr.SetPlayerIndex(1);

        this.player1PoisonUI.player=pl;
        this.player2PoisonUI.player=pr;

        listeners.Add(new PoisonListener());
        //listeners.Add(new DamageSEListener(this.sePlayer));

        this.gameTime=0;
    }

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

    public void OnMove(MoveEvent e){
        for(int i=0;i<listeners.Count;i++){
            listeners[i].OnMove(e);
        }
    }

    public void OnJump(JumpEvent e){
        for(int i=0;i<listeners.Count;i++){
            listeners[i].OnJump(e);
        }
    }
}
