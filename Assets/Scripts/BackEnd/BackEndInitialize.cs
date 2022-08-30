using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;

public class BackEndInitialize : MonoBehaviour
{
    private void Awake()
    {
        Backend.Initialize(HandleBackendCallback);
    }

    private void HandleBackendCallback()
    {
        if (Backend.IsInitialized)
        {
            Debug.Log("SDK �ʱ�ȭ �Ϸ�");

            // ����üũ -> ������Ʈ �ڵ�

            // ���� �ؽ�Ű ȹ��
            if (!Backend.Utils.GetGoogleHash().Equals(""))
                Debug.Log(Backend.Utils.GetGoogleHash());

            // �����ð� ȹ��
            Debug.Log(Backend.Utils.GetServerTime());
        }
        else
            Debug.LogError("Failed to initialize the backend");
    }
}
