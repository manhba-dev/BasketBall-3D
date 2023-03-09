using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Awake()
    {
        
    }
    // Update is called once per frame
    //void Update()
    //{
    //    SetPower();
    //    // nhấn chuột xuống 0 ~ trái
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        SetPower(true);
    //    }
    //    // thoát chuột
    //    if (Input.GetMouseButtonUp(0))
    //    {
    //        SetPower(false);
    //    }
    //}

    ////void SetPower()
    ////{
    ////    // khi đã set lực và chwua nhảy lên
    ////    if (m_powerSetted && !m_didJump)
    ////    {


    ////        if (GameGUIManager.Ins.upToFill)
    ////        {
    ////            jumpForce.x += jumpForceUp.x * Time.deltaTime;
    ////            jumpForce.y += jumpForceUp.y * Time.deltaTime;

    ////            // giới hạn pos x và y
    ////            jumpForce.x = Mathf.Clamp(jumpForce.x, minForceX, maxForceX);
    ////            jumpForce.y = Mathf.Clamp(jumpForce.y, minForceY, maxForceY);

    ////            m_curPowerBarVal += GameManager.Ins.powerBarUp * Time.deltaTime;
    ////        }
    ////        else if (!GameGUIManager.Ins.upToFill)
    ////        {
    ////            jumpForce.x -= jumpForceUp.x * Time.deltaTime;
    ////            jumpForce.y -= jumpForceUp.y * Time.deltaTime;

    ////            // giới hạn pos x và y
    ////            jumpForce.x = Mathf.Clamp(jumpForce.x, minForceX, maxForceX);
    ////            jumpForce.y = Mathf.Clamp(jumpForce.y, minForceY, maxForceY);

    ////            m_curPowerBarVal -= GameManager.Ins.powerBarUp * Time.deltaTime;
    ////        }
    ////        GameGUIManager.Ins.UpdatePowerBar(m_curPowerBarVal, 1);


    ////    }
    //}

    //public void SetPower(bool isHoldingMouse)
    //{
    //    m_powerSetted = isHoldingMouse;

    //    if (!m_powerSetted && !m_didJump)
    //    {
    //        Jump();
    //    }
    //}

}
