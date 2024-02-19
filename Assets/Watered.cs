using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class Watered : MonoBehaviour
{
    public VirtualButtonBehaviour water;
    private const string lastWateredTimeKey = "PlantLastWateredTime";
    private float waterCooldown = 4f; // ��Ÿ�� ���� ȸ�� �� �ð����ϱ�@@@@@@@@@@@@@@@@@@2
    private PlantData plantData;
    public GameObject rainPrefab;
    public GameObject rainPosition;
    public GameObject badParticle;
    public GameObject buttonParticle;
    private void Start()
    {
        water.RegisterOnButtonPressed(CheckWaterCooldown);
        plantData = GetComponent<PlantData>();
    }

    private void CheckWaterCooldown(VirtualButtonBehaviour vb)
    {
        GameObject bp = Instantiate(buttonParticle, transform.position, Quaternion.identity);
        Destroy(bp, 3);
        Vector3 position = new Vector3(rainPosition.transform.position.x, rainPosition.transform.position.y + 8, rainPosition.transform.position.z);
        if (PlayerPrefs.HasKey(lastWateredTimeKey))
        {
                        
            System.TimeSpan elapsedTime = plantData.CalculateElapsedTime(lastWateredTimeKey);
            double coolTimeSeconds = waterCooldown * 3600 - elapsedTime.TotalSeconds; // ������ ��Ÿ�ӿ��� ���� �ð��� ���� ���� ��Ÿ�� ���
            System.TimeSpan coolTime2 = TimeSpan.FromSeconds(coolTimeSeconds); // �� ���� �����ָ� ��

            if (elapsedTime.TotalSeconds < waterCooldown )
            {
                Debug.Log("�� �ֱ�� ��Ÿ��");
            }
            else
            {
                // ��Ÿ���� ������ ���� �� �� �ִ� ����
                // ���⿡ ������ �� ȿ�� �����ϱ�
                GameObject rain = Instantiate(rainPrefab, position, Quaternion.identity);
                rain.transform.SetParent(rainPosition.transform);
                Destroy(rain, 5);
                badParticle.SetActive(false);
                Debug.Log("�� �ֱ�");
                plantData.SaveTime(lastWateredTimeKey);
            }
        }
        else
        {
            // ó�� ���� �� ��
            GameObject rain = Instantiate(rainPrefab, position, Quaternion.identity);
            rain.transform.SetParent(rainPosition.transform);
            Destroy(rain, 5);
            Debug.Log("�� �ֱ�");
            plantData.SaveTime(lastWateredTimeKey);
        }
    }
}
