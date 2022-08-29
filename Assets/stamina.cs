using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stamina : MonoBehaviour
{
    public Slider slider;
    [SerializeField] float maxValue = 100;

    public void setMaxStamina()
    {
        slider.maxValue = maxValue;
        slider.value = maxValue;
    }

    public void setStamina(float value)
    {
        slider.value = value;
    }

    public void loseStamina()
    {
        slider.value--;
    }
}
