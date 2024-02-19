using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private const string creationTimeKey = "PlantCreationTime";
    private PlantData plantData;
    private int currentPlantLevel;
    private int currentLevel; // 현재 레벨 변수
    public GameObject plantObject; // 베이스 식물
    public GameObject[] plantObjectsByLevel; // 레벨 별 변화시킬 식물
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
            System.TimeSpan elapsedTime = plantData.CalculateElapsedTime(creationTimeKey); // 시간이 얼마나 지났는지 확인

            // 성장도 계산
            float growthRatePerHour = 0.1f; // 시간당 식물 성장도 지금 1시간당 10%임 회의 후 수치 정하기@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            float growthLevel = growthRatePerHour * (float)elapsedTime.TotalHours;

            // 레벨 증가 처리
            int maxLevel = 5; // 최대 레벨 설정 몇으로 할지 정하기 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
            int plantLevel = Mathf.FloorToInt(growthLevel); // 성장도의 소수점 아래 버림

            if (plantLevel >= maxLevel)
            {
                plantLevel = maxLevel;
                // 만렙 달성 추가적인 변화 처리 회의 해보기 @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@22
            }

            // 레벨 반환
            return plantLevel;
        }

        // 기본 레벨 반환 (예를 들어, 식물이 생성되지 않은 경우)
        return 0;
    }


    private void ChangePlantPerLevel(int currentPlantLevel)
    {
        // 레벨에 따른 추가 변화 처리
        switch (currentPlantLevel)
        {
            case 1:
                // 레벨 1의 변화 처리
                // 예시: 식물의 머티리얼을 변경하여 색상 변화 효과, 식물의 크기 변경, 외형 변화
                LevelUp(currentPlantLevel);
                Renderer plantRenderer = GetComponent<Renderer>();
                plantRenderer.material.color = Color.yellow;
                break;
            case 2:
                // 레벨 2의 변화 처리
                transform.localScale = new Vector3(1.5f, 1.5f, 1.5f); // 크기 변경
                break;
                // 여기에 레벨 별로 추가하기
        }
    }

    private void ChangePlantObjectType(int currentPlantLevel)
    {
        // 현재 식물 오브젝트를 비활성화
        plantObject.SetActive(false);

        // 현재 레벨에 해당하는 식물 오브젝트를 활성화
        GameObject newPlantObject = plantObjectsByLevel[currentPlantLevel];
        newPlantObject.SetActive(true);
         plantObject = newPlantObject;

    }


    public void LevelUp(int newLevel) // 렙업 하면 외형 변화
    {
        if (newLevel > currentLevel)
        {
            currentLevel = newLevel;
            ChangePlantObjectType(currentPlantLevel);
        }
    }
}
