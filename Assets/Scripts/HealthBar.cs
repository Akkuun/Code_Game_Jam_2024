using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public GameObject GameOverMenu;
    public void setHealth(float health)
    {
        slider.value = health;
        if (health <= 0f)
        {
            GameOverMenu.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void setHealth(int health)
    {
        slider.value = health;
        if (health <= 0)
        {
            GameOverMenu.SetActive(true);
            Time.timeScale = 0f;
        }
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
