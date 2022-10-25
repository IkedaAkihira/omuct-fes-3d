using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealTokeito : MonoBehaviour
{

    public Vector3 centerPos;
    private float realT;
    private readonly float TOKEITO_HEIGHT = 27.0f; // [m]
    private readonly float GROW_SPEED = 0.1f; // [/sec]
    private readonly float GROW_DELAY = 4.0f; // [sec]

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

        float growT = ((realT - GROW_DELAY) * GROW_SPEED) * 2.0f - 1.0f;
        float h = -0.5f;
        if (growT <= 1.01)
        {
            h = Mathf.Atan(growT * 3.0f / Mathf.PI) + (growT / 4.0f);
            h = (h + 1.0f) / 2.0f;
            h = Mathf.Min(h, 1.0f);
        }
        else
        {
            h = 1.0f;
        }

        Vector3 pos = centerPos + new Vector3(0.0f, 0.0f, 0.0f);
        pos.y = TOKEITO_HEIGHT * (h - 1.0f);

        transform.position = pos;
    }
}
