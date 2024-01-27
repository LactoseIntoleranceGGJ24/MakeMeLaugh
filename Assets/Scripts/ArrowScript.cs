using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    // Start is called before the first frame update

    private Vector3 _targetLocation;
    private GameObject _cam;
    private Vector3 _arrowDirection;
    private float _distance;
    void Start()
    {
        _cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    public void UpdateLocation(GameObject activeLocation)
    {
        _targetLocation = activeLocation.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        //position arrow relative to camera and rotate towards target
        _arrowDirection = Vector3.MoveTowards(_cam.transform.position, _targetLocation, 6);
        _arrowDirection.z = 0;
        transform.position = _arrowDirection;

        Vector3 targetDirection = _targetLocation - _cam.transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetDirection);

        //fade out if close to target
        _distance = Vector3.Distance(_cam.transform.position, _targetLocation);

        

        if (_distance < 20)
        {
            Color _arrowCol = new Color(0.8f, 1, 0, (_distance * 0.8f) - 9);
            GetComponent<SpriteRenderer>().color = _arrowCol;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.yellow;
        }
    }
}

