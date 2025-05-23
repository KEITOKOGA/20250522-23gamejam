using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GaugeController : MonoBehaviour
{
    [SerializeField] private GameObject _gauge;
    [SerializeField] private GameObject _graceGauge;
    [SerializeField] private float _waitingTime;
    public int _HP;
    public int _currentHP;
    private float _HP1;

    private void Update()
    {

    }
    public void Init()
    {
        _currentHP = _HP;
        _HP1 = _gauge.GetComponent<RectTransform>().sizeDelta.x / _HP;
    }

    public void BeInjured(int attack)
    {
        _currentHP -= attack;
        if (_currentHP <= _HP / 4)
        {
            _gauge.GetComponent<Image>().color = new Color(255, 0, 0);
        }
        else if (_currentHP <= _HP / 2)
        {
            _gauge.GetComponent<Image>().color = new Color(255, 165, 0);
        }
        float damage = _HP1 * attack;
        StartCoroutine(damageEnumerator(damage));
    }

    // 体力ゲージを減らすコルーチン
    IEnumerator damageEnumerator(float damage)
    {
        var gauge = _gauge.GetComponent<RectTransform>();
        var graceGauge = _graceGauge.GetComponent<RectTransform>();
        var endPos = gauge.sizeDelta;
        endPos.x -= damage;
        gauge.sizeDelta = endPos;
        yield return new WaitForSeconds(_waitingTime);
        var currentTime = 0f;
        while (currentTime < _waitingTime)
        {
            yield return null;
            currentTime += Time.deltaTime;
            var size = graceGauge.sizeDelta;
            var distPerFrame = (size.x - endPos.x) / _waitingTime * Time.fixedDeltaTime;
            size.x -= distPerFrame;
            graceGauge.sizeDelta = size;
        }
    }
}