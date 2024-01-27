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
    private GameObject _activeLocation;
    private bool _isRestauraunt = true;
    public ArrowScript arrowScript;
    int locationNumber = 0;
    void Start()
    {
        arrowScript = GameObject.FindGameObjectWithTag("GuideArrow").GetComponent<ArrowScript>();
        _player = GameObject.FindGameObjectWithTag("Player");
        _activeLocation = _restaurant;
        arrowScript.UpdateLocation(_restaurant);
    }

    // Using FixedUpdate for testing, this should be its own function
    void FixedUpdate()
    {
        Debug.Log(Vector3.Distance(_player.transform.position, _activeLocation.transform.position));
        if (Vector3.Distance(_player.transform.position, _activeLocation.transform.position) < 3)
        {
            LocationReached(_activeLocation);
        }

    }

    void LocationReached(GameObject currentLocation)
    {
        if (_isRestauraunt == true)
        {
            locationNumber = Random.Range(0, _locationList.Length);
            _activeLocation = _locationList[locationNumber];
            arrowScript.UpdateLocation(_activeLocation);
            _isRestauraunt = false;
        } else if (_isRestauraunt == false) 
        {
            _activeLocation = _restaurant;
            arrowScript.UpdateLocation(_activeLocation);
            _isRestauraunt = true;
        }

    }

}
