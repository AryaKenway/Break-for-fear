using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DashUI : MonoBehaviour
{
    public Dash dashScript;

    public Image dashIcon;            // The base icon that changes color
    public Image cooldownMask; // Radial fill image
    public TextMeshProUGUI cooldownText; // Countdown number

    public Color cooldownColor = Color.gray;
    public Color readyColor = Color.white;
    public Color iconCooldownColor = Color.gray;
    public Color iconReadyColor = Color.gray;
    public Color textCooldownColor = Color.gray;
    public Color textReadyColor = Color.white;


    void Update()
    {
        UpdateUI();
    }

    void UpdateUI()
    {
        float cooldown = dashScript.GetCooldown();
        float ratio = 1f - Mathf.Clamp01(cooldown / dashScript.dashRegenTime);

        // Update radial fill and color
        cooldownMask.fillAmount = ratio;
        cooldownMask.color = Color.Lerp(cooldownColor, readyColor, ratio);

        // Show countdown number if in cooldown
        if (cooldown > 0)
        {
            cooldownText.text = Mathf.CeilToInt(cooldown).ToString();
        }
        else
        {
            cooldownText.text = "E";
        }
        dashIcon.color = Color.Lerp(iconReadyColor, iconCooldownColor, ratio);
        cooldownText.color = Color.Lerp(textCooldownColor, textReadyColor, ratio);

    }
}
