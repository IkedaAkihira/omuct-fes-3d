using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleTimer
{
    static public long TimeInSecond = 300;

    GameObject drawerL;
    GameObject drawerR;
    GameObject drawerM;
    Text textL;
    Text textR;
    Text timerText;

    // Start is called before the first frame update
    public BattleTimer()
    {
        GameObject canvas = GameObject.Find("Canvas");
        Font font = Resources.GetBuiltinResource(typeof(Font), "Arial.ttf") as Font;

        drawerL = new GameObject("BattleTimer.drawerL");
        drawerL.layer = 5;
        drawerL.transform.parent = canvas.transform;
        drawerL.transform.localPosition = new Vector3(-200.0f, 0.0f, 0.0f);
        drawerL.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        textL = drawerL.AddComponent<Text>();
        textL.font = font;
        textL.alignment = TextAnchor.MiddleCenter;
        RectTransform rectTransformL = drawerL.GetComponent<RectTransform>();
        rectTransformL.sizeDelta = new Vector2(400.0f, 450.0f);
        drawerL.SetActive(true);

        drawerR = new GameObject("BattleTimer.drawerR");
        drawerR.layer = 5;
        drawerR.transform.parent = canvas.transform;
        drawerR.transform.localPosition = new Vector3(200.0f, 0.0f, 0.0f);
        drawerR.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        textR = drawerR.AddComponent<Text>();
        textR.font = font;
        textR.alignment = TextAnchor.MiddleCenter;
        RectTransform rectTransformR = drawerR.GetComponent<RectTransform>();
        rectTransformR.sizeDelta = new Vector2(400.0f, 450.0f);
        drawerR.SetActive(true);

        drawerM = new GameObject("BattleTimer.drawerM");
        drawerM.layer = 5;
        drawerM.transform.parent = canvas.transform;
        drawerM.transform.localPosition = new Vector3(0.0f, 0.0f, 0.0f);
        drawerM.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
        timerText = drawerM.AddComponent<Text>();
        timerText.font = font;
        timerText.fontSize = 32;
        timerText.color = Color.black;
        timerText.alignment = TextAnchor.UpperCenter;
        RectTransform rectTransformM = drawerM.GetComponent<RectTransform>();
        rectTransformM.sizeDelta = new Vector2(800.0f, 446.0f);
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

        long timerValue = System.Math.Clamp(TimeInSecond - tick, 0L, TimeInSecond);
        string timerString = (timerValue / 60 % 10) + ":" + (timerValue % 60 / 10) + (timerValue % 10);
        timerText.text = timerString;

        if(timerValue == 0)
        {
            GameMaster.instance.Finish();
        }
    }
}
