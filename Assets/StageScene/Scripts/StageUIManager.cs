using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageUIManager : MonoBehaviour
{
    [SerializeField] private GameObject stage1; // �������� 1 ��ư
    [SerializeField] private GameObject stage2; // �������� 2 ��ư

    public void Stage1()
    {
        SceneManager.LoadScene(2); // �������� 1 ������ �̵�
        GameManager.Instance.isPlayingGame = true; // ���� ���� ����
        GameManager.Instance.isSuccess = false; // ���� ���� ���� �ʱ�ȭ
        GameManager.Instance.opption1 = false; // ��Ʈ1 �ʱ�ȭ
        GameManager.Instance.opption2 = false; // ��Ʈ2 �ʱ�ȭ
        GameManager.Instance.opption3 = false; // ��Ʈ3 �ʱ�ȭ
        GameUIController.Instance.timeUI.SetActive(true); // �ð� UI
        GameUIController.Instance.restartButton.SetActive(true); // ����� ��ư
    }

    public void Stage2()
    {
        SceneManager.LoadScene(3); // �������� 2 ������ �̵�
        GameManager.Instance.isPlayingGame = true; // ���� ���� ����
        GameManager.Instance.isSuccess = false; // ���� ���� ���� �ʱ�ȭ
        GameManager.Instance.opption1 = false; // ��Ʈ1 �ʱ�ȭ
        GameManager.Instance.opption2 = false; // ��Ʈ2 �ʱ�ȭ
        GameManager.Instance.opption3 = false; // ��Ʈ3 �ʱ�ȭ
        GameUIController.Instance.timeUI.SetActive(true); // �ð� UI
        GameUIController.Instance.restartButton.SetActive(true); // ����� ��ư
    }

    public void Stage3()
    {
        SceneManager.LoadScene(4); // �������� 3 ������ �̵�
        GameManager.Instance.isPlayingGame = true; // ���� ���� ����
        GameManager.Instance.isSuccess = false; // ���� ���� ���� �ʱ�ȭ
        GameManager.Instance.opption1 = false; // ��Ʈ1 �ʱ�ȭ
        GameManager.Instance.opption2 = false; // ��Ʈ2 �ʱ�ȭ
        GameManager.Instance.opption3 = false; // ��Ʈ3 �ʱ�ȭ
        GameUIController.Instance.timeUI.SetActive(true); // �ð� UI
        GameUIController.Instance.restartButton.SetActive(true); // ����� ��ư
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
}
