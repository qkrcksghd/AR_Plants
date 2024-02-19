using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CubeClickEvent : MonoBehaviour
{
    private const string CreationTimeKey = "PlantCreationTime";
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
                    // 큐브를 클릭한 경우 처리할 이벤트
                    HandleCubeClick();
                }
            }
        }
    }

    private void HandleCubeClick()
    {
        //아래 코드는 식물을 처음 생성 했을 때 저장하도록
        if (!PlayerPrefs.HasKey(CreationTimeKey))
        {
            // 현재 시간 저장
            PlayerPrefs.SetString(CreationTimeKey, System.DateTime.Now.ToString());
            PlayerPrefs.Save();
        }
        // 큐브 클릭 시 처리할 로직
        Debug.Log("Cube Clicked!");
    }
}
