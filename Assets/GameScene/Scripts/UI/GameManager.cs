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

    [SerializeField]public int stageCount = 0; // 스테이지 카운트

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

    private void Update()
    {

    }

    public bool isPlayingGame = false;
    public bool isSuccess = false;
    public bool isResult = false; // 결과창 활성화 여부

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

        StageInformation.Instance.PrintStage1_1Heart();
        StageInformation.Instance.PrintStage1_2Heart();
        StageInformation.Instance.PrintStage2_1Heart();
        StageInformation.Instance.PrintStage2_2Heart();
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
    }
}
