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
            Debug.Log("SDK 초기화 완료");

            // 버전체크 -> 업데이트 코드

            // 구글 해시키 획득
            if (!Backend.Utils.GetGoogleHash().Equals(""))
                Debug.Log(Backend.Utils.GetGoogleHash());

            // 서버시간 획득
            Debug.Log(Backend.Utils.GetServerTime());
        }
        else
            Debug.LogError("Failed to initialize the backend");
    }
}
