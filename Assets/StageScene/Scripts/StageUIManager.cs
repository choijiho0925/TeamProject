using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageUIManager : MonoBehaviour
{
    [SerializeField] public GameObject stage1; // �������� 1 ��ư
    [SerializeField] public GameObject stage2; // �������� 2 ��ư
    [SerializeField] private GameObject timeUI; // �ð� UI

    public static StageUIManager Instance;
    TimeUIHandler timeUIHandler; // TimeUIHandler ������Ʈ

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
        timeUIHandler = timeUI.GetComponent<TimeUIHandler>(); // TimeUIHandler ������Ʈ �������� 
    }

    public void Stage1()
    {
        SceneManager.LoadScene(2); // �������� 1 ������ �̵�
        GameManager.Instance.isPlayingGame = true; // ���� ���� ����
        GameManager.Instance.isSuccess = false; // ���� ���� ���� �ʱ�ȭ
        stage1.SetActive(false); // �������� 1 ��ư ��Ȱ��ȭ
        stage2.SetActive(false); // �������� 2 ��ư ��Ȱ��ȭ
        GameUIController.Instance.timeUI.SetActive(true); // �ð� UI
        GameUIController.Instance.restartButton.SetActive(true); // ����� ��ư
        GameManager.Instance.stageCount = 1; // �������� ī��Ʈ ����
        StageInformation.Instance.ResetItemCount(); // ������ ī��Ʈ �ʱ�ȭ
        
    }

    public void Stage2()
    {
        if (!StageInformation.Instance.stage1_1Clear)
        {
            return;
        }
        else
        {
            SceneManager.LoadScene(3); // �������� 2 ������ �̵�
            GameManager.Instance.isPlayingGame = true; // ���� ���� ����
            GameManager.Instance.isSuccess = false; // ���� ���� ���� �ʱ�ȭ
            stage1.SetActive(false); // �������� 1 ��ư ��Ȱ��ȭ
            stage2.SetActive(false); // �������� 2 ��ư ��Ȱ��ȭ
            GameUIController.Instance.timeUI.SetActive(true); // �ð� UI
            GameUIController.Instance.restartButton.SetActive(true); // ����� ��ư
            GameManager.Instance.stageCount = 2; // �������� ī��Ʈ ����
            StageInformation.Instance.ResetItemCount(); // ������ ī��Ʈ �ʱ�ȭ
            
        }

    }

    public void Stage3()
    {
        if (!StageInformation.Instance.stage1_2Clear)
        {
            return;
        }
        else
        {
            SceneManager.LoadScene(4); // �������� 3 ������ �̵�
            GameManager.Instance.isPlayingGame = true; // ���� ���� ����
            GameManager.Instance.isSuccess = false; // ���� ���� ���� �ʱ�ȭ
            stage1.SetActive(false); // �������� 1 ��ư ��Ȱ��ȭ
            stage2.SetActive(false); // �������� 2 ��ư ��Ȱ��ȭ
            GameUIController.Instance.timeUI.SetActive(true); // �ð� UI
            GameUIController.Instance.restartButton.SetActive(true); // ����� ��ư
            GameManager.Instance.stageCount = 3; // �������� ī��Ʈ ����
            StageInformation.Instance.ResetItemCount(); // ������ ī��Ʈ �ʱ�ȭ
            
        }
    }

    public void Stage4()
    {
        if (!StageInformation.Instance.stage2_1Clear)
        {
            return;
        }
        else
        {
            SceneManager.LoadScene(5); // �������� 4 ������ �̵�
            GameManager.Instance.isPlayingGame = true; // ���� ���� ����
            GameManager.Instance.isSuccess = false; // ���� ���� ���� �ʱ�ȭ
            stage1.SetActive(false); // �������� 1 ��ư ��Ȱ��ȭ
            stage2.SetActive(false); // �������� 2 ��ư ��Ȱ��ȭ
            GameUIController.Instance.timeUI.SetActive(true); // �ð� UI
            GameUIController.Instance.restartButton.SetActive(true); // ����� ��ư
            GameManager.Instance.stageCount = 3; // �������� ī��Ʈ ����
            StageInformation.Instance.ResetItemCount(); // ������ ī��Ʈ �ʱ�ȭ
            
        }
    }

    public void Goback()
    {
        SceneManager.LoadScene(1);
        stage1.SetActive(false); // �������� 1 ��ư ��Ȱ��ȭ
        stage2.SetActive(false); // �������� 2 ��ư ��Ȱ��ȭ
    }

    public void SelectedStage1()
    {
        stage1.SetActive(true); // �������� 1 ��ư Ȱ��ȭ
    }

    public void SelectedStage2()
    {
        stage2.SetActive(true); // �������� 2 ��ư Ȱ��ȭ
    }

    public void StageSelect()
    {
        SceneManager.LoadScene(1); // �������� ���� ������ �̵�
        stage1.SetActive(false); // �������� 1 ��ư ��Ȱ��ȭ
        stage2.SetActive(false); // �������� 2 ��ư ��Ȱ��ȭ
    }
}
