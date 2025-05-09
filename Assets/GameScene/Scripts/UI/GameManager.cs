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
        //Ŭ����UI SetActive = true
    }


    public void GameOver()
    {
        //  ����UI SetActive = true
    }
}
