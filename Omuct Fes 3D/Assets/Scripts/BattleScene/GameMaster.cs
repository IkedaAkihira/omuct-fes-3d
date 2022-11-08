using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    static public GameMaster instance=null;
    public long gameTime;
    public long gameTimeOffset = -220;
    [SerializeField] private CameraMover player1Camera;
    [SerializeField] private Slider player1HPSlider;
    [SerializeField] private Image player1ItemImage;
    [SerializeField] private UIEffect[] player1UIEffects;
    [SerializeField] private Slider player2HPSlider;
    [SerializeField] private CameraMover player2Camera;
    [SerializeField] private Image player2ItemImage;
    [SerializeField] private UIEffect[] player2UIEffects;
    [SerializeField] private float player1CameraRotation = Mathf.PI/2;
    [SerializeField] private float player2CameraRotation = -Mathf.PI/2;
    [SerializeField] private float resultDelay = 2f;
    private Player playerL;
    private Player playerR;
    private Player pl;
    private Player pr;
    [SerializeField] private Player[] characters;

    List<EventListener>listeners;
    public MasterListener listener;
    

    private BattleTimer battleTimer;

    public SEPlayer sePlayer;
    
    private bool isFinished;
    private bool isStarted;

    [SerializeField] Vector3 spawnPlayer1 = new Vector3(-100.0f, 10.0f, 0.0f);
    [SerializeField] Vector3 spawnPlayer2 = new Vector3(100.0f, 10.0f, 0.0f);
    private void Awake() {
        GameMaster.instance=this;
        this.playerL=characters[DataTransfer.player1CharacterNumber];
        this.pl = Instantiate(playerL.gameObject,spawnPlayer1,Quaternion.identity).GetComponent<Player>();
        this.pl
        .SetUI(player1HPSlider,player1ItemImage)
        .SetTPSCamera(player1Camera)
        .SetIsLeftPlayer(true)
        .MakeAvailable();
        this.pl.SetPlayerIndex(0);
        this.pl.cameraRotation = this.player1CameraRotation;

        this.playerR=characters[DataTransfer.player2CharacterNumber];
        this.pr = Instantiate(playerR.gameObject,spawnPlayer2,Quaternion.identity).GetComponent<Player>();
        this.pr
        .SetUI(player2HPSlider,player2ItemImage)
        .SetTPSCamera(player2Camera)
        .SetIsLeftPlayer(false)
        .MakeAvailable();
        this.pr.SetPlayerIndex(1);
        this.pr.cameraRotation = this.player2CameraRotation;

        foreach(UIEffect uiEffect in player1UIEffects){
            uiEffect.player = this.pl;
        }

        foreach(UIEffect uiEffect in player2UIEffects){
            uiEffect.player = this.pr;
        }

        listeners = new List<EventListener>();

        listeners.Add(new PoisonListener());
        listeners.Add(new ChinanagoListener());
        listeners.Add(new DamageSEListener(this.sePlayer));
        listeners.Add(new RiverListener());

        this.gameTime = gameTimeOffset;

        battleTimer = new BattleTimer();
        
        this.isFinished = false;
        this.isFinished = false;

        this.listener = new MasterListener(ref listeners);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        pl.doStopPlayerControl = 0 <= gameTime;
        pr.doStopPlayerControl = 0 <= gameTime;

        battleTimer.Update(gameTime);

        if(!isStarted && gameTime>=0)
        {
            this.sePlayer.Play("start");
            this.isStarted = true;
        }
    }

    private void FixedUpdate() {
        this.gameTime++;
    }


    public Player GetPlayer(bool isLeftPlayer){
        return isLeftPlayer?pl:pr;
    }

    public void Finish(){
        if(this.isFinished)
            return;
        this.isFinished = true;
        DataTransfer.player1ResultData=pl.GetResultData();
        DataTransfer.player2ResultData=pr.GetResultData();
        Invoke("Result",resultDelay);
        GameMaster.instance.sePlayer.Play("finish");
    }
    
    void Result(){
        SceneManager.LoadScene("ResultScene");
    }
}
