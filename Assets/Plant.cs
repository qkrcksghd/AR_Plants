 using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant : MonoBehaviour
{
    private const string creationTimeKey = "PlantCreationTime";
    private const string lastWateredTimeKey = "PlantLastWateredTime";
    private const string FertilizedCountKey = "FertilizedCount";
    private int newLevel; // 렙업 했을 때 새 레벨 변수
    private int currentLevel = 0; //현재 레벨 변수
    public int maxLevel = 2; // 최대 레벨
    private int FertilizedCount;
    private float growthLevel; //  게이지용 성장도
    private float growth; // 레벨용 성장도
    public GameObject p;
    public GameObject badParticle;
    public GameObject basePlant; // 베이스 식물
    public GameObject plantObject; // 베이스 식물
    public GameObject[] plantObjectsByLevel; // 레벨 별 변화시킬 식물
    public ImgsFillDynamic ImgsFD;

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.HasKey(creationTimeKey))
        {
            System.DateTime currentTime = System.DateTime.Now;
            System.DateTime savedTime = System.DateTime.Parse(PlayerPrefs.GetString(creationTimeKey)); //저장된 데이터 문자열을 DateTime 객체로 변환시킴
            System.TimeSpan elapsedTime = currentTime - savedTime;  // 저장된 시간과 현재 시간을 비교하기
            growth = CalculateGrowthLevel(elapsedTime);
            newLevel = CalculatePlantLevel(growth);
            ChangePlant(newLevel);
            growthLevel = CalculateGrowthLevel(elapsedTime);
            growthLevel = growthLevel - newLevel;
            if (newLevel >= maxLevel)   //식물 성장도가 100% 초과 방지, 식물이 다 성장하면 게이지 변화x
            { 
                growthLevel = 1f;
            }
            else
            {
                ImgsFD.SetValue(growthLevel, false);
                // UnityEngine.Debug.Log("성장도 : " + growthGauge);
            }
            transform.localScale = new Vector3(1f + growthLevel, 1f + growthLevel, 1f + growthLevel); // 성장도에 따라 크기 변경
        }
        
        if (PlayerPrefs.HasKey(lastWateredTimeKey))
        {
            System.DateTime currentTime = System.DateTime.Now;
            System.DateTime savedTime = System.DateTime.Parse(PlayerPrefs.GetString(lastWateredTimeKey)); //저장된 데이터 문자열을 DateTime 객체로 변환시킴
            System.TimeSpan WateredTime = currentTime - savedTime;  // 저장된 시간과 현재 시간을 비교하기
            double WateredTimeSeconds = WateredTime.TotalSeconds;
            if (WateredTimeSeconds > 6 * 3600) // 만약 물 안준 시간이 오른쪽 값을 넘으면 패널티
            {
                badParticle.SetActive(true);
            }
        }

        
    }


    public float CalculateGrowthLevel(System.TimeSpan elapsedTime)
    {
        // 성장도 계산
        FertilizedCount = PlayerPrefs.GetInt(FertilizedCountKey);
        float growthRatePerHour = 0.1f; // 시간당 식물 성장도 지금 1시간당 10%임 회의 후 수치 정하기@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@
        float growth = growthRatePerHour * (float)elapsedTime.TotalSeconds + 0.1f * FertilizedCount;
        return growth;
    }
    public int CalculatePlantLevel(float growth)
    {
        int plantLevel = Mathf.FloorToInt(growth); // 성장도의 소수점 아래 버림

        if (plantLevel >= maxLevel)
        {
            plantLevel = maxLevel;
            //만렙이면
            p.SetActive(true);
        }
        // 레벨 반환
        return plantLevel;
    }


    private void ChangePlant(int currentPlantLevel)
    {
        // 레벨에 따른 추가 변화 처리
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
                // 1렙
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
                // 추후에 여기에 레벨 별로 추가하면 됨
        }
    }

    private void ChangePlantObject(int currentLevel)
    {
        Debug.Log(currentLevel);
        plantObject.SetActive(false);
        // 현재 식물 오브젝트를 비활성화
        GameObject newPlantObject = plantObjectsByLevel[currentLevel];
        newPlantObject.SetActive(true);
        plantObject = newPlantObject;
    }
}
