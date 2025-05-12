using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool opption1 = false; // ��Ʈ1
    public bool opption2 = false; // ��Ʈ2
    public bool opption3 = false; // ��Ʈ3

    [SerializeField]public int stageCount = 0; // �������� ī��Ʈ

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
    public bool isResult = false; // ���â Ȱ��ȭ ����

    public void Clear()
    {
        isSuccess = true;
        isPlayingGame = false;
        isResult = true; // ���â Ȱ��ȭ
        if (isResult == true)
        {
            if (isSuccess == false)
            {
                GameUIController.Instance.nextStageButton.SetActive(false); // ���� �������� ��ư ��Ȱ��ȭ
            }
            else
            {
                GameUIController.Instance.nextStageButton.SetActive(true); // ���� �������� ��ư Ȱ��ȭ
                if (GameUIController.Instance.endSceneIndex == SceneManager.GetActiveScene().buildIndex)
                {
                    GameUIController.Instance.nextStageButton.SetActive(false); // ���� �������� ��ư ��Ȱ��ȭ
                }
                else
                {
                    GameUIController.Instance.nextStageButton.SetActive(true); // ���� �������� ��ư Ȱ��ȭ
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
        isResult = true; // ���â Ȱ��ȭ ����
        isPlayingGame = false;
        isSuccess = false;
        if (isResult == true)
        {
            if (isSuccess == false)
            {
                GameUIController.Instance.nextStageButton.SetActive(false); // ���� �������� ��ư ��Ȱ��ȭ
            }
            else
            {
                GameUIController.Instance.nextStageButton.SetActive(true); // ���� �������� ��ư Ȱ��ȭ
                if (GameUIController.Instance.endSceneIndex == SceneManager.GetActiveScene().buildIndex)
                {
                    GameUIController.Instance.nextStageButton.SetActive(false); // ���� �������� ��ư ��Ȱ��ȭ
                }
                else
                {
                    GameUIController.Instance.nextStageButton.SetActive(true); // ���� �������� ��ư Ȱ��ȭ
                }
            }
            GameUIController.Instance.Result();
        }
    }
}
