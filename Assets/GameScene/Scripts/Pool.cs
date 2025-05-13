using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private int count = 3;              // Middle ������Ʈ ����
    [SerializeField] private GameObject startPrefab;     // Start ������Ʈ ������
    [SerializeField] private GameObject middlePrefab;    // Middle ������Ʈ ������
    [SerializeField] private GameObject endPrefab;       // End ������Ʈ ������
    public ColorType flooringType; // �̳����� � �������� ����
    public LayerMask firePlayerLayer; // �����ĸ� ���̾� ����
    public LayerMask waterPlayerLayer;// Ÿ���ĸ� ���̾� ����

    private void Start()
    {
        MakeChildGenerateObjects();
    }

    private void MakeChildGenerateObjects()
    {
        //start ����
        GameObject startObj = Instantiate(startPrefab, transform);
        Flooring startScript = startObj.GetComponent<Flooring>();
        startScript.flooringType = flooringType;
        startScript.firePlayerLayer = firePlayerLayer;
        startScript.waterPlayerLayer = waterPlayerLayer;
        startObj.transform.localPosition = Vector3.zero;
        
        //middle ����
        for (int i = 0; i < count; i++)
        {
            GameObject middleObj = Instantiate(middlePrefab, transform);
            Flooring middleScript = middleObj.GetComponent<Flooring>();
            middleScript.flooringType = flooringType;
            middleScript.firePlayerLayer = firePlayerLayer;
            middleScript.waterPlayerLayer = waterPlayerLayer;
            middleObj.transform.localPosition = new Vector3((i + 1) * 1f, 0, 0);
        }

        //end ����
        GameObject endObj = Instantiate(endPrefab, transform);
        Flooring endScript = endObj.GetComponent<Flooring>();
        endScript.flooringType = flooringType;
        endScript.firePlayerLayer = firePlayerLayer;
        endScript.waterPlayerLayer = waterPlayerLayer;
        endObj.transform.localPosition = new Vector3((count + 1) * 1f, 0, 0);
    }
}
