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
           // Debug.Log("�̹� ���� ��");
        }
        else
        {
            //����1 �� ����
            plantData.SaveTime(creationTimeKey); // �����ð� ����
            baseFlower.SetActive(true);
            Gauge.SetActive(true);
            baseFlower.transform.GetChild(0).gameObject.SetActive(true);
            // ť�긦 Ŭ���� ��� ó���� �̺�Ʈ
            
        }
    }
}
