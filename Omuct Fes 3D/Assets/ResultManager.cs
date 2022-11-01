using UnityEngine;
using UnityEngine.UI;
public class ResultManager : MonoBehaviour {
    [SerializeField] Image player1ResultImage;
    [SerializeField] Image player2ResultImage;
    [SerializeField] Sprite winSprite;
    [SerializeField] Sprite loseSprite;

    private void Awake() {
        this.player1ResultImage.sprite = DataTransfer.player1ResultData.isWin?this.winSprite:this.loseSprite;
        this.player2ResultImage.sprite = DataTransfer.player2ResultData.isWin?this.winSprite:this.loseSprite;
    }
}