using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealTokeito : MonoBehaviour
{

    public Vector3 centerPos;
    private float t;
    private readonly float TOKEITO_HEIGHT = 27.0f;
    private readonly float GROW_SPEED = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        t = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.deltaTime * GROW_SPEED;
        t += dt;

        Vector3 pos = centerPos + new Vector3(0.0f, 0.0f, 0.0f);
        float x = (t - 0.005f) * 2.0f - 1.0f;
        float h = -0.5f;
        if (x <= 1.01)
        {
            h = Mathf.Atan(x * 3.0f / Mathf.PI) + (x / 4.0f);
            h = Mathf.Min(h);
        }
        else
        {
            h = 1.0f;
        }
        pos.y = TOKEITO_HEIGHT * (h - 1.0f);

        transform.position = pos;
    }
}
