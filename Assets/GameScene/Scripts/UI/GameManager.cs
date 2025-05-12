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
    public bool isResult = false; // ���â Ȱ��ȭ ����

    public void Clear()
    {
        isSuccess = true;
        isPlayingGame = false;
        isResult = true; // ���â Ȱ��ȭ
    }


    public void GameOver()
    {
        isResult = true; // ���â Ȱ��ȭ ����
        isPlayingGame = false;
        isSuccess = false;
    }
}
