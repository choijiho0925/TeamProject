using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool opption1 = false; // ��Ʈ1
    public bool opption2 = false; // ��Ʈ2
    public bool opption3 = false; // ��Ʈ3

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
        //Ŭ����UI SetActive = true
    }


    public void GameOver()
    {
        //  ����UI SetActive = true
    }
}
