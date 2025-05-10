using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    [Header("StartScene")]
    [SerializeField] private GameObject Option; // 옵션 UI

    [Header("GameUI")] 
    [SerializeField] private GameObject gameUI; // 게임 UI
    [SerializeField] private GameObject settingtUI; // 셋팅 UI
    [SerializeField] private GameObject resultUI; // 스테이지 선택 UI
    [SerializeField] private GameObject restartButton; // 재시작 버튼
    [SerializeField] private GameObject timeUI; // 시간 UI

    TimeUIHandler timeUIHandler;

    public static GameUIController Instance;

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

    private void Start()
    {
        timeUIHandler = gameObject.GetComponentInChildren<TimeUIHandler>(); // TimeUIHandler 컴포넌트 가져오기       
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
        settingtUI.SetActive(false); // 셋팅 UI 비활성화
        resultUI.SetActive(false); // 결과 UI 비활성화
        gameUI.SetActive(true); // 게임 UI 활성화
        GameManager.Instance.isSuccess = false; // 게임 성공 상태 초기화
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 씬 재시작
        timeUIHandler.playTime = 0f; // 플레이 시간 초기화
        settingtUI.SetActive(false); // 셋팅 UI 비활성화
        resultUI.SetActive(false); // 결과 UI 비활성화
        GameManager.Instance.isSuccess = false; // 게임 성공 상태 초기화
        GameManager.Instance.isPlayingGame = true; // 게임 진행
    }

    public void NextStage()
    {
        GameManager.Instance.isPlayingGame = true; // 게임 진행 시작
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // 현재 씬 인덱스
        SceneManager.LoadScene(currentSceneIndex + 1); // 다음 씬으로 이동
        settingtUI.SetActive(false); // 셋팅 UI 비활성화
        resultUI.SetActive(false); // 결과 UI 비활성화
        GameManager.Instance.opption1 = false; // 하트1 초기화
        GameManager.Instance.opption2 = false; // 하트2 초기화
        GameManager.Instance.opption3 = false; // 하트3 초기화
    }

    public void Result()
    {
        resultUI.SetActive(true); // 결과 UI 활성화    
        GameOverHandler.Instance.PrintResult(); // 결과 출력
    }

    public void StartOpttion()
    {
        Option.SetActive(true); // 옵션 UI 활성화
    }

    public void CloseOpttion()
    {
        Option.SetActive(false); // 옵션 UI 비활성화
    }

    public void ExitGame()
    {
        
    }
}

