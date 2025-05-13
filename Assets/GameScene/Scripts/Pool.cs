using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private int count = 3;              // Middle 오브젝트 개수
    [SerializeField] private GameObject startPrefab;     // Start 오브젝트 프리팹
    [SerializeField] private GameObject middlePrefab;    // Middle 오브젝트 프리팹
    [SerializeField] private GameObject endPrefab;       // End 오브젝트 프리팹
    public ColorType flooringType; // 이넘으로 어떤 장판인지 설정
    public LayerMask firePlayerLayer; // 퉁사후르 레이어 설정
    public LayerMask waterPlayerLayer;// 타사후르 레이어 설정

    private void Start()
    {
        MakeChildGenerateObjects();
    }

    private void MakeChildGenerateObjects()
    {
        //start 생성
        GameObject startObj = Instantiate(startPrefab, transform);
        Flooring startScript = startObj.GetComponent<Flooring>();
        startScript.flooringType = flooringType;
        startScript.firePlayerLayer = firePlayerLayer;
        startScript.waterPlayerLayer = waterPlayerLayer;
        startObj.transform.localPosition = Vector3.zero;
        
        //middle 생성
        for (int i = 0; i < count; i++)
        {
            GameObject middleObj = Instantiate(middlePrefab, transform);
            Flooring middleScript = middleObj.GetComponent<Flooring>();
            middleScript.flooringType = flooringType;
            middleScript.firePlayerLayer = firePlayerLayer;
            middleScript.waterPlayerLayer = waterPlayerLayer;
            middleObj.transform.localPosition = new Vector3((i + 1) * 1f, 0, 0);
        }

        //end 생성
        GameObject endObj = Instantiate(endPrefab, transform);
        Flooring endScript = endObj.GetComponent<Flooring>();
        endScript.flooringType = flooringType;
        endScript.firePlayerLayer = firePlayerLayer;
        endScript.waterPlayerLayer = waterPlayerLayer;
        endObj.transform.localPosition = new Vector3((count + 1) * 1f, 0, 0);
    }
}
