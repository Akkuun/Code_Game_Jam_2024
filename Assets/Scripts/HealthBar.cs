using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public void setHealth(float health)
    {
        slider.value = health;
    }

    public void setHealth(int health)
    {
        slider.value = health;
    }

    public void Damage(int num)
    {
        if (slider.value - num >= 0)
            setHealth(slider.value - num);
        else
            slider.value = 0;
    }

    public void Damage(float num)
    {
        if (slider.value - num >= 0)
            setHealth(slider.value - num);
        else
            slider.value = 0;
    }
    public void Heal(int num)
    {
        if (slider.value + num <= 100)
            slider.value += num;
        else
            slider.value = 100;
    }

    public void Heal(float num)
    {
        if (slider.value + num <= 100)
            slider.value += num;
        else
            slider.value = 100;
    }

    public float GetHealth()
    {
        return slider.value;
    }

    public void setMaxHealth(int health){
        slider.maxValue = health;
    }
}
