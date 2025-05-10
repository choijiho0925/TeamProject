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
    [SerializeField] private GameObject restartButton; // ����� ��ư
    [SerializeField] private GameObject timeUI; // �ð� UI

    TimeUIHandler timeUIHandler;

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
        timeUIHandler = gameObject.GetComponentInChildren<TimeUIHandler>(); // TimeUIHandler ������Ʈ ��������       
    }

    private void Update()
    {
        if (GameManager.Instance.isPlayingGame == false && GameManager.Instance.isSuccess == true)
        {
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

    public void StageSelected()
    {
        GameManager.Instance.isPlayingGame = false; // ���� ���� ����
        SceneManager.LoadScene("StageScene"); // �������� ������ �̵�
        settingtUI.SetActive(false); // ���� UI ��Ȱ��ȭ
        resultUI.SetActive(false); // ��� UI ��Ȱ��ȭ
        gameUI.SetActive(true); // ���� UI Ȱ��ȭ
        GameManager.Instance.isSuccess = false; // ���� ���� ���� �ʱ�ȭ
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���� �� �����
        timeUIHandler.playTime = 0f; // �÷��� �ð� �ʱ�ȭ
        settingtUI.SetActive(false); // ���� UI ��Ȱ��ȭ
        resultUI.SetActive(false); // ��� UI ��Ȱ��ȭ
        GameManager.Instance.isSuccess = false; // ���� ���� ���� �ʱ�ȭ
        GameManager.Instance.isPlayingGame = true; // ���� ����
    }

    public void NextStage()
    {
        GameManager.Instance.isPlayingGame = true; // ���� ���� ����
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // ���� �� �ε���
        SceneManager.LoadScene(currentSceneIndex + 1); // ���� ������ �̵�
        settingtUI.SetActive(false); // ���� UI ��Ȱ��ȭ
        resultUI.SetActive(false); // ��� UI ��Ȱ��ȭ
        GameManager.Instance.opption1 = false; // ��Ʈ1 �ʱ�ȭ
        GameManager.Instance.opption2 = false; // ��Ʈ2 �ʱ�ȭ
        GameManager.Instance.opption3 = false; // ��Ʈ3 �ʱ�ȭ
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

    public void ExitGame()
    {
        
    }
}

