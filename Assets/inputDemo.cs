using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //텍스트를 관리하는 라이브러리 추가
using System.Diagnostics;
using System;

public enum KeyType { None, GetKey, GeyButton, GetAxis, Mouse}
public class inputDemo : MonoBehaviour
{
    public Rigidbody myRb; //물리연산을 담당하는 기능 추가
    public KeyType keyType = KeyType.None; //키타입을 열거형으로 분리해서 관리하려고 함
    public TextMeshProUGUI InputValuese; //입력값을 텍스트 UI에 보이게 하려고 사용
    public float range;
    private void Start()
    {
        myRb = GetComponent<Rigidbody>(); //기능을 가져와서 사용할 준비를 해줌
    }
    //FixedUPdate는 프레임 호출 간격이 일정하여 물리연산이 들어간 이동또는 물리 전달계산에 사용되는 UPdate입니다.
    private void FixedUpdate()
    {
        bool _down = Input.GetKeyDown(KeyCode.Space);
        bool _Up = Input.GetKeyUp(KeyCode.Space);
        bool _Hold = Input.GetKeyUp(KeyCode.Space);

        bool _bDown = Input.GetButtonDown("Jump");
        bool _bUp = Input.GetButtonUp("Jump");
        bool _bHold = Input.GetButton("Jump");

        float h = Input.GetAxis("Horizontal");
        float xPos = h * range;
        InputValuese.text = "Value" + h.ToString("F2");
        switch (keyType)
        {
            case KeyType.None:
                break;
            case KeyType.GetKey:
                if (_down)
                {
                    myRb.AddForce(Vector3.up * 10f, ForceMode.Force);
                    print(_down);
                }
                else if (_Hold)
                {
                    myRb.AddForce(Vector3.up * 10f, ForceMode.Force);
                    print(_Hold);
                }
                else if (_Up)
                {
                    myRb.AddForce(Vector3.up * 10f, ForceMode.Force);
                    print(_Up);
                }
               

                break;
            case KeyType.GeyButton:

                 if (_bUp)
                {
                    myRb.AddForce(Vector3.up * 10f, ForceMode.Force);
                    print(_bUp);
                }
                else if (_bDown)
                {
                    myRb.AddForce(Vector3.up * 10f, ForceMode.Force);
                    print(_bDown);
                }
                else if (_bHold)
                {
                    myRb.AddForce(Vector3.up * 10f, ForceMode.Force);
                    print(_bHold);
                }
                break;
            case KeyType.GetAxis:
                transform.position = new Vector3(xPos, 2f, 0);
                break;
            case KeyType.Mouse:
                break;
            default:
                break;
                   
        }
        
    }
}
