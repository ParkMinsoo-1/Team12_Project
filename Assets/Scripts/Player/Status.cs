using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Status : MonoBehaviour
{
    public int currentValue;
    public int startValue;
    public int maxValue;
    public int passiveValue;
    
    private void Start()
    {
        currentValue = startValue;
    }
    
    //UI이미지 업데이트용 이미지 바 비율
    private void Update() 
    {
        
    }

    public void Add(int value)
    {
        currentValue = Mathf.Min(currentValue + value, maxValue); //둘 중 작은 값을 현재 값으로 사용
    }

    public void Subtract(int value)
    {
        currentValue = Mathf.Max(currentValue - value, 0);
    }


}
