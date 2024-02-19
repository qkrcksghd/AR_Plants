using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class Fertilized : MonoBehaviour
{
    public VirtualButtonBehaviour fertilizer;
    private const string creationTimeKey = "PlantCreationTime";
    private const string lastFertilizedTimeKey = "PlantLastFertilizedTime";
    private float fertilizeCooldown = 12f; // 쿨타임 설정 회의 후 시간정하기@@@@@@@@@@@@@@@@@@2
    private PlantData plantData;
    private void Start()
    {
        fertilizer.RegisterOnButtonPressed(CheckFertilizeCooldown);
        plantData = GetComponent<PlantData>();
    }


    private void Update()
    {

       
        // 이거는 일단 확인을 위해 큐브 클릭 상황으로 만들어 논거 가상 버튼으로 옮기면 됨 CheckFertilizeCooldown(); 얘만


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
        //                CheckFertilizeCooldown();
        //            }
        //        }
        //    }
        //}
    }

    private void CheckFertilizeCooldown(VirtualButtonBehaviour vb)
    {
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
                Debug.Log("비료를 줬어요!");
                plantData.SaveTime(lastFertilizedTimeKey);
            }
        }
        else
        {
            // 처음 비료를 줄 때
            // 여기에 비료줬을 때 효과 구현하기
            Debug.Log("비료를 줬어요!");
            plantData.SaveTime(lastFertilizedTimeKey); 
        }
    }
}
