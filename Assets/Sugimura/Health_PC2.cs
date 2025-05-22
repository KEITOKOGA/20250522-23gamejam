using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_PC2 : MonoBehaviour,IAttackable
{
    [SerializeField, Header("元の体力値")]
    public int m_health_pc;
    [SerializeField, Header("相手の勝利画面")]
    public GameObject m_win_1;
    [SerializeField, Header("タイトルへ戻る")]
    public GameObject m_title;
    /*
        private float m_timer;
        private string lasertag = "Laser";
    */
    private int m_Maxhealth_pc;
    //    private bool hit = false;




    // Start is called before the first frame update
    void Start()
    {
        m_Maxhealth_pc = m_health_pc;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void Damage(int damage)
    {
        m_health_pc -= damage;
        if (m_health_pc <= 0)
        {
            Destroy(this.gameObject);
            m_win_1.SetActive(true);
            m_title.SetActive(true);
        }

    }

}
