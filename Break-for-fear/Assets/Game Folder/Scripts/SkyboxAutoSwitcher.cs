using UnityEngine;

public class SkyboxAutoSwitcher : MonoBehaviour
{
    public Material[] skyboxes;  // Assign 3 skybox materials here

    private int currentSkyboxIndex = 0;
    private float timer = 0f;
    private float switchInterval = 5f;  // 300 seconds = 5 minutes

    void Start()
    {
        if (skyboxes.Length < 3)
        {
            Debug.LogError("Please assign 3 skybox materials.");
            return;
        }

        RenderSettings.skybox = skyboxes[0];
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= switchInterval)
        {
            timer = 0f;
            SwitchSkybox();
        }
    }

    void SwitchSkybox()
    {
        currentSkyboxIndex = (currentSkyboxIndex + 1) % skyboxes.Length;
        RenderSettings.skybox = skyboxes[currentSkyboxIndex];
    }
}
