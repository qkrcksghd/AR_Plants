using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class Create : MonoBehaviour
{
    public VirtualButtonBehaviour plant;
    private PlantData plantData;
    private const string creationTimeKey = "PlantCreationTime";
    private void Start()
    {
        plant.RegisterOnButtonPressed(clickPlant);
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
        //            // 큐브를 클릭한 경우 처리할 이벤트
        //            plantData.SaveTime(creationTimeKey); // 생성시간 저장
        //            System.TimeSpan elapsedTime = plantData.CalculateElapsedTime(creationTimeKey); // 경과 시간 계산
        //            Debug.Log("Elapsed Time: " + elapsedTime);
        //        }
        //    }
        //}
    }

    public void clickPlant(VirtualButtonBehaviour vb)
    {
        // 큐브를 클릭한 경우 처리할 이벤트
        plantData.SaveTime(creationTimeKey); // 생성시간 저장
        System.TimeSpan elapsedTime = plantData.CalculateElapsedTime(creationTimeKey); // 경과 시간 계산
        //ㄴDebug.Log("Elapsed Time: " + elapsedTime);
    }
}
