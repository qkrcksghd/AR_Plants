using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantData : MonoBehaviour
{
    public void SaveTime(string TimeKey) // 시간 저장하기
    {
        // 현재 시간 저장
        PlayerPrefs.SetString(TimeKey, System.DateTime.Now.ToString()); // DateTime을 스트링으로 변환하여 저장
        PlayerPrefs.Save();
    }

    public TimeSpan CalculateElapsedTime(string TimeKey) // 시간 비교해서 얼마나 지났는지 확인
    {
        System.DateTime currentTime = System.DateTime.Now;
        System.DateTime savedTime = System.DateTime.Parse(PlayerPrefs.GetString(TimeKey)); //저장된 데이터 문자열을 DateTime 객체로 변환시킴
        System.TimeSpan elapsedTime = currentTime - savedTime;  // 저장된 시간과 현재 시간을 비교하기
        return elapsedTime;
    }
}
