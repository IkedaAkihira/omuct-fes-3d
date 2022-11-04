using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour {
    public long cursorIndex = 0;

    private int interval = 0;

    private bool _isDone = false;
    [SerializeField] private int controllerIndex = 0;
    [SerializeField] private float threshold = 0.5f;
    [SerializeField] private int maxInterval = 10;
    [SerializeField] private Image[] cursors;
    [SerializeField] private Sprite unselectedCursorSprite;
    [SerializeField] private Sprite selectedCursorSprite;
    [SerializeField] private PlayerDispenser dispenser;
    [SerializeField] private int cursorNum;

    private PlayerController pc;

    
    private void Awake() {
        cursors[0].sprite = selectedCursorSprite;
        for(int i=1;i<cursors.Length;i++){
            cursors[i].sprite = unselectedCursorSprite;
        }
        pc=dispenser.GetController(cursorNum);
    }

    private void MoveCursor(bool isCorrect){
        cursors[cursorIndex].sprite = unselectedCursorSprite;
        cursorIndex=(cursors.Length+cursorIndex+(isCorrect?1:-1))%cursors.Length;
        cursors[cursorIndex].sprite = selectedCursorSprite;
    }

    private void Update() {
        if(!_isDone && pc.GetSubmitValue()){
            _isDone = true;
            cursors[cursorIndex].color = new Color(1f,1f,0f);
        }

        if(_isDone && pc.GetCancelValue()){
            _isDone = false;
            cursors[cursorIndex].color = new Color(1f,1f,1f);
        }
        if(interval>0)
            return;
        if(_isDone)
            return;
        float v = pc.GetMoveValue().x;
        if(v>threshold){
            MoveCursor(true);
            interval = maxInterval;
        }else if(v<-threshold){
            MoveCursor(false);
            interval = maxInterval;
        }
    }

    private void FixedUpdate() {
        interval--;
    }

    public bool IsDone {
        get{return _isDone;}
    }
}