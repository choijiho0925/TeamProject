using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float requiredStayTime = 3f; //클리어까지 문앞에 대기해야 하는시간, 애니메이션을 넣는다면 
    private float stayTimer = 0f; //문앞에 대기한 시간
    public LayerMask firePlayerLayer; //인스펙터에 퉁사후르 레이어 설정표시
    public Animator doorAnimation;

    private void Awake()
    {
        doorAnimation = GetComponentInChildren<Animator>();// 자식에 있는 animator 가져오기
    }
    private void OnTriggerStay2D(Collider2D collision)// 리지드바디 naverStop안키면 작동 안함
    {
            if ((firePlayerLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
                stayTimer += Time.deltaTime; // 대기시간 더해줌
                doorAnimation.SetBool("IsClear", true); //문열리는 애니메이션
            if (stayTimer > requiredStayTime)
            {
                GameManager.Instance.opption1 = true; // 하트1 활성화
                if (GameManager.Instance.stageCount == 1) { StageInformation.Instance.CheckStage1_1Time(); StageInformation.Instance.CheckStage1_1Item(); StageInformation.Instance.stage1_1Clear = true; }
                else if (GameManager.Instance.stageCount == 2) { StageInformation.Instance.CheckStage1_2Time(); StageInformation.Instance.CheckStage1_2Item(); StageInformation.Instance.stage1_2Clear = true; }
                else if (GameManager.Instance.stageCount == 3) { StageInformation.Instance.CheckStage2_1Time(); StageInformation.Instance.CheckStage2_1Item(); StageInformation.Instance.stage2_1Clear = true; }
                else if (GameManager.Instance.stageCount == 4) { StageInformation.Instance.CheckStage2_2Time(); StageInformation.Instance.CheckStage2_2Item(); StageInformation.Instance.stage2_2Clear = true; }
                GameManager.Instance.Clear();// 일정시간 대기하면 게임 클리어
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if ((firePlayerLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            stayTimer = 0f; // 나갈경우 대기시간 초기화
            doorAnimation.SetBool("IsClear", false);//문 닫힘
        }
    }
}
