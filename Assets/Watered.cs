using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class Watered : MonoBehaviour
{
    public VirtualButtonBehaviour water;
    private const string lastWateredTimeKey = "PlantLastWateredTime";
    private float waterCooldown = 4f; // 쿨타임 설정 회의 후 시간정하기@@@@@@@@@@@@@@@@@@2
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
            double coolTimeSeconds = waterCooldown * 3600 - elapsedTime.TotalSeconds; // 정해진 쿨타임에서 지난 시간을 빼서 남은 쿨타임 계산
            System.TimeSpan coolTime2 = TimeSpan.FromSeconds(coolTimeSeconds); // 이 값을 보여주면 됨

            if (elapsedTime.TotalSeconds < waterCooldown )
            {
                Debug.Log("물 주기는 쿨타임");
            }
            else
            {
                // 쿨타임이 지나서 물을 줄 수 있는 상태
                // 여기에 물줬을 때 효과 구현하기
                GameObject rain = Instantiate(rainPrefab, position, Quaternion.identity);
                rain.transform.SetParent(rainPosition.transform);
                Destroy(rain, 5);
                badParticle.SetActive(false);
                Debug.Log("물 주기");
                plantData.SaveTime(lastWateredTimeKey);
            }
        }
        else
        {
            // 처음 물을 줄 때
            GameObject rain = Instantiate(rainPrefab, position, Quaternion.identity);
            rain.transform.SetParent(rainPosition.transform);
            Destroy(rain, 5);
            Debug.Log("물 주기");
            plantData.SaveTime(lastWateredTimeKey);
        }
    }
}
