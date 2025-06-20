using UnityEngine;

public class Dash : MonoBehaviour
{
    public float dashSpeed = 30f;
    public float dashDuration = 0.2f;
    public int maxDashes = 1;
    public float dashRegenTime = 2f;

    private int currentDashes;
    private float dashCooldown;
    private float dashTimer;
    private bool isDashing;

    private PlayerMovement pm;

    void Start()
    {
        pm = GetComponent<PlayerMovement>();
        currentDashes = maxDashes;
       // dashCooldowns = new float[maxDashes]; //Array cuz we have 3 dashes, if 1 is used we need to see other dash's cooldowns 
    }

    void Update()
    {
        HandleDash();
        RegenerateDashes();
    }

    void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.E) && !isDashing && currentDashes > 0)
        {
            isDashing = true;
            dashTimer = dashDuration; // Dashtimer is required because you want the dash to stop after 1 or 2 seconds, not go continuously
            currentDashes--;
            dashCooldown = dashRegenTime;
        }

        if (isDashing)
        {
            dashTimer -= Time.deltaTime;
            pm.controller.Move(transform.forward * dashSpeed * Time.deltaTime);  // transform.forward = Dash forward, Time.deltaTime = frame rate independent movement

            if (dashTimer <= 0f) //Stops dash after a certain time as per dash duration
                isDashing = false;
        }
    }

    void RegenerateDashes()
    {
        
            if (currentDashes<maxDashes)
            {
                dashCooldown = dashCooldown - Time.deltaTime; // reduce the cooldown time - 5,4,3,2,1 so that we can increment curentDashes
            if (dashCooldown <= 0f)
            {
                currentDashes = maxDashes;
                dashCooldown = 0f;
            }
            }
        

        currentDashes = Mathf.Clamp(currentDashes, 0, maxDashes);
    }

    public bool IsDashing() // Used so that speedboost doesnt overlap dash, still doesnt work tho
    {
        return isDashing;
    }
    public float GetCooldown()
    { 
        return dashCooldown; 
    }

    public int GetCurrentDashes()
    {
        return currentDashes;
    }
}
