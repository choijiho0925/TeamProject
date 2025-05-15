using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField, Min(1)] private int count = 1;              // �������� ����
    [SerializeField] private GameObject onePrefab;     // ��ĭ ������Ʈ ������
    [SerializeField] private GameObject startPrefab;     // Start ������Ʈ ������
    [SerializeField] private GameObject middlePrefab;    // Middle ������Ʈ ������
    [SerializeField] private GameObject endPrefab;       // End ������Ʈ ������
    public ColorType flooringType; // �̳����� � �������� ����
    public LayerMask firePlayerLayer; // �����ĸ� ���̾� ����
    public LayerMask waterPlayerLayer;// Ÿ���ĸ� ���̾� ����
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        MakeChildGenerateObjects();
    }

    private void MakeChildGenerateObjects()
    {
        spriteRenderer.enabled = false; //���� �̹��� �Ⱥ��̰� ó��
        //spriteRenderer.color = spriteRenderer.color.WithAlpha(0f); //������ �Ⱥ��̰� �� ���� ������ �������� �κп��� �̻��

        if (count == 1)//��ĭ¥�� ����
        {
            GameObject oneObj = Instantiate(onePrefab, transform);
            InitializeFlooring(oneObj, Vector3.zero);
        }
        else
        {
            count = count - 2;
            // Start ����
            GameObject startObj = Instantiate(startPrefab, transform);
            InitializeFlooring(startObj, Vector3.zero);

            // Middle ����
            for (int i = 0; i < count; i++)
            {
                GameObject middleObj = Instantiate(middlePrefab, transform);
                InitializeFlooring(middleObj, new Vector3((i + 1) * 1f, 0, 0));
            }

            // End ����
            GameObject endObj = Instantiate(endPrefab, transform);
            InitializeFlooring(endObj, new Vector3((count + 1) * 1f, 0, 0));
        }
    }

    //�Է¹��� ���� ���� ��ü��� ����
    private void InitializeFlooring(GameObject obj, Vector3 position)
    {
        Flooring script = obj.GetComponent<Flooring>();
        script.flooringType = flooringType;
        script.firePlayerLayer = firePlayerLayer;
        script.waterPlayerLayer = waterPlayerLayer;
        obj.transform.localPosition = position;
    }
}
