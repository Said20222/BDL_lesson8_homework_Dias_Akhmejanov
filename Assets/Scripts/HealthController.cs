using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private Slider _healthBar;
    [SerializeField] private float _health;
    [SerializeField] private float _fillSpeed;
    private float _healthPercentage;

    // Start is called before the first frame update
    private void Start()
    {
        _healthPercentage = _health/100;
    }

    public void DealDamage(float damage) {
        if (_health > 0) {
            _health -= damage;
        } else {
            _health = 0;
        }

        _healthPercentage = _health/100;
    }

    // Update is called once per frame
    private void Update()
    {
        _healthBar.value = Mathf.Lerp(_healthBar.value, _healthPercentage, Time.deltaTime * _fillSpeed);
    }
}
