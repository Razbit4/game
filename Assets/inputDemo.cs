using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; //�ؽ�Ʈ�� �����ϴ� ���̺귯�� �߰�
using System.Diagnostics;
using System;

public enum KeyType { None, GetKey, GeyButton, GetAxis, Mouse}
public class inputDemo : MonoBehaviour
{
    public Rigidbody myRb; //���������� ����ϴ� ��� �߰�
    public KeyType keyType = KeyType.None; //ŰŸ���� ���������� �и��ؼ� �����Ϸ��� ��
    public TextMeshProUGUI InputValuese; //�Է°��� �ؽ�Ʈ UI�� ���̰� �Ϸ��� ���
    public float range;
    private void Start()
    {
        myRb = GetComponent<Rigidbody>(); //����� �����ͼ� ����� �غ� ����
    }
    //FixedUPdate�� ������ ȣ�� ������ �����Ͽ� ���������� �� �̵��Ǵ� ���� ���ް�꿡 ���Ǵ� UPdate�Դϴ�.
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
