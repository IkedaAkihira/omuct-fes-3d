using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ResultManager : MonoBehaviour {
    [SerializeField] Image player1ResultImage;
    [SerializeField] Image player2ResultImage;
    [SerializeField] Sprite winSprite;
    [SerializeField] Sprite loseSprite;
    [SerializeField] int resultSec = 5;
    long resultTime;

    private void Awake() {
        resultTime = resultSec * 50;
        this.player1ResultImage.sprite = DataTransfer.player1ResultData.isWin?this.winSprite:this.loseSprite;
        this.player2ResultImage.sprite = DataTransfer.player2ResultData.isWin?this.winSprite:this.loseSprite;
    }

    private void FixedUpdate() {
        if((--resultTime)<=0)
            SceneManager.LoadScene("StartScene");

    }
}