using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField, Min(1)] private int count = 1;              // 웅덩이의 길이
    [SerializeField] private GameObject onePrefab;     // 한칸 오브젝트 프리팹
    [SerializeField] private GameObject startPrefab;     // Start 오브젝트 프리팹
    [SerializeField] private GameObject middlePrefab;    // Middle 오브젝트 프리팹
    [SerializeField] private GameObject endPrefab;       // End 오브젝트 프리팹
    public ColorType flooringType; // 이넘으로 어떤 장판인지 설정
    public LayerMask firePlayerLayer; // 퉁사후르 레이어 설정
    public LayerMask waterPlayerLayer;// 타사후르 레이어 설정
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        MakeChildGenerateObjects();
    }

    private void MakeChildGenerateObjects()
    {
        spriteRenderer.enabled = false; //예시 이미지 안보이게 처리
        //spriteRenderer.color = spriteRenderer.color.WithAlpha(0f); //투명도로 안보이게 할 수도 있지만 성능적인 부분에서 미사용

        if (count == 1)//한칸짜리 생성
        {
            GameObject oneObj = Instantiate(onePrefab, transform);
            InitializeFlooring(oneObj, Vector3.zero);
        }
        else
        {
            count = count - 2;
            // Start 생성
            GameObject startObj = Instantiate(startPrefab, transform);
            InitializeFlooring(startObj, Vector3.zero);

            // Middle 생성
            for (int i = 0; i < count; i++)
            {
                GameObject middleObj = Instantiate(middlePrefab, transform);
                InitializeFlooring(middleObj, new Vector3((i + 1) * 1f, 0, 0));
            }

            // End 생성
            GameObject endObj = Instantiate(endPrefab, transform);
            InitializeFlooring(endObj, new Vector3((count + 1) * 1f, 0, 0));
        }
    }

    //입력받은 값을 하위 객체들로 전달
    private void InitializeFlooring(GameObject obj, Vector3 position)
    {
        Flooring script = obj.GetComponent<Flooring>();
        script.flooringType = flooringType;
        script.firePlayerLayer = firePlayerLayer;
        script.waterPlayerLayer = waterPlayerLayer;
        obj.transform.localPosition = position;
    }
}
