using UnityEngine;
using UnityEngine.Rendering;

public class DayNightCycle : MonoBehaviour
{
    public Light morningLight;
    public Light eveningLight;
    public Light nightLight;

    public float fullCycleDuration = 90f;  // Full Morning → Evening → Night → Morning cycle time in seconds

    public Color morningAmbient = new Color(0.6f, 0.6f, 0.6f);
    public Color eveningAmbient = new Color(0.4f, 0.4f, 0.4f);
    public Color nightAmbient = Color.black;

    private float timeOfDay = 0f;

    void Start()
    {
        SetMorning();
    }

    void Update()
    {
        timeOfDay += Time.deltaTime;
        float cycleProgress = (timeOfDay % fullCycleDuration) / fullCycleDuration;

        if (cycleProgress < 0.33f)
        {
            SetMorning();
        }
        else if (cycleProgress < 0.66f)
        {
            SetEvening();
        }
        else
        {
            SetNight();
        }
    }

    void SetMorning()
    {
        ActivateLight(morningLight);
        RenderSettings.sun = morningLight;
        RenderSettings.ambientMode = AmbientMode.Flat;
        RenderSettings.ambientLight = morningAmbient;
    }

    void SetEvening()
    {
        ActivateLight(eveningLight);
        RenderSettings.sun = eveningLight;
        RenderSettings.ambientMode = AmbientMode.Flat;
        RenderSettings.ambientLight = eveningAmbient;
    }

    void SetNight()
    {
        ActivateLight(nightLight);
        RenderSettings.sun = nightLight;
        RenderSettings.ambientMode = AmbientMode.Flat;
        RenderSettings.ambientLight = nightAmbient;
    }

    void ActivateLight(Light activeLight)
    {
        morningLight.enabled = (activeLight == morningLight);
        eveningLight.enabled = (activeLight == eveningLight);
        nightLight.enabled = (activeLight == nightLight);
    }
}
