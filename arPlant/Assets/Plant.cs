using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private const string creationTimeKey = "PlantCreationTime";
    private PlantData plantData;
    private int currentPlantLevel;
    private int currentLevel; // ���� ���� ����
    public GameObject plantObject; // ���̽� �Ĺ�
    public GameObject[] plantObjectsByLevel; // ���� �� ��ȭ��ų �Ĺ�
    private void Start()
    {
        plantData = GetComponent<PlantData>();
    }

    // Update is called once per frame
    void Update()
    {
        currentPlantLevel = CalculatePlantLevel(creationTimeKey);
        ChangePlantPerLevel(currentPlantLevel);
        currentLevel = CalculatePlantLevel(creationTimeKey);
    }

    public int CalculatePlantLevel(string creationTimeKey)
    {
        if (PlayerPrefs.HasKey(creationTimeKey))
        {
            System.TimeSpan elapsedTime = plantData.CalculateElapsedTime(creationTimeKey); // �ð��� �󸶳� �������� Ȯ��

            // ���嵵 ���
            float growthRatePerHour = 0.1f; // �ð��� �Ĺ� ���嵵 ���� 1�ð��� 10%�� ȸ�� �� ��ġ ���ϱ�@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            float growthLevel = growthRatePerHour * (float)elapsedTime.TotalHours;

            // ���� ���� ó��
            int maxLevel = 5; // �ִ� ���� ���� ������ ���� ���ϱ� @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            int plantLevel = Mathf.FloorToInt(growthLevel); // ���嵵�� �Ҽ��� �Ʒ� ����

            if (plantLevel >= maxLevel)
            {
                plantLevel = maxLevel;
                // ���� �޼� �߰����� ��ȭ ó�� ȸ�� �غ��� @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22
            }

            // ���� ��ȯ
            return plantLevel;
        }

        // �⺻ ���� ��ȯ (���� ���, �Ĺ��� �������� ���� ���)
        return 0;
    }


    private void ChangePlantPerLevel(int currentPlantLevel)
    {
        // ������ ���� �߰� ��ȭ ó��
        switch (currentPlantLevel)
        {
            case 1:
                // ���� 1�� ��ȭ ó��
                // ����: �Ĺ��� ��Ƽ������ �����Ͽ� ���� ��ȭ ȿ��, �Ĺ��� ũ�� ����, ���� ��ȭ
                LevelUp(currentPlantLevel);
                Renderer plantRenderer = GetComponent<Renderer>();
                plantRenderer.material.color = Color.yellow;
                break;
            case 2:
                // ���� 2�� ��ȭ ó��
                transform.localScale = new Vector3(1.5f, 1.5f, 1.5f); // ũ�� ����
                break;
                // ���⿡ ���� ���� �߰��ϱ�
        }
    }

    private void ChangePlantObjectType(int currentPlantLevel)
    {
        // ���� �Ĺ� ������Ʈ�� ��Ȱ��ȭ
        plantObject.SetActive(false);

        // ���� ������ �ش��ϴ� �Ĺ� ������Ʈ�� Ȱ��ȭ
        GameObject newPlantObject = plantObjectsByLevel[currentPlantLevel];
        newPlantObject.SetActive(true);
         plantObject = newPlantObject;

    }


    public void LevelUp(int newLevel) // ���� �ϸ� ���� ��ȭ
    {
        if (newLevel > currentLevel)
        {
            currentLevel = newLevel;
            ChangePlantObjectType(currentPlantLevel);
        }
    }
}
