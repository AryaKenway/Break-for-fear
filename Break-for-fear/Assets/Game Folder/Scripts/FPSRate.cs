using UnityEngine;

public class FPSManager : MonoBehaviour
{
    public static FPSManager Instance;

    void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // persists across scenes
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SetFPSLock(bool limitTo30)
    {
        Application.targetFrameRate = limitTo30 ? 30 : -1; // -1 = uncapped
    }
}
