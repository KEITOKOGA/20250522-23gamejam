using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class CooldownController : MonoBehaviour
{
    [SerializeField] private Image cooldownImageP1;
    [SerializeField] private Image cooldownImageP2;

    void Start()
    {
        if (cooldownImageP1 != null) cooldownImageP1.fillAmount = 1f;
        if (cooldownImageP2 != null) cooldownImageP2.fillAmount = 1f;
    }

    public void UIStartCooldown(PlayerType playerType, float duration)
    {
        Debug.Log("UI StartCooldown");
        if (playerType == PlayerType.A)
        {
            cooldownImageP1.fillAmount = 0;
            cooldownImageP1.DOFillAmount(1, duration).SetEase(Ease.Linear);
        }
        else
        {
            cooldownImageP2.fillAmount = 0;
            cooldownImageP2.DOFillAmount(1, duration).SetEase(Ease.Linear);
        }
    }
}
