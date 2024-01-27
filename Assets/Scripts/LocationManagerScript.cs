using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.FilePathAttribute;

public class LocationManagerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] _locationList;
    public GameObject _restaurant;
    public GameObject _player;
    public PlayerWeapon _playerWeapon;
    private GameObject _activeLocation;
    private int _questsRemaining;
    public ArrowScript arrowScript;
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
    void FixedUpdate()
    {
        if (Vector3.Distance(_player.transform.position, _activeLocation.transform.position) < 5)
        {
            LocationReached();
        }
    }

    void LocationReached()
    {
        
        if (_questsRemaining > 0) 
        {   
            _playerWeapon.Boost(0.3f, 8f);
            locationNumber = Random.Range(0, _locationList.Length);
            _activeLocation = _locationList[locationNumber];
            arrowScript.UpdateLocation(_activeLocation);
            _questsRemaining -= 1;
        } else if (_questsRemaining == 0)
        {
            _activeLocation = _restaurant;
            locationNumber = Random.Range(0, _locationList.Length);
            arrowScript.UpdateLocation(_activeLocation);
            _questsRemaining = 3;
        }
        Debug.Log("Location reached, " +_questsRemaining +" quests remaining");

    }


}
