using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class LightShake : MonoBehaviour
{

    private Light2D lightComponent;

    public float min;
    public float max;

    private bool isLoaded;
    private float intensity;

    void Start()
    {
        lightComponent = GetComponent<Light2D>();
        if(lightComponent != null)
        {
            isLoaded = true;
            intensity = lightComponent.intensity;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(isLoaded)
        {
            lightComponent.intensity = Random.Range(intensity*min, intensity*max);
        }
    }
}
