using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool opption1 = false; // 하트1
    public bool opption2 = false; // 하트2
    public bool opption3 = false; // 하트3

    [SerializeField] public int stageCount = 0; // 스테이지 카운트

    public bool isCheckTime = true; // 시간 체크 여부
    public bool isPlayingGame = false;
    public bool isSuccess = false;
    public bool isResult = false; // 결과창 활성화 여부

    StageInformation stageInformation;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Update()
    {

    }

    public void Clear()
    {
        isSuccess = true;
        isPlayingGame = false;
        isResult = true; // 결과창 활성화
        if (isResult == true)
        {
            if (isSuccess == false)
            {
                GameUIController.Instance.nextStageButton.SetActive(false); // 다음 스테이지 버튼 비활성화
            }
            else
            {
                GameUIController.Instance.nextStageButton.SetActive(true); // 다음 스테이지 버튼 활성화
                if (GameUIController.Instance.endSceneIndex == SceneManager.GetActiveScene().buildIndex)
                {
                    GameUIController.Instance.nextStageButton.SetActive(false); // 다음 스테이지 버튼 비활성화
                }
                else
                {
                    GameUIController.Instance.nextStageButton.SetActive(true); // 다음 스테이지 버튼 활성화
                }
            }
            GameUIController.Instance.Result();
        }
        switch (stageCount)
        {
            case 1:
                StageInformation.Instance.PrintStage1_1Heart();
                break;
            case 2:
                StageInformation.Instance.PrintStage1_2Heart();
                break;
            case 3:
                StageInformation.Instance.PrintStage2_1Heart();
                break;
            case 4:
                StageInformation.Instance.PrintStage2_2Heart();
                break;
        }
        StageInformation.Instance.UnLockStage();
        Time.timeScale = 0; // 게임 일시 정지
    }


    public void GameOver()
    {
        isResult = true; // 결과창 활성화 여부
        isPlayingGame = false;
        isSuccess = false;
        if (isResult == true)
        {
            if (isSuccess == false)
            {
                GameUIController.Instance.nextStageButton.SetActive(false); // 다음 스테이지 버튼 비활성화
            }
            else
            {
                GameUIController.Instance.nextStageButton.SetActive(true); // 다음 스테이지 버튼 활성화
                if (GameUIController.Instance.endSceneIndex == SceneManager.GetActiveScene().buildIndex)
                {
                    GameUIController.Instance.nextStageButton.SetActive(false); // 다음 스테이지 버튼 비활성화
                }
                else
                {
                    GameUIController.Instance.nextStageButton.SetActive(true); // 다음 스테이지 버튼 활성화
                }
            }
            GameUIController.Instance.Result();
        }
        Time.timeScale = 0; // 게임 일시 정지
    }
}

