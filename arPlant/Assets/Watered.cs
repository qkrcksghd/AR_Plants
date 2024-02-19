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
    private float waterCooldown = 4f; // 쿨타임 설정 회의 후 시간정하기@@@@@@@@@@@@@@@@@@2
    private PlantData plantData;
    private void Start()
    {
        water.RegisterOnButtonPressed(CheckWaterCooldown);
        plantData = GetComponent<PlantData>();
    }
    private void Update()
    {
       
        // 마우스 왼쪽 버튼이 눌렸을 때
        //if (Input.GetMouseButtonDown(0))
        //{
        //    // 마우스 위치로부터 Ray 생성
        //    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    RaycastHit hit;

        //    // Ray와 충돌하는 오브젝트 확인
        //    if (Physics.Raycast(ray, out hit))
        //    {
        //        // 충돌한 오브젝트가 큐브인 경우
        //        if (hit.collider.gameObject == gameObject)
        //        {
        //            if (PlayerPrefs.HasKey(creationTimeKey)) // 식물이 심어져 있는지 확인
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
            double coolTimeSeconds = waterCooldown * 3600 - elapsedTime.TotalSeconds; // 정해진 쿨타임에서 지난 시간을 빼서 남은 쿨타임 계산
            System.TimeSpan coolTime2 = TimeSpan.FromSeconds(coolTimeSeconds); // 이 값을 보여주면 됨

            if (elapsedTime.TotalSeconds < waterCooldown * 3600)
            {
                Debug.Log("물 주기는 쿨타임");
            }
            else
            {
                // 쿨타임이 지나서 물을 줄 수 있는 상태
                // 여기에 물줬을 때 효과 구현하기
                Debug.Log("물 주기");
                plantData.SaveTime(lastWateredTimeKey);
            }
        }
        else
        {
            // 처음 물을 줄 때
            // 여기에 물줬을 때 효과 구현하기
            Debug.Log("물 주기");
            plantData.SaveTime(lastWateredTimeKey);
        }
    }
}
