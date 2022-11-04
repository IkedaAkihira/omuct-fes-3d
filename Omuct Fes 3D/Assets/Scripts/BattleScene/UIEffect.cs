using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class UIEffect : MonoBehaviour {
    Image image;

    [SerializeField] List<Sprite>sprites;

    [SerializeField] Sprite stopSprite;
    [SerializeField] int effectType;
    [SerializeField] int interval = 5;
    int count=0;

    public Player player;

    private void Awake() {
        this.image=this.GetComponent<Image>();
    }

    private void FixedUpdate() {
        if(!player.effects.ContainsKey(effectType))
            this.image.sprite=this.stopSprite;
        else if(GameMaster.instance.gameTime%interval==0){
            count++;
            this.image.sprite=this.sprites[count%this.sprites.Count];
        }
    }
}