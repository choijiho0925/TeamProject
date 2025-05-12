using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    [Header("StartScene")]
    [SerializeField] private GameObject Option; // �ɼ� UI

    [Header("GameUI")] 
    [SerializeField] private GameObject gameUI; // ���� UI
    [SerializeField] private GameObject settingtUI; // ���� UI
    [SerializeField] private GameObject resultUI; // �������� ���� UI
    [SerializeField] public GameObject restartButton; // ����� ��ư
    [SerializeField] public GameObject timeUI; // �ð� UI
    [SerializeField] public GameObject endRestartButton; // ����� ��ư
    [SerializeField] public GameObject nextStageButton; // ������������ ���� ��ư

    int endSceneIndex = 4; // ������ �� �ε���

    TimeUIHandler timeUIHandler;
    StageInformation stageInformation;

    public static GameUIController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // �̱��� �ν��Ͻ� ����
            DontDestroyOnLoad(gameObject); // �� ��ȯ �� ������Ʈ ����
        }
        else
        {
            Destroy(gameObject); // �ߺ��� ������Ʈ ����
        }
    }

    private void Start()
    {
        timeUIHandler = timeUI.GetComponentInChildren<TimeUIHandler>(); // TimeUIHandler ������Ʈ ��������       
    }

    private void Update()
    {
        if (GameManager.Instance.isResult == true)
        {
            if(GameManager.Instance.isSuccess == false)
            {
                nextStageButton.SetActive(false); // ���� �������� ��ư ��Ȱ��ȭ
            }
            else
            {
                nextStageButton.SetActive(true); // ���� �������� ��ư Ȱ��ȭ
                if (endSceneIndex == SceneManager.GetActiveScene().buildIndex)
                {
                    nextStageButton.SetActive(false); // ���� �������� ��ư ��Ȱ��ȭ
                }
                else
                {
                    nextStageButton.SetActive(true); // ���� �������� ��ư Ȱ��ȭ
                }
            }
            Result();
        }
    }

    public void Setting()
    {
        GameManager.Instance.isPlayingGame = false;
        settingtUI.SetActive(true); // ���� UI Ȱ��ȭ
    }

    public void Continue()
    {
        GameManager.Instance.isPlayingGame = true;
        settingtUI.SetActive(false); // ���� UI ��Ȱ��ȭ
    }

    public void Result()
    {
        resultUI.SetActive(true); // ��� UI Ȱ��ȭ    
        GameOverHandler.Instance.PrintResult(); // ��� ���
    }

    public void StartOpttion()
    {
        Option.SetActive(true); // �ɼ� UI Ȱ��ȭ
    }

    public void CloseOpttion()
    {
        Option.SetActive(false); // �ɼ� UI ��Ȱ��ȭ
    }

    public void StageSelected()
    {
        SceneManager.LoadScene("StageScene"); // �������� ������ �̵�
        timeUIHandler.playTime = 0f; // �÷��� �ð� �ʱ�ȭ
        settingtUI.SetActive(false); // ���� UI ��Ȱ��ȭ
        resultUI.SetActive(false); // ��� UI ��Ȱ��ȭ
        gameUI.SetActive(true); // ���� UI Ȱ��ȭ
        restartButton.SetActive(false); // ����� ��ư ��Ȱ��ȭ
        timeUI.SetActive(false); // �ð� UI ��Ȱ��ȭ
        GameManager.Instance.opption1 = false; // ��Ʈ1 �ʱ�ȭ
        GameManager.Instance.opption2 = false; // ��Ʈ2 �ʱ�ȭ
        GameManager.Instance.opption3 = false; // ��Ʈ3 �ʱ�ȭ
        GameManager.Instance.isPlayingGame = false; // ���� ���� ����
        GameManager.Instance.isSuccess = false; // ���� ���� ���� �ʱ�ȭ
        GameManager.Instance.isResult = false; // ���â ��Ȱ��ȭ
        GameManager.Instance.stageCount = 0; // �������� ī��Ʈ �ʱ�ȭ
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���� �� �����
        timeUIHandler.playTime = 0f; // �÷��� �ð� �ʱ�ȭ
        settingtUI.SetActive(false); // ���� UI ��Ȱ��ȭ
        resultUI.SetActive(false); // ��� UI ��Ȱ��ȭ
        GameManager.Instance.opption1 = false; // ��Ʈ1 �ʱ�ȭ
        GameManager.Instance.opption2 = false; // ��Ʈ2 �ʱ�ȭ
        GameManager.Instance.opption3 = false; // ��Ʈ3 �ʱ�ȭ
        GameManager.Instance.isSuccess = false; // ���� ���� ���� �ʱ�ȭ
        GameManager.Instance.isPlayingGame = true; // ���� ����
        GameManager.Instance.isResult = false; // ���â ��Ȱ��ȭ
    }

    public void NextStage()
    {
        GameManager.Instance.isPlayingGame = true; // ���� ���� ����
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // ���� �� �ε���
        SceneManager.LoadScene(currentSceneIndex + 1); // ���� ������ �̵�
        GameManager.Instance.stageCount++; // �������� ī��Ʈ ����
        timeUIHandler.playTime = 0f; // �÷��� �ð� �ʱ�ȭ
        settingtUI.SetActive(false); // ���� UI ��Ȱ��ȭ
        resultUI.SetActive(false); // ��� UI ��Ȱ��ȭ
        GameManager.Instance.opption1 = false; // ��Ʈ1 �ʱ�ȭ
        GameManager.Instance.opption2 = false; // ��Ʈ2 �ʱ�ȭ
        GameManager.Instance.opption3 = false; // ��Ʈ3 �ʱ�ȭ
        GameManager.Instance.isSuccess = false; // ���� ���� ���� �ʱ�ȭ
        GameManager.Instance.isResult = false; // ���â ��Ȱ��ȭ
    }

    public void ExitGame()
    {
        
    }
}

