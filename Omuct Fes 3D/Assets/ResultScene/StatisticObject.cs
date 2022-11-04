using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatisticObject : MonoBehaviour
{
    [SerializeField] public StatisticRow headRow;
    [SerializeField] public int playerId;

    void SetStatistic(ResultData resultData)
    {
        StatisticRow p = headRow;
        p.SetValue("" + resultData.useItemCount);
        p = p.nextRow;
        p.SetValue("" + resultData.attackCount);
        p = p.nextRow;
        p.SetValue("" + resultData.jumpCount);
    }

    // Start is called before the first frame update
    void Start()
    {
        if(playerId == 0)
        {
            SetStatistic(DataTransfer.player1ResultData);
        }
        else if(playerId == 1)
        {
            SetStatistic(DataTransfer.player2ResultData);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
