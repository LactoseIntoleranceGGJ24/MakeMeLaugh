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
    [SerializeField] private GameObject _reviewScript;
    [SerializeField] private GameObject _enemySpawner;
    private GameObject _activeLocation;
    private int _questsRemaining = 3;
    private float _timer = 30f;
    [SerializeField] private ArrowScript arrowScript;
    [SerializeField] private Text timerText;
    AudioSource audioData;
    int locationNumber = 0;
    void Start()
    {
        arrowScript = GameObject.FindGameObjectWithTag("GuideArrow").GetComponent<ArrowScript>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _activeLocation = _restaurant;
        arrowScript.UpdateLocation(_restaurant);
        audioData = GetComponent<AudioSource>();
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
        audioData.Play(0);
        _activeLocation.GetComponent<SpriteRenderer>().color = Color.white;
        int temp = 0;
        
        if (_questsRemaining >= 0 && _questsRemaining < 3) //delivery
        {
            locationNumber = Random.Range(0, _locationList.Length); //there is a small chance to get the same location twice in a row
            _activeLocation = _locationList[locationNumber];
            _reviewScript.GetComponent<ReviewScript>().Review(timeRemaining);
            temp = -1;
        }
        if (_questsRemaining == 0) //final delivery
        {
            _activeLocation = _restaurant;
            //_questsRemaining = 4;
            temp = 3;
        
        }
        if (_questsRemaining == 3) //restaurant
        {
            _player.GetComponent<PlayerHealth>().Heal(70);
            _enemySpawner.GetComponent<EnemySpawner>().IncreaseSpawnRate();
            locationNumber = Random.Range(0, _locationList.Length);
            _activeLocation = _locationList[locationNumber];
            temp = -1;
        }

        _activeLocation.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0.5f) ;
        arrowScript.UpdateLocation(_activeLocation);
        _timer = 30f;
        _questsRemaining += temp;
    }


}
