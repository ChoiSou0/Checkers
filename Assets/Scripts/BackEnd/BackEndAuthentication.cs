using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using BackEnd;

public class BackEndAuthentication : MonoBehaviour
{
    public InputField idInput;
    public InputField palnInput;

    // 회원가입 동기방식
    public void OnClickSignUp()
    {
        // 회원 가입을 한 뒤 결과를 BackEndReturnObject 타입으로 변환한다.
        string error = Backend.BMember.CustomSignUp(idInput.text, palnInput.text, "Test1").GetErrorCode();

        // 회원 가입 결과 처리
        switch(error)
        {
            case "DuplicatedParameterException":
                Debug.Log("중복된 아이디가 있습니다.");
                break;

            default:
                Debug.Log("회원 가입 완료");
                break;
        }

        Debug.Log("동기 방식");
    }

    // 로그인 동기방식
    public void OnClickLogin1()
    {
        string error = Backend.BMember.CustomLogin(idInput.text, palnInput.text).GetErrorCode();

        switch (error)
        {
            case "BadUnauthorizedException":
                Debug.Log("아이디 또는 비밀번호가 틀렸다");
                break;

            case "BadPlayer":
                Debug.Log("차단된 유저");
                break;

            default:
                Debug.Log("로그인 완료");
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
