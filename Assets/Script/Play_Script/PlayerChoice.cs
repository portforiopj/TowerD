using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerChoice : MonoBehaviour
{
    void Awake()
    {
        
        transform.GetChild(GameSystem.Instatce.G_choiceint).gameObject.SetActive(true);
    }
   
}
