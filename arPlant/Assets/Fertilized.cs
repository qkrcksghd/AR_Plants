using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class Fertilized : MonoBehaviour
{
    public VirtualButtonBehaviour fertilizer;
    private const string creationTimeKey = "PlantCreationTime";
    private const string lastFertilizedTimeKey = "PlantLastFertilizedTime";
    private float fertilizeCooldown = 12f; // ��Ÿ�� ���� ȸ�� �� �ð����ϱ�@@@@@@@@@@@@@@@@@@2
    private PlantData plantData;
    private void Start()
    {
        fertilizer.RegisterOnButtonPressed(CheckFertilizeCooldown);
        plantData = GetComponent<PlantData>();
    }


    private void Update()
    {

       
        // �̰Ŵ� �ϴ� Ȯ���� ���� ť�� Ŭ�� ��Ȳ���� ����� ��� ���� ��ư���� �ű�� �� CheckFertilizeCooldown(); �길


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
        //            if (PlayerPrefs.HasKey(creationTimeKey)) // �Ĺ��� �ɾ��� �ִ��� Ȯ��
        //            {
        //                CheckFertilizeCooldown();
        //            }
        //        }
        //    }
        //}
    }

    private void CheckFertilizeCooldown(VirtualButtonBehaviour vb)
    {
        Debug.Log("��� ����");
        if (PlayerPrefs.HasKey(lastFertilizedTimeKey)) // Ű ���� ���� �ִ��� Ȯ���ϴ� �� ó������ ������ ����ߴ���
        {
            System.TimeSpan elapsedTime = plantData.CalculateElapsedTime(lastFertilizedTimeKey);  // ����� �ð��� ���� �ð��� ���ϱ�
            double coolTimeSeconds = fertilizeCooldown * 3600 - elapsedTime.TotalSeconds; // ������ ��Ÿ�ӿ��� ���� �ð��� ���� ���� ��Ÿ�� ���
            System.TimeSpan coolTime2 = TimeSpan.FromSeconds(coolTimeSeconds); // �� ���� �����ָ� ��

            if (elapsedTime.TotalSeconds < fertilizeCooldown * 3600 ) // ��Ÿ�� Ȯ�� �ؼ� �ð� �������� �۵�, 3600�� �� ���� ��Ÿ���� �ð������� �ǵ��� �Ѱ���
            {
                Debug.Log("����ֱ�� ��Ÿ��!");
                Debug.Log("���� ��Ÿ���� = " + coolTime2);
            }
            else
            {
                // ��Ÿ���� ������ ��Ḧ �� �� �ִ� ����
                // ���⿡ ������� �� ȿ�� �����ϱ�
                Debug.Log("��Ḧ ����!");
                plantData.SaveTime(lastFertilizedTimeKey);
            }
        }
        else
        {
            // ó�� ��Ḧ �� ��
            // ���⿡ ������� �� ȿ�� �����ϱ�
            Debug.Log("��Ḧ ����!");
            plantData.SaveTime(lastFertilizedTimeKey); 
        }
    }
}
