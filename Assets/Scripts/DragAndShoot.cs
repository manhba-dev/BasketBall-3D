using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class DragAndShoot : MonoBehaviour
{
    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;

    private Rigidbody rb;

    private bool isShoot;

    bool m_powerSetted;
    public float m_curPowerBarVal = 0;
    public float force = 2;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {

        SetPower();
        // nhấn chuột xuống 0 ~ trái
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SetPower(true);
        }
        // thoát chuột
        if (Input.GetKeyUp(KeyCode.Space))
        {
            forceMultiplier = GameGUIManager.Ins.powerBarSlider.fillAmount * force;
            SetPower(false);
        }
    }

    void SetPower()
    {
        // khi đã set lực và chwua nhảy lên
        if (m_powerSetted)
        {


            if (GameGUIManager.Ins.upToFill)
            {
                m_curPowerBarVal += 1f * Time.deltaTime;
            }
            else if (!GameGUIManager.Ins.upToFill)
            {
                m_curPowerBarVal -= 1f * Time.deltaTime;
            }
            Debug.Log(m_curPowerBarVal);
            GameGUIManager.Ins.UpdatePowerBar(m_curPowerBarVal, 1);


        }
    }

    public void SetPower(bool isHoldingMouse)
    {
        m_powerSetted = isHoldingMouse;

        if (!m_powerSetted)
        {
            Shoot(mouseReleasePos - mousePressDownPos);
        }
    }

    private void OnMouseDown()
    {
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseUp()
    {
        //DrawTrajectory.Instance.HideLine();
        mouseReleasePos = Input.mousePosition;
        //Shoot(mouseReleasePos - mousePressDownPos);
    }

    private void OnMouseDrag()
    {
        Vector3 forceInit = (Input.mousePosition - mousePressDownPos);
        Vector3 forceV = (new Vector3(forceInit.x,forceInit.y,forceInit.y))*1f;

        if (!isShoot)
        {
            DrawTrajectory.Instance.UpdateTrajectory(forceV, rb, transform.position);
        }
        OnMouseUp();
    }


    private float forceMultiplier = 1f;
    void Shoot(Vector3 Force)
    {
        if (isShoot)
            return;
        rb.AddForce(new Vector3(Force.x, Force.y, Force.y) * forceMultiplier);
        isShoot = true;

        Spawner.Instance.NewSpawnRequest();
    }

}