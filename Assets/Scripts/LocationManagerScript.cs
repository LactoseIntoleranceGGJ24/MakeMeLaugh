using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class LocationManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] locationList;
    public ArrowScript arrowScript;
    int locationNumber;
    void Start()
    {
        arrowScript = GameObject.FindGameObjectWithTag("GuideArrow").GetComponent<ArrowScript>();
    }

    // Using FixedUpdate for testing, this should be its own function
    void FixedUpdate()
    {
        //int randomv = Random.Range(0, locationList.Length);
        GameObject activeLocation = locationList[locationNumber];

        arrowScript.UpdateLocation(activeLocation);

        if (Input.GetMouseButtonDown(0)) //select random location on mouse press
        { 
            locationNumber = Random.Range(0, locationList.Length);
            Debug.Log(locationNumber);
        }
    }

<<<<<<< Updated upstream
=======
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

        _activeLocation.GetComponent<SpriteRenderer>().color = new Color(1f, 1f, 0.2f) ;
        arrowScript.UpdateLocation(_activeLocation);
        _timer = 30f;
        _questsRemaining += temp;
    }
>>>>>>> Stashed changes


}
