using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    // Animator 파라미터 이름을 미리 해시로 변환해 캐싱 (성능 최적화)
    private static readonly int IsSwitch = Animator.StringToHash("IsSwitch");

    protected Animator animator;


    protected virtual void Awake()
    {
        // 애니메이터 컴포넌트를 자식에서 가져옴
        animator = GetComponentInChildren<Animator>();
    }

    public void LeverSwitch()
    {
        // 레버 동작 상태 진입
        animator.SetBool(IsSwitch, true);
    }


    // Start is called before the first frame update
    // 단독으로 실행되는지 체크
    void Start()
    {
        LeverSwitch();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
