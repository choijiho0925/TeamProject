using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverHandler : MonoBehaviour // �̱��� �ʹ� ����������
{
    [SerializeField] private List<Image> resultImageList = new List<Image>(); // �̹��� ����Ʈ
    [SerializeField] private List<Sprite> heartSpriteList = new List<Sprite>(); // ��Ʈ �̹��� ����Ʈ

    [SerializeField] private TextMeshProUGUI timeText; // ��� �ؽ�Ʈ
    [SerializeField] private TextMeshProUGUI titleText; // ���� �ؽ�Ʈ
    [SerializeField] private GameObject timeUI; // �ð� ����

    float playTime; // ���� ���� �ð�

    public static GameOverHandler Instance; // �̱��� �ν��Ͻ�

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this; // �̱��� �ν��Ͻ� ����
            DontDestroyOnLoad(Instance); // �� ��ȯ �� ������Ʈ ����
        }
        else
        {
            Destroy(Instance); // �ߺ��� �ν��Ͻ� ����
        }
        playTime = timeUI.GetComponent<TimeUIHandler>().playTime; // TimeUIHandler���� �÷��� �ð� ��������
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
