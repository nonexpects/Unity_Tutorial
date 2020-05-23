using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Part12_Test : MonoBehaviour
{
    [SerializeField]
    private Slider slider;

    private bool isClick;
    private float dotTime = 1f;
    private float currentDotTime = 0f;

    private void Start()
    {
        currentDotTime = dotTime;
    }

    public void Update()
    {
        if(isClick)
        {
            currentDotTime -= Time.deltaTime;
            
            if(currentDotTime<=0)
            {
                slider.value -= Time.deltaTime;

                if (currentDotTime <= -1f)
                {
                    currentDotTime = dotTime;
                }
            }
        }
        
    }

    public void Button()
    {
        isClick = true;
    }
}
