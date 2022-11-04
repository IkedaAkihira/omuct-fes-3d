using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectorManager : MonoBehaviour {
    [SerializeField] private CharacterSelector[] characterSelectors;
    private void Awake() {
        
    }

    private void Update() {
        foreach (CharacterSelector cs  in characterSelectors) {
            if(!cs.IsDone){
                return;
            }
        }

        DataTransfer.player1CharacterNumber=characterSelectors[0].cursorIndex;
        DataTransfer.player2CharacterNumber=characterSelectors[1].cursorIndex;

        SceneManager.LoadScene("BattleScene");
    }
}