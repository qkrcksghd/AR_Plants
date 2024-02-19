using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
public class Create : MonoBehaviour
{
    public GameObject baseFlower;
    private PlantData plantData;
    public GameObject Gauge;
    private const string creationTimeKey = "PlantCreationTime";
    private void Start()
    {
        plantData = GetComponent<PlantData>();
    }

    public void clickPlant()
    {
        if (PlayerPrefs.HasKey(creationTimeKey))
        {
           // Debug.Log("이미 생성 됨");
        }
        else
        {
            //레벨1 꽃 생성
            plantData.SaveTime(creationTimeKey); // 생성시간 저장
            baseFlower.SetActive(true);
            Gauge.SetActive(true);
            baseFlower.transform.GetChild(0).gameObject.SetActive(true);
            // 큐브를 클릭한 경우 처리할 이벤트
            
        }
    }
}
