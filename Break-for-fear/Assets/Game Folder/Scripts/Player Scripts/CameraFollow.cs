using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform cameraTransform;
    public Animator playerAnimator;
    public string defaultAnimationName = "BentBody"; // Set this to your default animation state's name
    public Vector3 defaultCameraPosition = new Vector3(0f, 1.6f, 0f);
    public Vector3 crouchCameraPosition = new Vector3(0f, 1.0f, 0f);
    public float cameraSmoothSpeed = 15f;

    void Update()
    {
        // Get current animation state
        AnimatorStateInfo stateInfo = playerAnimator.GetCurrentAnimatorStateInfo(0);

        // Choose camera position based on animation
        Vector3 targetPosition = stateInfo.IsName(defaultAnimationName) ? defaultCameraPosition : crouchCameraPosition;

        // Smoothly move camera
        cameraTransform.localPosition = Vector3.Lerp(cameraTransform.localPosition, targetPosition, Time.deltaTime * cameraSmoothSpeed);
    }
}
