using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantData : MonoBehaviour
{
    public void SaveTime(string TimeKey) // �ð� �����ϱ�
    {
        // ���� �ð� ����
        PlayerPrefs.SetString(TimeKey, System.DateTime.Now.ToString()); // DateTime�� ��Ʈ������ ��ȯ�Ͽ� ����
        PlayerPrefs.Save();
    }

    public TimeSpan CalculateElapsedTime(string TimeKey) // �ð� ���ؼ� �󸶳� �������� Ȯ��
    {
        System.DateTime currentTime = System.DateTime.Now;
        System.DateTime savedTime = System.DateTime.Parse(PlayerPrefs.GetString(TimeKey)); //����� ������ ���ڿ��� DateTime ��ü�� ��ȯ��Ŵ
        System.TimeSpan elapsedTime = currentTime - savedTime;  // ����� �ð��� ���� �ð��� ���ϱ�
        return elapsedTime;
    }
}
