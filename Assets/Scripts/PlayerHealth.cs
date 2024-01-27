using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthUI;
    [SerializeField] private float _maxHealth;
    private float _currentHealth;

    void Start() {
        _currentHealth = _maxHealth;

        _healthUI.text = string.Format("{0:#.0} / {1}", _currentHealth, _maxHealth);
    }

    public void TakeDamage(float damage) {
        _currentHealth -= damage;

        _healthUI.text = string.Format("{0:#.0} / {1}", _currentHealth, _maxHealth);
    }

    public void TakeDamageOverTime(float damage) {
        _currentHealth -= damage * Time.deltaTime;

        _healthUI.text = string.Format("{0:#.0} / {1}", _currentHealth, _maxHealth);
    } 
}
