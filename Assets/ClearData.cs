using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearData : MonoBehaviour
{
    private const string creationTimeKey = "PlantCreationTime";
    public const string lastFertilizedTimeKey = "PlantLastFertilizedTime";
    public const string lastWateredTimeKey = "PlantLastWateredTime";
    public const string FertilizedCountKey = "FertilizedCount";
    public GameObject Gauge;
    public GameObject baseFlower;
    public GameObject badParticle;
    public GameObject p;

    public void ClickClear()
    {
        if (PlayerPrefs.HasKey(creationTimeKey))    //Ű���� ���� ���
        {
            PlayerPrefs.DeleteKey(creationTimeKey);
            PlayerPrefs.DeleteKey(lastFertilizedTimeKey);
            PlayerPrefs.DeleteKey(lastWateredTimeKey);
            PlayerPrefs.DeleteKey(FertilizedCountKey);
            //�� ���ӿ�����Ʈ ��� ��Ȱ��ȭ
            baseFlower.SetActive(false);
            Gauge.SetActive(false);
            badParticle.SetActive(false);
            p.SetActive(false);
            for (int i = 0; i < baseFlower.transform.childCount; i++)
            {
                baseFlower.transform.GetChild(i).gameObject.SetActive(false);
            }
        }
        else
        {// Debug.Log("���� ��"); 
        }

       
    }
}
