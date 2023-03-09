using Assets.Scripts;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameGUIManager : Singleton<GameGUIManager>
{
    public Image powerBarSlider;
    public bool upToFill = true;

    private void Awake()
    {
        MakeSingleton(false);
    }

    public void UpdatePowerBar(float curVal, float totalVal)
    {
        if (powerBarSlider)
        {
            if (upToFill)
            {
                powerBarSlider.fillAmount = curVal / totalVal;
                //Debug.Log(powerBarSlider.fillAmount);
                if (powerBarSlider.fillAmount >= 1)
                {
                    upToFill = false;
                }
            }
            else if (!upToFill)
            {
                powerBarSlider.fillAmount = curVal / totalVal;
                //Debug.Log(powerBarSlider.fillAmount);
                if (powerBarSlider.fillAmount <= 0)
                {
                    upToFill = true;
                }
            }
            //powerBarSlider.fillAmount = curVal;
            //if (upToFill == true)
            //{
            //    //Reduce fill amount over 30 seconds
            //    powerBarSlider.fillAmount = curVal / totalVal;
            //    //powerBarSlider.fillAmount += curVal / 10f * Time.deltaTime;
            //}

        }

    }
}
