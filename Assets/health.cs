using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class health : MonoBehaviour
{
    public Slider slider;
    [SerializeField] float maxValue = 100;

    public void setMaxHealth ()
    {
        slider.maxValue = maxValue;
        slider.value = maxValue;
    }

    public void setHealth (float value)
    {
        slider.value = value;
    }

    public void takeDamage(float value)
    {
        slider.value-=value;
    }
}
