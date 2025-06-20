using UnityEngine;

public class SlowFall : MonoBehaviour
{
    private PlayerMovement pm;

    public float normalGravity = -20f;
    public float slowFallGravity = -2f;

    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (!pm.controller.isGrounded)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                pm.verticalVelocity = slowFallGravity;
            }
            else
            {
                pm.verticalVelocity = normalGravity;
            }
        }
    }
}
