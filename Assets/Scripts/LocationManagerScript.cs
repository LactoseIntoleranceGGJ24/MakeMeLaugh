using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEditor.FilePathAttribute;
using UnityEditor.UI;
using UnityEngine.UI;

public class LocationManagerScript : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private GameObject[] _locationList;
    [SerializeField] private GameObject _restaurant;
    [SerializeField] private GameObject _player;
    [SerializeField] private ReviewScript _reviewScript;
    [SerializeField] private PlayerWeapon _playerWeapon;
    [SerializeField] private GameObject _enemySpawner;
    private GameObject _activeLocation;
    private int _questsRemaining;
    private float _timer = 30f;
    [SerializeField] private ArrowScript arrowScript;
    [SerializeField] private Text timerText;
    int locationNumber = 0;
    void Start()
    {
        arrowScript = GameObject.FindGameObjectWithTag("GuideArrow").GetComponent<ArrowScript>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerWeapon = GameObject.FindGameObjectWithTag("PlayerWeapon").GetComponent<PlayerWeapon>();
        _activeLocation = _restaurant;
        arrowScript.UpdateLocation(_restaurant);
    }

    // Using FixedUpdate for testing, this should be its own function
    void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0)
        {
            //could game over for this
            _timer = 0;
        }
        
        timerText.text = Mathf.FloorToInt(_timer).ToString();

        if (Vector3.Distance(_player.transform.position, _activeLocation.transform.position) < 5)
        {
            LocationReached(_timer);
        }

    }

    void LocationReached(float timeRemaining)
    {
        //_reviewScript.Review(timeRemaining, _questsRemaining);
        _activeLocation.GetComponent<SpriteRenderer>().color = Color.white;
       
        
        if (_questsRemaining > 0)
        {
            _playerWeapon.Boost(0.3f, 8f);
            locationNumber = Random.Range(0, _locationList.Length); //there is a small chance to get the same location twice in a row
            _activeLocation = _locationList[locationNumber];
            Debug.Log("House" + _questsRemaining);
        }
        if (_questsRemaining == 0)
        {
            _activeLocation = _restaurant;
            _questsRemaining = 4;
            _player.GetComponent<PlayerHealth>().Heal(70);
            _enemySpawner.GetComponent<EnemySpawner>().IncreaseSpawnRate();
            Debug.Log("Restaurant" + _questsRemaining);
        }
        _activeLocation.GetComponent<SpriteRenderer>().color = Color.yellow;
        arrowScript.UpdateLocation(_activeLocation);
        _timer = 30f;
        _questsRemaining -= 1;
    }


}
