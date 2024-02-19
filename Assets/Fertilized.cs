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
    private float fertilizeCooldown = 12f; // 쿨타임 설정 회의 후 시간정하기@@@@@@@@@@@@@@@@@@2
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
        Debug.Log("비료 누름");
        if (PlayerPrefs.HasKey(lastFertilizedTimeKey)) // 키 내부 값이 있는지 확인하는 거 처음인지 이전에 사용했는지
        {
            System.TimeSpan elapsedTime = plantData.CalculateElapsedTime(lastFertilizedTimeKey);  // 저장된 시간과 현재 시간을 비교하기
            double coolTimeSeconds = fertilizeCooldown * 3600 - elapsedTime.TotalSeconds; // 정해진 쿨타임에서 지난 시간을 빼서 남은 쿨타임 계산
            System.TimeSpan coolTime2 = TimeSpan.FromSeconds(coolTimeSeconds); // 이 값을 보여주면 됨

            if (elapsedTime.TotalSeconds < fertilizeCooldown * 3600 ) // 쿨타임 확인 해서 시간 지났으면 작동, 3600은 초 단위 쿨타임을 시간단위가 되도록 한거임
            {
                Debug.Log("비료주기는 쿨타임!");
                Debug.Log("남은 쿨타임은 = " + coolTime2);
            }
            else
            {
                // 쿨타임이 지나서 비료를 줄 수 있는 상태
                // 여기에 비료줬을 때 효과 구현하기
                FertilizedCount++;
                PlayerPrefs.SetInt(FertilizedCountKey, FertilizedCount);
                GameObject p = Instantiate(particle, particlePosition.transform.position, Quaternion.identity);
                Destroy(p, 3);
                Debug.Log("비료를 줬어요!");
                plantData.SaveTime(lastFertilizedTimeKey);

            }
        }
        else
        {
            // 처음 비료를 줄 때
            // 여기에 비료줬을 때 효과 구현하기
            FertilizedCount++;
            PlayerPrefs.SetInt(FertilizedCountKey, FertilizedCount);
            GameObject p = Instantiate(particle, particlePosition.transform.position, Quaternion.identity);
            Destroy(p, 3);
            Debug.Log("비료를 줬어요!");
            plantData.SaveTime(lastFertilizedTimeKey); 
        }
    }
}
