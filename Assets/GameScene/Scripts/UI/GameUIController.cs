using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    [SerializeField] private GameObject settingtUI; // 셋팅 UI
    [SerializeField] private GameObject resultUI; // 스테이지 선택 UI

    TimeUIHandler timeUIHandler;

    private void Start()
    {
        timeUIHandler = FindObjectOfType<TimeUIHandler>(); // TimeUIHandler 스크립트 찾기
    }

    public void Setting()
    {
        GameManager.Instance.isPlayingGame = false;
        settingtUI.SetActive(true); // 셋팅 UI 활성화
    }

    public void Continue()
    {
        GameManager.Instance.isPlayingGame = true;
        settingtUI.SetActive(false); // 셋팅 UI 비활성화
    }

    public void StageSelected()
    {
        GameManager.Instance.isPlayingGame = false; // 게임 진행 중지
        SceneManager.LoadScene("StageScene"); // 스테이지 씬으로 이동
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 씬 재시작
        timeUIHandler.playTime = 0f; // 플레이 시간 초기화
    }

    public void NextStage()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // 현재 씬 인덱스
        SceneManager.LoadScene(currentSceneIndex + 1); // 다음 씬으로 이동
    }

    public void Clear()
    {
        resultUI.SetActive(true); // 결과 UI 활성화    
    }
}

