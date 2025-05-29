using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class Status : MonoBehaviour
{
    public int currentValue;
    public int startValue;
    public int maxValue;
    public int passiveValue;

    public Image statBar;
    public TMP_Text statText;

    private void Start()
    {
        currentValue = startValue;

        float result = (float)currentValue / (float)maxValue;
        statBar.fillAmount = result;
        statText.text = $"{((int)(result * 100))}%";
    }
    
    //UI이미지 업데이트용 이미지 바 비율

    //public void Add(int value)
    //{
    //    currentValue = Mathf.Min(currentValue + value, maxValue); //둘 중 작은 값을 현재 값으로 사용
    //    float result = currentValue / maxValue;
    //    statBar.fillAmount = result;
    //    statText.text = $"{((int)(result * 100))}%";
    //}

    //public void Subtract(int value)
    //{
    //    currentValue = Mathf.Max(currentValue - value, 0);
    //    float result = currentValue / maxValue;
    //    statBar.fillAmount = result;
    //    statText.text = $"{((int)(result * 100))}%";

    //}

    public void StatChange(int value, string choice)
    {
        switch (choice)
        {
            case "Add":
                currentValue = Mathf.Min(currentValue + value, maxValue);
                break;

            case "Subtract":
                currentValue = Mathf.Max(currentValue - value, 0);
                break;
        }
        float result = (float)currentValue / (float)maxValue;
        statBar.fillAmount = result;
        statText.text = $"{((int)(result * 100))}%";
    }
}
