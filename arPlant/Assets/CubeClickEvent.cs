using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CubeClickEvent : MonoBehaviour
{
    private const string CreationTimeKey = "PlantCreationTime";
    private void Update()
    {
        // ���콺 ���� ��ư�� ������ ��
        if (Input.GetMouseButtonDown(0))
        {
            // ���콺 ��ġ�κ��� Ray ����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Ray�� �浹�ϴ� ������Ʈ Ȯ��
            if (Physics.Raycast(ray, out hit))
            {
                // �浹�� ������Ʈ�� ť���� ���
                if (hit.collider.gameObject == gameObject)
                {
                    // ť�긦 Ŭ���� ��� ó���� �̺�Ʈ
                    HandleCubeClick();
                }
            }
        }
    }

    private void HandleCubeClick()
    {
        //�Ʒ� �ڵ�� �Ĺ��� ó�� ���� ���� �� �����ϵ���
        if (!PlayerPrefs.HasKey(CreationTimeKey))
        {
            // ���� �ð� ����
            PlayerPrefs.SetString(CreationTimeKey, System.DateTime.Now.ToString());
            PlayerPrefs.Save();
        }
        // ť�� Ŭ�� �� ó���� ����
        Debug.Log("Cube Clicked!");
    }
}
