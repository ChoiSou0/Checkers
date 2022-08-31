using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BackEnd;

public class BackEndAuthentication : MonoBehaviour
{
    public InputField idInput;
    public InputField palnInput;

    // ȸ������ ������
    public void OnClickSignUp()
    {
        // ȸ�� ������ �� �� ����� BackEndReturnObject Ÿ������ ��ȯ�Ѵ�.
        string error = Backend.BMember.CustomSignUp(idInput.text, palnInput.text, "Test1").GetErrorCode();

        // ȸ�� ���� ��� ó��
        switch(error)
        {
            case "DuplicatedParameterException":
                Debug.Log("�ߺ��� ���̵� �ֽ��ϴ�.");
                break;

            default:
                Debug.Log("ȸ�� ���� �Ϸ�");
                break;
        }

        Debug.Log("���� ���");
    }

    // �α��� ������
    public void OnClickLogin1()
    {
        string error = Backend.BMember.CustomLogin(idInput.text, palnInput.text).GetErrorCode();

        switch (error)
        {
            case "BadUnauthorizedException":
                Debug.Log("���̵� �Ǵ� ��й�ȣ�� Ʋ�ȴ�");
                break;

            case "BadPlayer":
                Debug.Log("���ܵ� ����");
                break;

            default:
                Debug.Log("�α��� �Ϸ�");
                break;
        }
    }

    public void AutoLogin()
    {
        string error = Backend.BMember.LoginWithTheBackendToken().GetErrorCode();

        switch (error)
        {
            case "GoneResourceException":
                break;

            case "BadUnauthorizedException":
                break;

            case "BadPlayer":
                break;

            default:
                break;
        }
    }
}
