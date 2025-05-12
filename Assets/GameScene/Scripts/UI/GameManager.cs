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
    public bool isResult = false; // 결과창 활성화 여부

    public void Clear()
    {
        isSuccess = true;
        isPlayingGame = false;
        isResult = true; // 결과창 활성화
    }


    public void GameOver()
    {
        isResult = true; // 결과창 활성화 여부
        isPlayingGame = false;
        isSuccess = false;
    }
}
