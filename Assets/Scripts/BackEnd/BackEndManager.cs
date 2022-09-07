using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BackEnd;

public class BackEndManager : MonoBehaviour
{
    private static BackEndManager instance = null;
    public static BackEndManager MyInstance { get => instance; set => instance = value; }


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        InitBackEnd();
    }

    private void InitBackEnd()
    {

        Backend.Initialize(BRO =>
        {
            Debug.Log("뒤끝 초기화 진행" + BRO);

            // 성공
            if (BRO.IsSuccess())
            {
                Debug.Log(Backend.Utils.GetServerTime());
            }

            // 실패
            else
            {
                ShowErrorUI(BRO);
            }
        });
    //    if (Backend.IsInitialized)
    //    {
    //        Debug.Log("SDK 초기화 완료");

    //        // 버전체크 -> 업데이트 코드

    //        // 구글 해시키 획득
    //        if (!Backend.Utils.GetGoogleHash().Equals(""))
    //            Debug.Log(Backend.Utils.GetGoogleHash());

    //        // 서버시간 획득
    //        Debug.Log(Backend.Utils.GetServerTime());
    //    }
    //    else
    //        Debug.LogError("Failed to initialize the backend");
    }

    public void ShowErrorUI(BackendReturnObject backendReturn)
    {
        int statusCode = int.Parse(backendReturn.GetStatusCode());

        switch (statusCode)
        {
            case 401:

                break;
        }
    }
}
