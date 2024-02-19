using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantData : MonoBehaviour
{
    public const string creationTimeKey = "PlantCreationTime";
    public const string lastFertilizedTimeKey = "PlantLastFertilizedTime";
    public const string lastWateredTimeKey = "PlantLastWateredTime";
    private const string WateredCountKey = "WateredCount";
    private const string FertilizedCountKey = "FertilizedCount";
    public void ResetPlantData() // ������ ����
    {
        PlayerPrefs.DeleteKey(creationTimeKey);
        PlayerPrefs.DeleteKey(lastFertilizedTimeKey);
        PlayerPrefs.DeleteKey(lastWateredTimeKey);
    }

    public void SaveTime(string TimeKey) // �ð� �����ϱ�
    {
        // ���� �ð� ����
        PlayerPrefs.SetString(TimeKey, System.DateTime.Now.ToString()); // DateTime�� ��Ʈ������ ��ȯ�Ͽ� ����
        PlayerPrefs.Save();
    }

    public TimeSpan CalculateElapsedTime(string TimeKey) // �ð� ���ؼ� �󸶳� �������� Ȯ��
    {
        if (PlayerPrefs.HasKey(TimeKey))
        {
            string Time = PlayerPrefs.GetString(TimeKey);
            System.DateTime currentTime = System.DateTime.Now;
            System.DateTime savedTime = System.DateTime.Parse(Time); //����� ������ ���ڿ��� DateTime ��ü�� ��ȯ��Ŵ
            System.TimeSpan elapsedTime = currentTime - savedTime;  // ����� �ð��� ���� �ð��� ���ϱ�
            Debug.Log("Elapsed Time: " + elapsedTime);
            return elapsedTime;
        }
        return default(TimeSpan); // ��ȯ�� �� ���� ��� TimeSpan.Zero ��ȯ
    }
}
