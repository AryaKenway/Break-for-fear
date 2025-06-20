using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    PlayerMovement pm;
    float originalSpeed;
    private Dash dash;

    private void Start()
    {
        pm = GetComponent<PlayerMovement>();
        originalSpeed = pm.moveSpeed; //stores the original speed in "originalSpeed"
        dash = GetComponent<Dash>();
    }

    void Update()
    {
        HandleSpeedBoost();
    }

    void HandleSpeedBoost()
    {
        if (dash != null && !dash.IsDashing()) // Don't interfere during dash
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                pm.moveSpeed = 20;
            }
            else
            {
                pm.moveSpeed = originalSpeed; // reverts back to original speed
            }
        }
    }

   
}
