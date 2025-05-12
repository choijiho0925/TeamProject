using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageInformation : MonoBehaviour
{
    public static StageInformation Instance;

    [SerializeField] private List<Image> stage1_1ImageList = new List<Image>(); // �̹��� ����Ʈ
    [SerializeField] private List<Image> stage1_2ImageList = new List<Image>(); // �̹��� ����Ʈ
    [SerializeField] private List<Image> stage2_1ImageList = new List<Image>(); // �̹��� ����Ʈ
    [SerializeField] private List<Image> stage2_2ImageList = new List<Image>(); // �̹��� ����Ʈ
    [SerializeField] private List<Sprite> heartSpriteList = new List<Sprite>(); // ��Ʈ �̹��� ����Ʈ

    [SerializeField] private TextMeshProUGUI totalHeartStage1;
    [SerializeField] private TextMeshProUGUI totalHeartStage2;

    private float stage1_1HeartCount; // �������� 1-1 ��Ʈ ����
    private float stage1_2HeartCount; // �������� 1-2 ��Ʈ ����
    private float stage2_1HeartCount; // �������� 2-1 ��Ʈ ����
    private float stage2_2HeartCount; // �������� 2-2 ��Ʈ ����
    private float stage1_1BestHeartCount; // ���� �÷����ߴ� ������ �ְ� ��Ʈ ����
    private float stage1_2BestHeartCount; // ���� �÷����ߴ� ������ �ְ� ��Ʈ ����
    private float stage2_1BestHeartCount; // ���� �÷����ߴ� ������ �ְ� ��Ʈ ����
    private float stage2_2BestHeartCount; // ���� �÷����ߴ� ������ �ְ� ��Ʈ ����

    public bool stage1_1Clear; // 1-1Ŭ���� ����
    public bool stage1_2Clear; // 1-2Ŭ���� ����
    public bool stage2_1Clear; // 2-1Ŭ���� ����
    public bool stage2_2Clear; // 2-2Ŭ���� ����

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
    }

    private void Update()
    {
        totalHeartStage1.text = $"{stage1_1BestHeartCount + stage1_2BestHeartCount} / 6"; // �������� 1 �� ��Ʈ ����
        totalHeartStage2.text = $"{stage2_1BestHeartCount + stage2_2BestHeartCount} / 6"; // �������� 2 �� ��Ʈ ����
    }

    public void PrintStage1_1Heart()
    {
        if (GameManager.Instance.stageCount == 1 && GameManager.Instance.opption1)
        {
            // ��Ʈ ���� ���
            stage1_1HeartCount = 1;
            stage1_1Clear = true;
            if (GameManager.Instance.opption2) stage1_1HeartCount++;
            if (GameManager.Instance.opption3) stage1_1HeartCount++;

            // ��Ʈ �̹��� ����
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
            // ��Ʈ ���� ���
            stage1_2HeartCount = 1;
            stage1_2Clear = true;
            if (GameManager.Instance.opption2) stage1_2HeartCount++;
            if (GameManager.Instance.opption3) stage1_2HeartCount++;
            // ��Ʈ �̹��� ����
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
            // ��Ʈ ���� ���
            stage2_1HeartCount = 1;
            stage2_1Clear = true;
            if (GameManager.Instance.opption2) stage2_1HeartCount++;
            if (GameManager.Instance.opption3) stage2_1HeartCount++;
            // ��Ʈ �̹��� ����
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
            // ��Ʈ ���� ���
            stage2_2HeartCount = 1;
            stage2_2Clear = true;
            if (GameManager.Instance.opption2) stage2_2HeartCount++;
            if (GameManager.Instance.opption3) stage2_2HeartCount++;
            // ��Ʈ �̹��� ����
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