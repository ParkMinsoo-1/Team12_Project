using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerStatus : MonoBehaviour
{
  
    [SerializeField] private int currentValue;
    public int CurrentValue { get => currentValue; set => currentValue = value; } //넘겨주는 값
    
    [SerializeField] private int startValue;
    public int StartValue { get => startValue; set => startValue = value; } //넘겨주는 값
    
    [SerializeField] private int maxValue;
    public int MaxValue { get => maxValue; set => maxValue = value; } //넘겨주는 값
    
    
}
