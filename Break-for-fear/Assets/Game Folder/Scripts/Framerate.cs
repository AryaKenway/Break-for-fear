using UnityEngine;

public class Framerate : MonoBehaviour
{
    private void Start()
    { 
        Application.targetFrameRate = -1; 
        QualitySettings.vSyncCount = 0; // 0 for VSync off, 1 for matching monitors refresh rate , 2 for monitors refresh rate divided by 2
    }

}
