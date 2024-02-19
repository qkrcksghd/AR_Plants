using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class Create : MonoBehaviour
{
    public VirtualButtonBehaviour plant;
    private PlantData plantData;
    private const string creationTimeKey = "PlantCreationTime";
    private void Start()
    {
        plant.RegisterOnButtonPressed(clickPlant);
        plantData = GetComponent<PlantData>();
    }

    private void Update()
    {
     
        // ���콺 ���� ��ư�� ������ ��
        //if (Input.GetMouseButtonDown(0))
        //{
        //    // ���콺 ��ġ�κ��� Ray ����
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    // Ray�� �浹�ϴ� ������Ʈ Ȯ��
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        // �浹�� ������Ʈ�� ť���� ���
        //        if (hit.collider.gameObject == gameObject)
        //        {
        //            // ť�긦 Ŭ���� ��� ó���� �̺�Ʈ
        //            plantData.SaveTime(creationTimeKey); // �����ð� ����
        //            System.TimeSpan elapsedTime = plantData.CalculateElapsedTime(creationTimeKey); // ��� �ð� ���
        //            Debug.Log("Elapsed Time: " + elapsedTime);
        //        }
        //    }
        //}
    }

    public void clickPlant(VirtualButtonBehaviour vb)
    {
        // ť�긦 Ŭ���� ��� ó���� �̺�Ʈ
        plantData.SaveTime(creationTimeKey); // �����ð� ����
        System.TimeSpan elapsedTime = plantData.CalculateElapsedTime(creationTimeKey); // ��� �ð� ���
        //��Debug.Log("Elapsed Time: " + elapsedTime);
    }
}
