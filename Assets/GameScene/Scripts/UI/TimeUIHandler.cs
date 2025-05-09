using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeUIHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timeText; // UI�� ǥ���� �ð� �ؽ�Ʈ

    public float playTime; // ���� ���� �ð�

    private void Update()
    {
        if (GameManager.Instance.isPlayingGame == false)
        {
            Time.timeScale = 0f; // ������ ������� ���� �� �ð� ����
        }
        else
        {
            Time.timeScale = 1f; // ������ ����� �� �ð� �帧
        }

        if (GameManager.Instance.isPlayingGame)
        {
            playTime += Time.deltaTime; // ���� ���� �ð� ������Ʈ
            UpdateTimeText(); // UI ������Ʈ
        }
    }

    private void UpdateTimeText()
    {
        int minutes = Mathf.FloorToInt(playTime / 60f);
        float seconds = playTime % 60f;
        timeText.text = $"{minutes:00}:{seconds:00.00}";
    }
}
