using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearData : MonoBehaviour
{
    private const string creationTimeKey = "PlantCreationTime";
    private const string lastFertilizedTimeKey = "PlantLastFertilizedTime";
    private const string lastWateredTimeKey = "PlantLastWateredTime";
    private PlantData plantData;
    private void Start()
    {
        plantData = GetComponent<PlantData>();
    }
    private void Update()
    {
        // 마우스 왼쪽 버튼이 눌렸을 때
        if (Input.GetMouseButtonDown(0))
        {
            // 마우스 위치로부터 Ray 생성
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Ray와 충돌하는 오브젝트 확인
            if (Physics.Raycast(ray, out hit))
            {
                // 충돌한 오브젝트가 큐브인 경우
                if (hit.collider.gameObject == gameObject)
                {
                    // 마우스 클릭으로 따로 버튼 넣어서 데이터 삭제되도록 하면 될 듯
                    plantData.ResetPlantData();
                }
            }
        }
    }
}
