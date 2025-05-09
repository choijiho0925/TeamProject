using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool opption1 = false; // 하트1
    public bool opption2 = false; // 하트2
    public bool opption3 = false; // 하트3

    private void Awake()
    { 
        if(Instance != null)
        {
            Destroy(gameObject );
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public bool isPlayingGame = false;
    public bool isSuccess = false;

    public void Clear()
    {
        isSuccess = true;
        isPlayingGame = false;
        //클리어UI SetActive = true
    }


    public void GameOver()
    {
        //  실패UI SetActive = true
    }
}
