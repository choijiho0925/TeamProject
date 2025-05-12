using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageInformation : MonoBehaviour
{
    public static StageInformation Instance;

    [SerializeField] private List<Image> stage1_1ImageList = new List<Image>(); // 이미지 리스트
    [SerializeField] private List<Image> stage1_2ImageList = new List<Image>(); // 이미지 리스트
    [SerializeField] private List<Image> stage2_1ImageList = new List<Image>(); // 이미지 리스트
    [SerializeField] private List<Image> stage2_2ImageList = new List<Image>(); // 이미지 리스트
    [SerializeField] private List<Sprite> heartSpriteList = new List<Sprite>(); // 하트 이미지 리스트

    [SerializeField] private TextMeshProUGUI totalHeartStage1;
    [SerializeField] private TextMeshProUGUI totalHeartStage2;

    private float stage1_1HeartCount; // 스테이지 1-1 하트 개수
    private float stage1_2HeartCount; // 스테이지 1-2 하트 개수
    private float stage2_1HeartCount; // 스테이지 2-1 하트 개수
    private float stage2_2HeartCount; // 스테이지 2-2 하트 개수
    private float stage1_1BestHeartCount; // 이전 플레이했던 게임중 최고 하트 개수
    private float stage1_2BestHeartCount; // 이전 플레이했던 게임중 최고 하트 개수
    private float stage2_1BestHeartCount; // 이전 플레이했던 게임중 최고 하트 개수
    private float stage2_2BestHeartCount; // 이전 플레이했던 게임중 최고 하트 개수

    public bool stage1_1Clear; // 1-1클리어 여부
    public bool stage1_2Clear; // 1-2클리어 여부
    public bool stage2_1Clear; // 2-1클리어 여부
    public bool stage2_2Clear; // 2-2클리어 여부

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

    private void Update()
    {
        totalHeartStage1.text = $"{stage1_1BestHeartCount + stage1_2BestHeartCount} / 6"; // 스테이지 1 총 하트 개수
        totalHeartStage2.text = $"{stage2_1BestHeartCount + stage2_2BestHeartCount} / 6"; // 스테이지 2 총 하트 개수
    }

    public void PrintStage1_1Heart()
    {
        if (GameManager.Instance.stageCount == 1 && GameManager.Instance.opption1)
        {
            // 하트 개수 계산
            stage1_1HeartCount = 1;
            stage1_1Clear = true;
            if (GameManager.Instance.opption2) stage1_1HeartCount++;
            if (GameManager.Instance.opption3) stage1_1HeartCount++;

            // 하트 이미지 설정
            if (stage1_1BestHeartCount < stage1_1HeartCount)
            {
                for (int i = 0; i < stage1_1HeartCount && i < stage1_1ImageList.Count; i++)
                {
                    stage1_1ImageList[i].sprite = heartSpriteList[0];
                }

                 stage1_1BestHeartCount = stage1_1HeartCount;
            }
        }
    }

    public void PrintStage1_2Heart()
    {
        if (GameManager.Instance.stageCount == 2 && GameManager.Instance.opption1)
        {
            // 하트 개수 계산
            stage1_2HeartCount = 1;
            stage1_2Clear = true;
            if (GameManager.Instance.opption2) stage1_2HeartCount++;
            if (GameManager.Instance.opption3) stage1_2HeartCount++;
            // 하트 이미지 설정
            if (stage1_2BestHeartCount < stage1_2HeartCount)
            {
                for (int i = 0; i < stage1_2HeartCount && i < stage1_2ImageList.Count; i++)
                {
                    stage1_2ImageList[i].sprite = heartSpriteList[0];
                }

                stage1_2BestHeartCount = stage1_2HeartCount;
            }
        }
    }

    public void PrintStage2_1Heart()
    {
        if (GameManager.Instance.stageCount == 3 && GameManager.Instance.opption1)
        {
            // 하트 개수 계산
            stage2_1HeartCount = 1;
            stage2_1Clear = true;
            if (GameManager.Instance.opption2) stage2_1HeartCount++;
            if (GameManager.Instance.opption3) stage2_1HeartCount++;
            // 하트 이미지 설정
            if (stage2_1BestHeartCount < stage2_1HeartCount)
            {
                for (int i = 0; i < stage2_1HeartCount && i < stage2_1ImageList.Count; i++)
                {
                    stage2_1ImageList[i].sprite = heartSpriteList[0];
                }
                stage2_1BestHeartCount = stage2_1HeartCount;
            }
        }
    }

    public void PrintStage2_2Heart()
    {
        if (GameManager.Instance.stageCount == 4 && GameManager.Instance.opption1)
        {
            // 하트 개수 계산
            stage2_2HeartCount = 1;
            stage2_2Clear = true;
            if (GameManager.Instance.opption2) stage2_2HeartCount++;
            if (GameManager.Instance.opption3) stage2_2HeartCount++;
            // 하트 이미지 설정
            if (stage2_2BestHeartCount < stage2_2HeartCount)
            {
                for (int i = 0; i < stage2_2HeartCount && i < stage2_1ImageList.Count; i++)
                {
                    stage2_1ImageList[i].sprite = heartSpriteList[0];
                }
                stage2_2BestHeartCount = stage2_2HeartCount;
            }
        }
    }
}