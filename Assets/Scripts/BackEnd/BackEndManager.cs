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
            Debug.Log("�ڳ� �ʱ�ȭ ����" + BRO);

            // ����
            if (BRO.IsSuccess())
            {
                Debug.Log(Backend.Utils.GetServerTime());
            }

            // ����
            else
            {
                ShowErrorUI(BRO);
            }
        });
    //    if (Backend.IsInitialized)
    //    {
    //        Debug.Log("SDK �ʱ�ȭ �Ϸ�");

    //        // ����üũ -> ������Ʈ �ڵ�

    //        // ���� �ؽ�Ű ȹ��
    //        if (!Backend.Utils.GetGoogleHash().Equals(""))
    //            Debug.Log(Backend.Utils.GetGoogleHash());

    //        // �����ð� ȹ��
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
