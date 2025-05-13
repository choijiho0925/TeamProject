using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    //이 버튼이 관리할 오브젝트를 리스트로 관리해서 한 번에 여러 개 작동 가능하도록 구현
    public List<GameObject> targetObjects;

    //버튼으로 관리할 오브젝트들은 IActivatable 인터페이스를 통해서 작동하니 이것도 리스트로 관리
    private List<IActivatable> activatables = new List<IActivatable>();

    // Animator 파라미터 이름을 미리 해시로 변환해 캐싱 (성능 최적화)
    private static readonly int IsSwitch = Animator.StringToHash("IsSwitch");

    //레버가 on/off 되어있는지 bool 값으로 관리
    private bool isActivated = false;

    //근처에 플레이어가 있어야 작동될 수 있도록 bool 값으로 확인
    private bool playerInRange = false;




    protected Animator animator;


    protected virtual void Awake()
    {
        // 애니메이터 컴포넌트를 자식에서 가져옴
        animator = GetComponentInChildren<Animator>();
    }

    public void LeverSwitch()
    {
        // 레버 동작 애니메이션 실행
        animator.SetBool(IsSwitch, true);
    }


    // Start is called before the first frame update
    // 단독으로 실행되는지 체크
    void Start()
    {
        foreach (var obj in targetObjects)
        {
            IActivatable a = obj.GetComponent<IActivatable>();
            if (a != null) activatables.Add(a);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))//플레이어가 근처에 있고 E키를 눌러서 실행
        {
            isActivated = !isActivated;

            foreach (var a in activatables)
            {
                if (isActivated) a.Activate();
                else a.Deactivate();
            }
            //작동 되었다면 애니메이션 실행
            LeverSwitch();
        }

    }


    //Player 태그 달린 얘가 근처에 있는지 없는지 확인
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어 닿음");
            playerInRange = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
            playerInRange = false;
    }
}
