using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour {
    private void Update() {
        if(Input.GetKeyDown(KeyCode.Return)){
            SceneManager.LoadScene("CharacterSelectScene");
        }
    }
}