using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class Fertilized : MonoBehaviour
{
    public VirtualButtonBehaviour fertilizer;
    private const string lastFertilizedTimeKey = "PlantLastFertilizedTime";
    private const string FertilizedCountKey = "FertilizedCount";
    private float fertilizeCooldown = 12f; // ��Ÿ�� ���� ȸ�� �� �ð����ϱ�@@@@@@@@@@@@@@@@@@2
    private PlantData plantData;
    public GameObject particle;
    public GameObject particlePosition;
    public GameObject buttonParticle;
    private int FertilizedCount;
    private void Start()
    {
        fertilizer.RegisterOnButtonPressed(CheckFertilizeCooldown);
        plantData = GetComponent<PlantData>();
        FertilizedCount = PlayerPrefs.GetInt(FertilizedCountKey);
    }


    private void CheckFertilizeCooldown(VirtualButtonBehaviour vb)
    {
        GameObject bp = Instantiate(buttonParticle, transform.position, Quaternion.identity);
        Destroy(bp, 3);
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
                FertilizedCount++;
                PlayerPrefs.SetInt(FertilizedCountKey, FertilizedCount);
                GameObject p = Instantiate(particle, particlePosition.transform.position, Quaternion.identity);
                Destroy(p, 3);
                Debug.Log("��Ḧ ����!");
                plantData.SaveTime(lastFertilizedTimeKey);

            }
        }
        else
        {
            // ó�� ��Ḧ �� ��
            // ���⿡ ������� �� ȿ�� �����ϱ�
            FertilizedCount++;
            PlayerPrefs.SetInt(FertilizedCountKey, FertilizedCount);
            GameObject p = Instantiate(particle, particlePosition.transform.position, Quaternion.identity);
            Destroy(p, 3);
            Debug.Log("��Ḧ ����!");
            plantData.SaveTime(lastFertilizedTimeKey); 
        }
    }
}
