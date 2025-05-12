using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageInformation : MonoBehaviour
{
    public static StageInformation Instance;

    [SerializeField] private List<Image> stage1_1ImageList = new List<Image>(); // 이미지 리스트
    [SerializeField] private List<Image> stage1_2ImageList = new List<Image>(); // 이미지 리스트
    [SerializeField] private List<Image> stage2_1ImageList = new List<Image>(); // 이미지 리스트
    [SerializeField] private List<Sprite> heartSpriteList = new List<Sprite>(); // 하트 이미지 리스트

    private float stage1_1HeartCount; // 스테이지 1-1 하트 개수
    private float stage1_2HeartCount; // 스테이지 1-2 하트 개수
    private float stage2_1HeartCount; // 스테이지 2-1 하트 개수
    private float beforeHeartCount; // 이전 하트 개수

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
        if (GameManager.Instance.stageCount == 1)
        {
            if(GameManager.Instance.opption1 == true)
            {
                stage1_1ImageList[0].sprite = heartSpriteList[0];
                stage1_1HeartCount = 1; // 하트 개수 설정
                if (GameManager.Instance.opption2 == true)
                {
                    stage1_1ImageList[1].sprite = heartSpriteList[0];
                    stage1_1HeartCount = 2; // 하트 개수 설정
                    if (GameManager.Instance.opption3 == true)
                    {
                        stage1_1ImageList[2].sprite = heartSpriteList[0];
                        stage1_1HeartCount = 3; // 하트 개수 설정
                    }
                }
                else
                {
                    if (GameManager.Instance.opption3 == true)
                    {
                        stage1_1ImageList[2].sprite = heartSpriteList[0];
                        stage1_1HeartCount = 2; // 하트 개수 설정
                    }
                }
            }
        }

        if (GameManager.Instance.stageCount == 2)
        {
            if (GameManager.Instance.opption1 == true)
            {
                stage1_2ImageList[0].sprite = heartSpriteList[0];
                stage1_2HeartCount = 1; // 하트 개수 설정
                if (GameManager.Instance.opption2 == true)
                {
                    stage1_2ImageList[1].sprite = heartSpriteList[0];
                    stage1_2HeartCount = 2; // 하트 개수 설정
                    if (GameManager.Instance.opption3 == true)
                    {
                        stage1_2ImageList[2].sprite = heartSpriteList[0];
                        stage1_2HeartCount = 3; // 하트 개수 설정
                    }
                }
                else
                {
                    if (GameManager.Instance.opption3 == true)
                    {
                        stage1_2ImageList[2].sprite = heartSpriteList[0];
                        stage1_2HeartCount = 2; // 하트 개수 설정
                    }
                }
            }
        }

        if (GameManager.Instance.stageCount == 3)
        {
            if (GameManager.Instance.opption1 == true)
            {
                stage2_1ImageList[0].sprite = heartSpriteList[0];
                stage2_1HeartCount = 1; // 하트 개수 설정
                if (GameManager.Instance.opption2 == true)
                {
                    stage2_1ImageList[1].sprite = heartSpriteList[0];
                    stage2_1HeartCount = 2; // 하트 개수 설정
                    if (GameManager.Instance.opption3 == true)
                    {
                        stage2_1ImageList[2].sprite = heartSpriteList[0];
                        stage2_1HeartCount = 3; // 하트 개수 설정
                    }
                }
                else
                {
                    if (GameManager.Instance.opption3 == true)
                    {
                        stage2_1ImageList[2].sprite = heartSpriteList[0];
                        stage2_1HeartCount = 2; // 하트 개수 설정
                    }
                }
            }
        }
    }
}