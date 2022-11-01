using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

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
    private Player playerL;
    private Player playerR;
    private Player pl;
    private Player pr;
    [SerializeField] private string[] characterPaths;
    List<EventListener>listeners=new List<EventListener>();

    public SEPlayer sePlayer;

    [SerializeField] Vector3 spawnPlayer1;
    [SerializeField] Vector3 spawnPlayer2;
    private void Awake() {
        GameMaster.instance=this;
        this.playerL=Resources.Load<Player>(this.characterPaths[DataTransfer.player1CharacterNumber]);
        this.pl = Instantiate(playerL.gameObject,spawnPlayer1,Quaternion.identity).GetComponent<Player>();
        this.pl
        .SetUI(player1HPSlider,player1ItemImage)
        .SetTPSCamera(player1Camera)
        .SetIsLeftPlayer(true)
        .MakeAvailable();
        this.pl.SetPlayerIndex(0);

        this.playerR=Resources.Load<Player>(this.characterPaths[DataTransfer.player2CharacterNumber]);
        this.pr = Instantiate(playerR.gameObject,spawnPlayer2,Quaternion.identity).GetComponent<Player>();
        this.pr
        .SetUI(player2HPSlider,player2ItemImage)
        .SetTPSCamera(player2Camera)
        .SetIsLeftPlayer(false)
        .MakeAvailable();
        this.pr.SetPlayerIndex(1);

        this.player1PoisonUI.player=pl;
        this.player2PoisonUI.player=pr;

        listeners.Add(new PoisonListener());
        listeners.Add(new ChinanagoListener());

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

    public Player GetPlayer(bool isLeftPlayer){
        return isLeftPlayer?pl:pr;
    }

    public void Finish(){
        DataTransfer.player1ResultData=pl.GetResultData();
        DataTransfer.player2ResultData=pr.GetResultData();
        SceneManager.LoadScene("ResultScene");
    }
}
