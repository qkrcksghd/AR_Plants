using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class Watered : MonoBehaviour
{
    public VirtualButtonBehaviour water;
    private const string creationTimeKey = "PlantCreationTime";
    private const string lastWateredTimeKey = "PlantLastWateredTime";
    private float waterCooldown = 4f; // ��Ÿ�� ���� ȸ�� �� �ð����ϱ�@@@@@@@@@@@@@@@@@@2
    private PlantData plantData;
    private void Start()
    {
        water.RegisterOnButtonPressed(CheckWaterCooldown);
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
        //            if (PlayerPrefs.HasKey(creationTimeKey)) // �Ĺ��� �ɾ��� �ִ��� Ȯ��
        //            {
        //                CheckWaterCooldown();
        //            }
        //        }
        //    }
        //}
    }



    private void CheckWaterCooldown(VirtualButtonBehaviour vb)
    {
        if (PlayerPrefs.HasKey(lastWateredTimeKey))
        {
            System.TimeSpan elapsedTime = plantData.CalculateElapsedTime(lastWateredTimeKey);
            double coolTimeSeconds = waterCooldown * 3600 - elapsedTime.TotalSeconds; // ������ ��Ÿ�ӿ��� ���� �ð��� ���� ���� ��Ÿ�� ���
            System.TimeSpan coolTime2 = TimeSpan.FromSeconds(coolTimeSeconds); // �� ���� �����ָ� ��

            if (elapsedTime.TotalSeconds < waterCooldown * 3600)
            {
                Debug.Log("�� �ֱ�� ��Ÿ��");
            }
            else
            {
                // ��Ÿ���� ������ ���� �� �� �ִ� ����
                // ���⿡ ������ �� ȿ�� �����ϱ�
                Debug.Log("�� �ֱ�");
                plantData.SaveTime(lastWateredTimeKey);
            }
        }
        else
        {
            // ó�� ���� �� ��
            // ���⿡ ������ �� ȿ�� �����ϱ�
            Debug.Log("�� �ֱ�");
            plantData.SaveTime(lastWateredTimeKey);
        }
    }
}
