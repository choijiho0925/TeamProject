using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float requiredStayTime = 2f; //클리어까지 문앞에 대기해야 하는시간, 애니메이션을 넣는다면 
    private float stayTimer = 0f; //문앞에 대기한 시간
    public LayerMask firePlayerLayer; //인스펙터에 퉁사후르 레이어 설정표시
    private void OnTriggerStay2D(Collider2D collision)// 리지드바디 naverStop안키면 작동 안함
    {
            if ((firePlayerLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
                stayTimer += Time.deltaTime; // 대기시간 더해줌
                Debug.Log(stayTimer);
                if (stayTimer > requiredStayTime)
                {
                    Debug.Log("작동 조건 충족");
                    //GameManager.Instance.Clear(); 클리어되는 함수
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision) // 나갈경우 대기시간 초기화
    {
        if ((firePlayerLayer.value & (1 << collision.gameObject.layer)) != 0)
        {
            stayTimer = 0f;
        }
    }

    //public void Clear() 게임매니저에 붙혀넣을 함수
    //{
    //    isSuccess = true;
    //    isPlayingGame = false;
    //    클리어 UI SetActive = true
    //}

    //public void Dead() 플레이어에 들어갈지 게임매니저에 들어갈지 미지수
    //{
    //    //플레이어 사망 애니메이션 출력
    //    Destroy(gameObject);
    //    isPlayingGame = false;
    //    실패 UI SetActive = true
    //}
}
