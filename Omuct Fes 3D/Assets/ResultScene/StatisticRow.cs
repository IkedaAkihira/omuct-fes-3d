using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatisticRow : MonoBehaviour
{
    [SerializeField] public StatisticRow nextRow = null;
    [SerializeField] private Text textL;
    [SerializeField] private Text textR;

    public void SetValue(string value)
    {
        textR.text = "| " + value;
    }

    public void SetKey(string key)
    {
        textL.text = key;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
