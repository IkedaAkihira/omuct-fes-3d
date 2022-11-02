using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeginningCountdown
{
    GameObject drawerL;
    GameObject drawerR;
    Text textL;
    Text textR;

    // Start is called before the first frame update
    public BeginningCountdown()
    {
        GameObject canvas = GameObject.Find("Canvas");
        Font font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

        drawerL = new GameObject("BeginningCountdown.drawerL");
        drawerL.layer = 5;
        drawerL.transform.parent = canvas.transform;
        drawerL.transform.localPosition = new Vector3(-200.0f, 0.0f, 0.0f);
        drawerL.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        drawerL.AddComponent<Text>();
        RectTransform rectTransformL = drawerL.GetComponent<RectTransform>();
        rectTransformL.sizeDelta = new Vector2(400.0f, 400.0f);
        textL = drawerL.GetComponent<Text>();
        textL.font = font;
        textL.alignment = TextAnchor.MiddleCenter;
        drawerL.SetActive(true);

        drawerR = new GameObject("BeginningCountdown.drawerR");
        drawerR.layer = 5;
        drawerR.transform.parent = canvas.transform;
        drawerR.transform.localPosition = new Vector3(200.0f, 0.0f, 0.0f);
        drawerR.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        drawerR.AddComponent<Text>();
        RectTransform rectTransformR = drawerR.GetComponent<RectTransform>();
        rectTransformR.sizeDelta = new Vector2(400.0f, 400.0f);
        textR = drawerR.GetComponent<Text>();
        textR.font = font;
        textR.alignment = TextAnchor.MiddleCenter;
        drawerR.SetActive(true);
    }

    public void Update(long gameTime)
    {
        const long gameTimePerSec = 50;
        long tick = 0;
        if (gameTime < 0) tick = -((-gameTime + gameTimePerSec - 1) / gameTimePerSec); else tick = gameTime / gameTimePerSec;
        float tickGrad = (gameTime - tick * gameTimePerSec) * 0.01f;

        if (tick == 0)
        {
            textL.text = "GO!";
            textL.fontSize = 200;
            textL.color = new Color(1.0f, 0.0f, 0.5f, 1.0f - tickGrad);
            textR.text = "GO!";
            textR.fontSize = 200;
            textR.color = new Color(1.0f, 0.0f, 0.5f, 1.0f - tickGrad);
            drawerL.SetActive(true);
            drawerR.SetActive(true);
        }
        else if (-3 <= tick && tick < 0)
        {
            textL.text = "" + (-tick);
            textL.fontSize = 300;
            textL.color = new Color(1.0f, 0.0f, 0.5f, 1.0f - tickGrad);
            textR.text = "" + (-tick);
            textR.fontSize = 300;
            textR.color = new Color(1.0f, 0.0f, 0.5f, 1.0f - tickGrad);
            drawerL.SetActive(true);
            drawerR.SetActive(true);
        }
        else
        {
            drawerL.SetActive(false);
            drawerR.SetActive(false);
        }
    }
}
