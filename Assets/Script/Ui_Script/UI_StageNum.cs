using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StageNum : MonoBehaviour
{
    //test 용 정보값
    int StageNum = 1;
    int CurrentWave = 1;
    int WaveNum = 6;

    public Text UIstg_stgnum;
    public Text UIstg_wavenum;


    void Start()
    {
        SetStgnum();
        SetWavenum();
    }

    
    void Update()
    {
        
    }

    public void SetStgnum()
    {
        UIstg_stgnum.text = StageNum.ToString();
    }

    public void SetWavenum()
    {
        UIstg_wavenum.text = CurrentWave + " / " + WaveNum;
    }
}
