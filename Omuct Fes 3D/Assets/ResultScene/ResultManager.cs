using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
class Background{
    public int id;
    public Sprite winSprite;
    public Sprite loseSprite;
}

public class ResultManager : MonoBehaviour {
    [SerializeField] Image player1ResultImage;
    [SerializeField] Image player2ResultImage;
    
    [SerializeField] Image player1BackgroundImage;
    [SerializeField] Image player2BackgroundImage;
    [SerializeField] Sprite winSprite;
    [SerializeField] Sprite loseSprite;
    [SerializeField] Background[] backgrounds;
    [SerializeField] int resultSec = 5;
    long resultTime;

    private void Awake() {
        resultTime = resultSec * 50;
        this.player1ResultImage.sprite = DataTransfer.player1ResultData.isWin?this.winSprite:this.loseSprite;
        this.player2ResultImage.sprite = DataTransfer.player2ResultData.isWin?this.winSprite:this.loseSprite;
        Background bg1 = this.backgrounds[DataTransfer.player1ResultData.id];
        Background bg2 = this.backgrounds[DataTransfer.player2ResultData.id];
        this.player1BackgroundImage.sprite = DataTransfer.player1ResultData.isWin?bg1.winSprite:bg1.loseSprite;
        this.player2BackgroundImage.sprite = DataTransfer.player2ResultData.isWin?bg2.winSprite:bg2.loseSprite;
    }

    private void FixedUpdate() {
        if((--resultTime)<=0)
            SceneManager.LoadScene("StartScene");

    }
}