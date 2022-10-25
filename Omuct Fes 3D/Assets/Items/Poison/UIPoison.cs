using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class UIPoison : MonoBehaviour {
    Image image;

    List<Sprite>sprites;

    Sprite stopSprite;
    int count=0;

    public Player player;

    private void Awake() {
        stopSprite=Resources.Load<Sprite>("Textures/null");
        sprites=new List<Sprite>();
        sprites.Add(Resources.Load<Sprite>("Textures/poison_effect"));
        sprites.Add(Resources.Load<Sprite>("Textures/poison_effect1"));
        sprites.Add(Resources.Load<Sprite>("Textures/poison_effect2"));
        this.image=this.GetComponent<Image>();
    }

    private void FixedUpdate() {
        if(!player.effects.ContainsKey(EffectPoison.TYPE))
            this.image.sprite=this.stopSprite;
        else if(GameMaster.instance.gameTime%5==0){
            count++;
            this.image.sprite=this.sprites[count%this.sprites.Count];
        }
    }
}