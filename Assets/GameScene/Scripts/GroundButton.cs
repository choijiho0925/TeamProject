using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundButton : MonoBehaviour
{
    // Animator 파라미터 이름을 미리 해시로 변환해 캐싱 (성능 최적화)
    private static readonly int IsSwitch = Animator.StringToHash("IsSwitch");

    protected Animator animator;



    protected virtual void Awake()
    {
        // 애니메이터 컴포넌트를 자식에서 가져옴
        animator = GetComponentInChildren<Animator>();
    }


    public void GroundButtonSwitch()
    {
        // 레버 동작 상태 진입
        animator.SetBool(IsSwitch, true);
    }

    public void GroundButtonNoSwitch()
    {
        // 레버 비동작 상태 진입
        animator.SetBool(IsSwitch, false);
    }

    // Start is called before the first frame update
    void Start()
    {
        //테스트용
        GroundButtonSwitch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
