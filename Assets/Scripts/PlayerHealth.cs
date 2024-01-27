using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private float _maxHealth;
    private Player _player;
    private float _currentHealth;

    void Start()
    {
        _currentHealth = _maxHealth;
        _player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>(); ;
        _slider.value = _maxHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        _slider.value = _currentHealth;
        _player.ChangeColor(Color.red);
        if (_currentHealth <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    public void TakeDamageOverTime(float damage)
    {
        _currentHealth -= damage * Time.deltaTime;
        _slider.value = _currentHealth;

        if (_currentHealth <= 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

    public void Heal(float healing)
    {
        _currentHealth += healing;
        _slider.value = _currentHealth;
        if (_currentHealth >= _maxHealth)
        {
            _currentHealth = _maxHealth;
        }
    }
}
