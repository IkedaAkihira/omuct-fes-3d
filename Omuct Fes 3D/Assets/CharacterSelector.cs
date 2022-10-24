using UnityEngine;
using UnityEngine.UI;

public class CharacterSelector : MonoBehaviour {
    private long cursorIndex = 0;

    private int interval = 0;

    private bool _isDone = false;
    [SerializeField] private string selectAxis = "Horizontal";
    [SerializeField] private string selectButton = "Submit";
    [SerializeField] private string cancelButton = "Cancel";
    [SerializeField] private float threshold = 0.5f;
    [SerializeField] private int maxInterval = 10;
    [SerializeField] private Image[] cursors;
    [SerializeField] private Sprite unselectedCursorSprite;
    [SerializeField] private Sprite selectedCursorSprite;
    private void Awake() {
        cursors[0].sprite = selectedCursorSprite;
        for(int i=1;i<cursors.Length;i++){
            cursors[i].sprite = unselectedCursorSprite;
        }
    }

    private void MoveCursor(bool isCorrect){
        cursors[cursorIndex].sprite = unselectedCursorSprite;
        cursorIndex=(cursors.Length+cursorIndex+(isCorrect?1:-1))%cursors.Length;
        cursors[cursorIndex].sprite = selectedCursorSprite;
    }

    private void Update() {
        if(!_isDone && Input.GetButtonDown(selectButton)){
            _isDone = true;
            cursors[cursorIndex].sprite = unselectedCursorSprite;
        }

        if(_isDone && Input.GetButtonDown(cancelButton)){
            _isDone = false;
            cursors[cursorIndex].sprite = selectedCursorSprite;
        }
        if(interval>0)
            return;
        if(_isDone)
            return;
        float v = Input.GetAxis(selectAxis);
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