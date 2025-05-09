using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private GameObject settingtUI; // ���� UI
    [SerializeField] private GameObject resultUI; // �������� ���� UI

    TimeUIHandler timeUIHandler;

    private void Start()
    {
        timeUIHandler = FindObjectOfType<TimeUIHandler>(); // TimeUIHandler ��ũ��Ʈ ã��
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
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // ���� �� �����
        timeUIHandler.playTime = 0f; // �÷��� �ð� �ʱ�ȭ
    }

    public void NextStage()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // ���� �� �ε���
        SceneManager.LoadScene(currentSceneIndex + 1); // ���� ������ �̵�
    }

    public void Clear()
    {
        resultUI.SetActive(true); // ��� UI Ȱ��ȭ    
    }
}

