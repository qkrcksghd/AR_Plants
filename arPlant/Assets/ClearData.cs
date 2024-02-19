using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearData : MonoBehaviour
{
    private const string creationTimeKey = "PlantCreationTime";
    private const string lastFertilizedTimeKey = "PlantLastFertilizedTime";
    private const string lastWateredTimeKey = "PlantLastWateredTime";
    private PlantData plantData;
    private void Start()
    {
        plantData = GetComponent<PlantData>();
    }
    private void Update()
    {
        // ���콺 ���� ��ư�� ������ ��
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 ��ġ�κ��� Ray ����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Ray�� �浹�ϴ� ������Ʈ Ȯ��
            if (Physics.Raycast(ray, out hit))
            {
                // �浹�� ������Ʈ�� ť���� ���
                if (hit.collider.gameObject == gameObject)
                {
                    // ���콺 Ŭ������ ���� ��ư �־ ������ �����ǵ��� �ϸ� �� ��
                    plantData.ResetPlantData();
                }
            }
        }
    }
}
