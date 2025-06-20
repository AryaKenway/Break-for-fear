using UnityEngine;
using TMPro;
public class FpsCounter : MonoBehaviour
{
    public TextMeshProUGUI textMeshProUGUI;
    float deltatime;

    private void Update()
    {
        deltatime += (Time.unscaledDeltaTime - deltatime) * 0.1f;
        float fps = (1.0f / deltatime);
        textMeshProUGUI.text = string.Format("{0:0.} FPS", fps);
    }
}
