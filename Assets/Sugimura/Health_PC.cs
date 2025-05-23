using UnityEngine;

public class Health_PC : MonoBehaviour, IAttackable
{
    [SerializeField, Header("元の体力値")] public int m_health_pc;
    [SerializeField, Header("相手の勝利画面")] public GameObject m_win_2;
    private int _maxHealth;
    private float title;
    private int i = 0;
    [SerializeField]
    private GaugeController gauge;

    void Start()
    {
        m_win_2.gameObject.SetActive(false);
        gauge._HP = m_health_pc;
        gauge.Init();
        _maxHealth = m_health_pc;
    }

    public void Damage(int damage)
    {
        Debug.Log($"player take {damage}");
        SoundManager.Instance.PlaySE(SE.BeamHit);
        gauge.BeInjured(damage);
        m_health_pc -= damage;
        if (m_health_pc <= 0)
        {
            SoundManager.Instance.PlaySE(SE.ResultWin);
            Destroy(gameObject);
            m_win_2.SetActive(true);
        }
    }
}