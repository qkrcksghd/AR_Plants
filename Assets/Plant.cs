 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private const string creationTimeKey = "PlantCreationTime";
    private const string lastWateredTimeKey = "PlantLastWateredTime";
    private const string FertilizedCountKey = "FertilizedCount";
    private int newLevel; // ���� ���� �� �� ���� ����
    private int currentLevel = 0; //���� ���� ����
    public int maxLevel = 2; // �ִ� ����
    private int FertilizedCount;
    private float growthLevel; //  �������� ���嵵
    private float growth; // ������ ���嵵
    public GameObject p;
    public GameObject badParticle;
    public GameObject basePlant; // ���̽� �Ĺ�
    public GameObject plantObject; // ���̽� �Ĺ�
    public GameObject[] plantObjectsByLevel; // ���� �� ��ȭ��ų �Ĺ�
    public ImgsFillDynamic ImgsFD;

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey(creationTimeKey))
        {
            System.DateTime currentTime = System.DateTime.Now;
            System.DateTime savedTime = System.DateTime.Parse(PlayerPrefs.GetString(creationTimeKey)); //����� ������ ���ڿ��� DateTime ��ü�� ��ȯ��Ŵ
            System.TimeSpan elapsedTime = currentTime - savedTime;  // ����� �ð��� ���� �ð��� ���ϱ�
            growth = CalculateGrowthLevel(elapsedTime);
            newLevel = CalculatePlantLevel(growth);
            ChangePlant(newLevel);
            growthLevel = CalculateGrowthLevel(elapsedTime);
            growthLevel = growthLevel - newLevel;
            if (newLevel >= maxLevel)   //�Ĺ� ���嵵�� 100% �ʰ� ����, �Ĺ��� �� �����ϸ� ������ ��ȭx
            { 
                growthLevel = 1f;
            }
            else
            {
                ImgsFD.SetValue(growthLevel, false);
                // UnityEngine.Debug.Log("���嵵 : " + growthGauge);
            }
            transform.localScale = new Vector3(1f + growthLevel, 1f + growthLevel, 1f + growthLevel); // ���嵵�� ���� ũ�� ����
        }
        
        if (PlayerPrefs.HasKey(lastWateredTimeKey))
        {
            System.DateTime currentTime = System.DateTime.Now;
            System.DateTime savedTime = System.DateTime.Parse(PlayerPrefs.GetString(lastWateredTimeKey)); //����� ������ ���ڿ��� DateTime ��ü�� ��ȯ��Ŵ
            System.TimeSpan WateredTime = currentTime - savedTime;  // ����� �ð��� ���� �ð��� ���ϱ�
            double WateredTimeSeconds = WateredTime.TotalSeconds;
            if (WateredTimeSeconds > 6 * 3600) // ���� �� ���� �ð��� ������ ���� ������ �г�Ƽ
            {
                badParticle.SetActive(true);
            }
        }

        
    }


    public float CalculateGrowthLevel(System.TimeSpan elapsedTime)
    {
        // ���嵵 ���
        FertilizedCount = PlayerPrefs.GetInt(FertilizedCountKey);
        float growthRatePerHour = 0.1f; // �ð��� �Ĺ� ���嵵 ���� 1�ð��� 10%�� ȸ�� �� ��ġ ���ϱ�@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        float growth = growthRatePerHour * (float)elapsedTime.TotalSeconds + 0.1f * FertilizedCount;
        return growth;
    }
    public int CalculatePlantLevel(float growth)
    {
        int plantLevel = Mathf.FloorToInt(growth); // ���嵵�� �Ҽ��� �Ʒ� ����

        if (plantLevel >= maxLevel)
        {
            plantLevel = maxLevel;
            //�����̸�
            p.SetActive(true);
        }
        // ���� ��ȯ
        return plantLevel;
    }


    private void ChangePlant(int currentPlantLevel)
    {
        // ������ ���� �߰� ��ȭ ó��
        switch (currentPlantLevel)
        {
            case 0:
                if (currentLevel < currentPlantLevel)
                {
                    ChangePlantObject(currentPlantLevel);
                }
                currentLevel = currentPlantLevel;
                break;
            case 1:
                // 1��
                if (currentLevel < currentPlantLevel)
                {
                    ChangePlantObject(currentPlantLevel);
                }
                currentLevel = currentPlantLevel;
                break;
            case 2:
                if (currentLevel < currentPlantLevel)
                {
                    ChangePlantObject(currentPlantLevel);
                }
                currentLevel = currentPlantLevel;
                plantObject = basePlant;
                break;
                // ���Ŀ� ���⿡ ���� ���� �߰��ϸ� ��
        }
    }

    private void ChangePlantObject(int currentLevel)
    {
        Debug.Log(currentLevel);
        plantObject.SetActive(false);
        // ���� �Ĺ� ������Ʈ�� ��Ȱ��ȭ
        GameObject newPlantObject = plantObjectsByLevel[currentLevel];
        newPlantObject.SetActive(true);
        plantObject = newPlantObject;
    }
}
