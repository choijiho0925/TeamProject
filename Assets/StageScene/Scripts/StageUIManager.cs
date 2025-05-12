using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageUIManager : MonoBehaviour
{
    [SerializeField] public GameObject stage1; // 스테이지 1 버튼
    [SerializeField] public GameObject stage2; // 스테이지 2 버튼

    public static StageUIManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // 싱글톤 인스턴스 설정
            DontDestroyOnLoad(gameObject); // 씬 전환 시 오브젝트 유지
        }
        else
        {
            Destroy(gameObject); // 중복된 오브젝트 삭제
        }
    }

    public void Stage1()
    {
        SceneManager.LoadScene(2); // 스테이지 1 씬으로 이동
        GameManager.Instance.isPlayingGame = true; // 게임 진행 시작
        GameManager.Instance.isSuccess = false; // 게임 성공 상태 초기화
        stage1.SetActive(false); // 스테이지 1 버튼 비활성화
        stage2.SetActive(false); // 스테이지 2 버튼 비활성화
        GameUIController.Instance.timeUI.SetActive(true); // 시간 UI
        GameUIController.Instance.restartButton.SetActive(true); // 재시작 버튼
        GameManager.Instance.stageCount = 1; // 스테이지 카운트 설정
    }

    public void Stage2()
    {
        SceneManager.LoadScene(3); // 스테이지 2 씬으로 이동
        GameManager.Instance.isPlayingGame = true; // 게임 진행 시작
        GameManager.Instance.isSuccess = false; // 게임 성공 상태 초기화
        stage1.SetActive(false); // 스테이지 1 버튼 비활성화
        stage2.SetActive(false); // 스테이지 2 버튼 비활성화
        GameUIController.Instance.timeUI.SetActive(true); // 시간 UI
        GameUIController.Instance.restartButton.SetActive(true); // 재시작 버튼
        GameManager.Instance.stageCount = 2; // 스테이지 카운트 설정
    }

    public void Stage3()
    {
        SceneManager.LoadScene(4); // 스테이지 3 씬으로 이동
        GameManager.Instance.isPlayingGame = true; // 게임 진행 시작
        GameManager.Instance.isSuccess = false; // 게임 성공 상태 초기화
        stage1.SetActive(false); // 스테이지 1 버튼 비활성화
        stage2.SetActive(false); // 스테이지 2 버튼 비활성화
        GameUIController.Instance.timeUI.SetActive(true); // 시간 UI
        GameUIController.Instance.restartButton.SetActive(true); // 재시작 버튼
        GameManager.Instance.stageCount = 3; // 스테이지 카운트 설정
    }

    public void Stage4()
    {
        SceneManager.LoadScene(5); // 스테이지 4 씬으로 이동
        GameManager.Instance.isPlayingGame = true; // 게임 진행 시작
        GameManager.Instance.isSuccess = false; // 게임 성공 상태 초기화
        stage1.SetActive(false); // 스테이지 1 버튼 비활성화
        stage2.SetActive(false); // 스테이지 2 버튼 비활성화
        GameUIController.Instance.timeUI.SetActive(true); // 시간 UI
        GameUIController.Instance.restartButton.SetActive(true); // 재시작 버튼
        GameManager.Instance.stageCount = 3; // 스테이지 카운트 설정
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

    public void StageSelect()
    {
        SceneManager.LoadScene(1); // 스테이지 선택 씬으로 이동
        stage1.SetActive(false); // 스테이지 1 버튼 비활성화
        stage2.SetActive(false); // 스테이지 2 버튼 비활성화
    }
}
