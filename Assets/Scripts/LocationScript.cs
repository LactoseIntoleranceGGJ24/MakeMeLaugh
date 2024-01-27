using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationScript : MonoBehaviour
{
    // Start is called before the first frame update
    public int id = 1;
    public LocationManagerScript lmscript;
    void Start()
    {
        lmscript = GameObject.FindGameObjectWithTag("LocationManager").GetComponent<LocationManagerScript>();
    }

    public void Activate()
    {
        Debug.Log("hi");
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
