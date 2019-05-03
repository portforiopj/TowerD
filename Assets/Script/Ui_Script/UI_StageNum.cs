using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_StageNum : MonoBehaviour
{
    //test 용 정보값
    int StageNum ;
    int CurrentWave;
    int WaveNum = 6;
    bool Waveset =false;
    public Text UIstg_stgnum;
    public Text UIstg_wavenum;
    void Awake()
    {
        
    }

    void Start()
    {
        StageNum = GameSystem.Instatce.G_round + 1;
        CurrentWave = GameSystem.Instatce.G_wave+ 1;
        SetStgnum();
        SetWavenum();
    }

    
    void Update()
    {
        if(GameSystem.Instatce.G_state== GameSystem.GameState.Ready && !Waveset)
        {
            StageNum = GameSystem.Instatce.G_round + 1;
            CurrentWave = GameSystem.Instatce.G_wave + 1;
            SetStgnum();
            SetWavenum();
            Waveset = true;
        }
        if(GameSystem.Instatce.G_state == GameSystem.GameState.Play)
        {
            Waveset = false;
        }
    }

    public void SetStgnum()
    {
        UIstg_stgnum.text ="Stage : "+ StageNum.ToString();
    }

    public void SetWavenum()
    {
        UIstg_wavenum.text ="Wave : "+ CurrentWave + " / " + WaveNum;
    }
}
