using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealTokeito : MonoBehaviour
{

    public Vector3 centerPos;
    private float realT;
    [SerializeField] private float TOKEITO_HEIGHT = 27.0f; // [m]
    [SerializeField] private float GROW_DELAY = 4.0f; // [sec]
    [SerializeField] private float GROW_TIME = 10.0f; // [sec]
    [SerializeField] private float STAY_INTERVAL = 30.0f; // [sec]
    [SerializeField] private float DRAWN_TIME = 5.0f; // [sec]
    [SerializeField] private float DELETE_DELAY = 4.0f; // [sec]

    // Start is called before the first frame update
    void Start()
    {
        realT = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime;
        realT += dt;

        float h = -0.5f;

        float GROW_TIMESTAMP = GROW_DELAY + GROW_TIME;
        float STAY_TIMESTAMP = GROW_TIMESTAMP + STAY_INTERVAL;
        float DRAWN_TIMESTAMP = STAY_TIMESTAMP + DRAWN_TIME + DELETE_DELAY;

        if (realT < GROW_TIMESTAMP)
        {
            float growT = ((realT - GROW_DELAY) / GROW_TIME) * 2.0f - 1.0f;
            h = Mathf.Atan(growT * 3.0f / Mathf.PI) + (growT / 4.0f);
            h = Mathf.Min(h, 1.0f);
            h = (h + 1.0f) / 2.0f;
        }
        else if(realT < STAY_TIMESTAMP)
        {
            h = 1.0f;
        }
        else if(realT < DRAWN_TIMESTAMP)
        {
            float drawnOffsetT = DRAWN_TIMESTAMP - DELETE_DELAY - realT;
            float growT = (drawnOffsetT / DRAWN_TIME) * 2.0f - 1.0f;
            h = Mathf.Atan(growT * 3.0f / Mathf.PI) + (growT / 4.0f);
            h = Mathf.Min(h, 1.0f);
            h = (h + 1.0f) / 2.0f;
        }
        else
        {
            Destroy(this.gameObject);
        }

        Vector3 pos = centerPos + new Vector3(0.0f, 0.0f, 0.0f);
        pos.y = TOKEITO_HEIGHT * (h - 1.0f);

        transform.position = pos;
    }
}
