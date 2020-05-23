using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Part11_Test : MonoBehaviour
{
    [SerializeField] private Text txt_name;
    [SerializeField] private Image img_name;
    // 스프라이트는 이미지에  포함됨
    [SerializeField] private Sprite sprite;

    private bool isCoolTIme = false;
    private float currentTime = 5f;
    private float delayTime = 5f;

    private void Update()
    {
        Color color = img_name.color;
        // a -> 알파값
        color.a = 0f;
        img_name.color = color;

        if(isCoolTIme)
        {
            currentTime -= Time.deltaTime;
            // fillAmount -> 비율이라 0(최저) ~ 1(최고)
            img_name.fillAmount = currentTime / delayTime;

            if(currentTime <= 0)
            {
                isCoolTIme = false;
                currentTime = delayTime;
                img_name.fillAmount = currentTime;
            }
        }
    }

    public void Change()
    {
        txt_name.text = "변경됨";
        isCoolTIme = true;
    }
}
