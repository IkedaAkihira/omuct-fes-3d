using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
[System.Serializable]
class NamedAudio{
    public string name;
    public AudioClip clip;
}
 
public class SEPlayer : MonoBehaviour {
    [SerializeField]
    private NamedAudio[] audios;
    
    private Dictionary<string,AudioClip> audioDict = new Dictionary<string,AudioClip>();
    
    AudioSource audioSource;
 
    void Start () {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }
    
    void Awake () {
        foreach(NamedAudio audio in this.audios){
            this.audioDict.Add(audio.name,audio.clip);
        }
    }
    
    public void Play(string audioName){
        AudioClip clip = this.audioDict.GetValueOrDefault(audioName);
        this.audioSource.PlayOneShot(clip);
    }
}
