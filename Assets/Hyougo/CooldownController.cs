using UnityEngine;
using UnityEngine.UI;

public class CooldownController : MonoBehaviour
{
    public float cooldownDuration = 2f;

    private float actionEndTimeP1 = 0f;
    private float actionEndTimeP2 = 0f;

    private bool isCooldownP1 = false;
    private bool isCooldownP2 = false;

    public Image cooldownImageP1;
    public Image cooldownImageP2;

    void Start()
    {
        if (cooldownImageP1 != null) cooldownImageP1.fillAmount = 1f;
        if (cooldownImageP2 != null) cooldownImageP2.fillAmount = 1f;
    }

    void Update()
    {
        HandlePlayerInput();
        UpdateCooldownUI();
    }

    void HandlePlayerInput()
    {
        // Player 1: Space
        if (Input.GetKeyDown(KeyCode.Space) && !isCooldownP1)
        {
            isCooldownP1 = true;
            actionEndTimeP1 = Time.time + cooldownDuration;
        }

        // Player 2: RightShift
        if (Input.GetKeyDown(KeyCode.RightShift) && !isCooldownP2)
        {
            isCooldownP2 = true;
            actionEndTimeP2 = Time.time + cooldownDuration;
        }

        if (isCooldownP1 && Time.time >= actionEndTimeP1)
        {
            isCooldownP1 = false;
        }

        if (isCooldownP2 && Time.time >= actionEndTimeP2)
        {
            isCooldownP2 = false;
        }
    }

    void UpdateCooldownUI()
    {
        if (cooldownImageP1 != null)
        {
            if (isCooldownP1)
            {
                float remaining = actionEndTimeP1 - Time.time;
                cooldownImageP1.fillAmount = Mathf.Clamp01(remaining / cooldownDuration);
            }
            else
            {
                cooldownImageP1.fillAmount = 1f; // çUåÇâ¬î\
            }
        }

        if (cooldownImageP2 != null)
        {
            if (isCooldownP2)
            {
                float remaining = actionEndTimeP2 - Time.time;
                cooldownImageP2.fillAmount = Mathf.Clamp01(remaining / cooldownDuration);
            }
            else
            {
                cooldownImageP2.fillAmount = 1f; // çUåÇâ¬î\
            }
        }
    }
}
