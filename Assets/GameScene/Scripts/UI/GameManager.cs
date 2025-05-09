using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private void Awake()
    { 
        if(Instance != null)
        {
            Destroy(Instance );
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
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
