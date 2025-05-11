using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageUIManager : MonoBehaviour
{
    [SerializeField] private GameObject stage1; // 스테이지 1 버튼
    [SerializeField] private GameObject stage2; // 스테이지 2 버튼

    public void Stage1()
    {
        SceneManager.LoadScene(2); // 스테이지 1 씬으로 이동
        GameManager.Instance.isPlayingGame = true; // 게임 진행 시작
        GameManager.Instance.isSuccess = false; // 게임 성공 상태 초기화
        GameManager.Instance.opption1 = false; // 하트1 초기화
        GameManager.Instance.opption2 = false; // 하트2 초기화
        GameManager.Instance.opption3 = false; // 하트3 초기화
        GameUIController.Instance.timeUI.SetActive(true); // 시간 UI
        GameUIController.Instance.restartButton.SetActive(true); // 재시작 버튼
    }

    public void Stage2()
    {
        SceneManager.LoadScene(3); // 스테이지 2 씬으로 이동
        GameManager.Instance.isPlayingGame = true; // 게임 진행 시작
        GameManager.Instance.isSuccess = false; // 게임 성공 상태 초기화
        GameManager.Instance.opption1 = false; // 하트1 초기화
        GameManager.Instance.opption2 = false; // 하트2 초기화
        GameManager.Instance.opption3 = false; // 하트3 초기화
        GameUIController.Instance.timeUI.SetActive(true); // 시간 UI
        GameUIController.Instance.restartButton.SetActive(true); // 재시작 버튼
    }

    public void Stage3()
    {
        SceneManager.LoadScene(4); // 스테이지 3 씬으로 이동
        GameManager.Instance.isPlayingGame = true; // 게임 진행 시작
        GameManager.Instance.isSuccess = false; // 게임 성공 상태 초기화
        GameManager.Instance.opption1 = false; // 하트1 초기화
        GameManager.Instance.opption2 = false; // 하트2 초기화
        GameManager.Instance.opption3 = false; // 하트3 초기화
        GameUIController.Instance.timeUI.SetActive(true); // 시간 UI
        GameUIController.Instance.restartButton.SetActive(true); // 재시작 버튼
    }

    public void Goback()
    {
        SceneManager.LoadScene(1);
        stage1.SetActive(false); // 스테이지 1 버튼 비활성화
        stage2.SetActive(false); // 스테이지 2 버튼 비활성화
    }

    public void SelectedStage1()
    {
        stage1.SetActive(true); // 스테이지 1 버튼 활성화
    }

    public void SelectedStage2()
    {
        stage2.SetActive(true); // 스테이지 2 버튼 활성화
    }
}
