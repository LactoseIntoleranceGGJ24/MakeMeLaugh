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

        _healthUI.text = _currentHealth.ToString() + " / " + _maxHealth;
    }

    public void TakeDamage(float damage) {
        _currentHealth -= damage;

        _healthUI.text = _currentHealth.ToString() + " / " + _maxHealth;
    }
}
