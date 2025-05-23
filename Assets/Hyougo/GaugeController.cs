using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GaugeController : MonoBehaviour
{
    [SerializeField] private GameObject _gauge;
    [SerializeField] private GameObject _graceGauge;
    [SerializeField] private float _waitingTime;
    public int _HP;
    private float _HP1;

    public void Init()
    {
        _HP1 = _gauge.GetComponent<RectTransform>().sizeDelta.x / _HP;
    }

    public void BeInjured(int attack)
    {
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