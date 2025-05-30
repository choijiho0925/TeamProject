using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour // 싱글톤 너무 막쓰지말기
{
    [Header("StartScene")]
    [SerializeField] private GameObject Option; // 옵션 UI

    [Header("GameUI")] 
    [SerializeField] private GameObject gameUI; // 게임 UI
    [SerializeField] private GameObject settingtUI; // 셋팅 UI
    [SerializeField] private GameObject resultUI; // 스테이지 선택 UI
    [SerializeField] public GameObject restartButton; // 재시작 버튼
    [SerializeField] public GameObject timeUI; // 시간 UI
    [SerializeField] public GameObject endRestartButton; // 재시작 버튼
    [SerializeField] public GameObject nextStageButton; // 다음스테이지 선택 버튼
    [SerializeField] public GameObject SoundUI; // 사운드 UI

    public int endSceneIndex = 5; // 마지막 씬 인덱스

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
        timeUIHandler = timeUI.GetComponent<TimeUIHandler>(); // TimeUIHandler 컴포넌트 가져오기
    }

    private void Start()
    {
          
    }

    private void Update()
    {

    }

    public void Setting()
    {
        timeUIHandler.StopTime(); // 시간 정지
        settingtUI.SetActive(true); // 셋팅 UI 활성화
    }

    public void Continue()
    {
        timeUIHandler.StartTime(); // 시간 시작
        settingtUI.SetActive(false); // 셋팅 UI 비활성화
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

    public void StageSelected()
    {
        SceneManager.LoadScene("StageScene"); // 스테이지 씬으로 이동
        settingtUI.SetActive(false); // 셋팅 UI 비활성화
        resultUI.SetActive(false); // 결과 UI 비활성화
        gameUI.SetActive(true); // 게임 UI 활성화
        restartButton.SetActive(false); // 재시작 버튼 비활성화
        timeUI.SetActive(false); // 시간 UI 비활성화
        GameManager.Instance.opption1 = false; // 하트1 초기화
        GameManager.Instance.opption2 = false; // 하트2 초기화
        GameManager.Instance.opption3 = false; // 하트3 초기화
        GameManager.Instance.isPlayingGame = false; // 게임 진행 중지
        GameManager.Instance.isSuccess = false; // 게임 성공 상태 초기화
        GameManager.Instance.isResult = false; // 결과창 비활성화
        GameManager.Instance.stageCount = 0; // 스테이지 카운트 초기화
        timeUIHandler.StartTime(); // 시간 시작
        timeUIHandler.playTime = 0f; // 플레이 시간 초기화
        Time.timeScale = 1; // 시간 스케일 초기화
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // 현재 씬 재시작
        timeUIHandler.playTime = 0f; // 플레이 시간 초기화
        settingtUI.SetActive(false); // 셋팅 UI 비활성화
        resultUI.SetActive(false); // 결과 UI 비활성화
        GameManager.Instance.opption1 = false; // 하트1 초기화
        GameManager.Instance.opption2 = false; // 하트2 초기화
        GameManager.Instance.opption3 = false; // 하트3 초기화
        GameManager.Instance.isSuccess = false; // 게임 성공 상태 초기화
        GameManager.Instance.isPlayingGame = true; // 게임 진행
        GameManager.Instance.isResult = false; // 결과창 비활성화
        StageInformation.Instance.ResetItemCount(); // 아이템 카운트 초기화
        Time.timeScale = 1; // 시간 스케일 초기화
    }

    public void NextStage()
    {
        GameManager.Instance.isPlayingGame = true; // 게임 진행 시작
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex; // 현재 씬 인덱스
        SceneManager.LoadScene(currentSceneIndex + 1); // 다음 씬으로 이동
        GameManager.Instance.stageCount++; // 스테이지 카운트 증가
        timeUIHandler.playTime = 0f; // 플레이 시간 초기화
        settingtUI.SetActive(false); // 셋팅 UI 비활성화
        resultUI.SetActive(false); // 결과 UI 비활성화
        GameManager.Instance.opption1 = false; // 하트1 초기화
        GameManager.Instance.opption2 = false; // 하트2 초기화
        GameManager.Instance.opption3 = false; // 하트3 초기화
        GameManager.Instance.isSuccess = false; // 게임 성공 상태 초기화
        GameManager.Instance.isResult = false; // 결과창 비활성화
        StageInformation.Instance.ResetItemCount(); // 아이템 카운트 초기화
        timeUIHandler.playTime = 0f;
        Time.timeScale = 1; // 시간 스케일 초기화
    }

    public void ExitGame()
    {
    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        // 빌드된 게임에서 실행 중일 경우
        Application.Quit();
    #endif
    }
}


