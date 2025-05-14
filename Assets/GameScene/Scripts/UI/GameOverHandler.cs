using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour // 싱글톤 너무 막쓰지말기
{
    [SerializeField] private List<Image> resultImageList = new List<Image>(); // 이미지 리스트
    [SerializeField] private List<Sprite> heartSpriteList = new List<Sprite>(); // 하트 이미지 리스트

    [SerializeField] private TextMeshProUGUI timeText; // 결과 텍스트
    [SerializeField] private TextMeshProUGUI titleText; // 제목 텍스트
    [SerializeField] private GameObject timeUI; // 시간 정보

    float playTime; // 게임 진행 시간

    public static GameOverHandler Instance; // 싱글톤 인스턴스

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // 싱글톤 인스턴스 설정
            DontDestroyOnLoad(Instance); // 씬 전환 시 오브젝트 유지
        }
        else
        {
            Destroy(Instance); // 중복된 인스턴스 삭제
        }
        playTime = timeUI.GetComponent<TimeUIHandler>().playTime; // TimeUIHandler에서 플레이 시간 가져오기
    }

    private void start()
    {
        //resultuireset();
    }

    public void PrintResult()
    {
        int minutes = Mathf.FloorToInt(playTime / 60f);
        float seconds = playTime % 60f;

        if (GameManager.Instance.opption1)
        {
            titleText.text = "Game Clear!";
            PrintHeartImage();
            timeText.text = $"Clear Within : {minutes: 00}:{seconds: 00.00}";
        }
        else
        {
            titleText.text = "Game Over...";
            PrintHeartImage();
            timeText.text = $"Clear Within : {minutes: 00}:{seconds: 00.00}"
            ;
        }
    }

    //private void ResultUIReset()
    //{
    //    for (int i = 0; i < resultImageList.Count; i++)
    //    {
    //        resultImageList[i].gameObject.SetActive(false);
    //    }
    //}

    public void PrintHeartImage()
    {
        if (GameManager.Instance.opption1)
        {
            resultImageList[0].sprite = heartSpriteList[0];

            if (GameManager.Instance.opption2) resultImageList[1].sprite = heartSpriteList[0];
            else resultImageList[1].sprite = heartSpriteList[1];

            if (GameManager.Instance.opption3) resultImageList[2].sprite = heartSpriteList[0];
            else resultImageList[2].sprite = heartSpriteList[1];
        }
        else
        {
            resultImageList[0].sprite = heartSpriteList[1];
            resultImageList[1].sprite = heartSpriteList[1];

            if (GameManager.Instance.opption3) resultImageList[2].sprite = heartSpriteList[2];
            else resultImageList[2].sprite = heartSpriteList[1];
        }
    }
}
