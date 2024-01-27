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



}
