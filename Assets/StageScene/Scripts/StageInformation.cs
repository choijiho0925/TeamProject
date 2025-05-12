using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageInformation : MonoBehaviour
{
    public static StageInformation Instance;

    [SerializeField] private List<Image> stage1_1ImageList = new List<Image>(); // �̹��� ����Ʈ
    [SerializeField] private List<Image> stage1_2ImageList = new List<Image>(); // �̹��� ����Ʈ
    [SerializeField] private List<Image> stage2_1ImageList = new List<Image>(); // �̹��� ����Ʈ
    [SerializeField] private List<Sprite> heartSpriteList = new List<Sprite>(); // ��Ʈ �̹��� ����Ʈ

    private float stage1_1HeartCount; // �������� 1-1 ��Ʈ ����
    private float stage1_2HeartCount; // �������� 1-2 ��Ʈ ����
    private float stage2_1HeartCount; // �������� 2-1 ��Ʈ ����
    private float beforeHeartCount; // ���� ��Ʈ ����

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
        if (GameManager.Instance.stageCount == 1)
        {
            if(GameManager.Instance.opption1 == true)
            {
                stage1_1ImageList[0].sprite = heartSpriteList[0];
                stage1_1HeartCount = 1; // ��Ʈ ���� ����
                if (GameManager.Instance.opption2 == true)
                {
                    stage1_1ImageList[1].sprite = heartSpriteList[0];
                    stage1_1HeartCount = 2; // ��Ʈ ���� ����
                    if (GameManager.Instance.opption3 == true)
                    {
                        stage1_1ImageList[2].sprite = heartSpriteList[0];
                        stage1_1HeartCount = 3; // ��Ʈ ���� ����
                    }
                }
                else
                {
                    if (GameManager.Instance.opption3 == true)
                    {
                        stage1_1ImageList[2].sprite = heartSpriteList[0];
                        stage1_1HeartCount = 2; // ��Ʈ ���� ����
                    }
                }
            }
        }

        if (GameManager.Instance.stageCount == 2)
        {
            if (GameManager.Instance.opption1 == true)
            {
                stage1_2ImageList[0].sprite = heartSpriteList[0];
                stage1_2HeartCount = 1; // ��Ʈ ���� ����
                if (GameManager.Instance.opption2 == true)
                {
                    stage1_2ImageList[1].sprite = heartSpriteList[0];
                    stage1_2HeartCount = 2; // ��Ʈ ���� ����
                    if (GameManager.Instance.opption3 == true)
                    {
                        stage1_2ImageList[2].sprite = heartSpriteList[0];
                        stage1_2HeartCount = 3; // ��Ʈ ���� ����
                    }
                }
                else
                {
                    if (GameManager.Instance.opption3 == true)
                    {
                        stage1_2ImageList[2].sprite = heartSpriteList[0];
                        stage1_2HeartCount = 2; // ��Ʈ ���� ����
                    }
                }
            }
        }

        if (GameManager.Instance.stageCount == 3)
        {
            if (GameManager.Instance.opption1 == true)
            {
                stage2_1ImageList[0].sprite = heartSpriteList[0];
                stage2_1HeartCount = 1; // ��Ʈ ���� ����
                if (GameManager.Instance.opption2 == true)
                {
                    stage2_1ImageList[1].sprite = heartSpriteList[0];
                    stage2_1HeartCount = 2; // ��Ʈ ���� ����
                    if (GameManager.Instance.opption3 == true)
                    {
                        stage2_1ImageList[2].sprite = heartSpriteList[0];
                        stage2_1HeartCount = 3; // ��Ʈ ���� ����
                    }
                }
                else
                {
                    if (GameManager.Instance.opption3 == true)
                    {
                        stage2_1ImageList[2].sprite = heartSpriteList[0];
                        stage2_1HeartCount = 2; // ��Ʈ ���� ����
                    }
                }
            }
        }
    }
}