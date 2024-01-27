using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject _targetLocation;
    GameObject _cam;
    Vector3 _arrowDirection;
    float _distance;
    Color _color;
    void Start()
    {
        //temporary way of getting a location for testing
        _targetLocation = GameObject.FindGameObjectWithTag("Location");
        _cam = GameObject.FindGameObjectWithTag("MainCamera");
    }

    // Update is called once per frame
    void Update()
    {
        //position arrow relative to camera and rotate towards target
        _arrowDirection = Vector3.MoveTowards(_cam.transform.position, _targetLocation.transform.position, 5);
        _arrowDirection.z = 0;
        transform.position = _arrowDirection;


        Vector3 targetDirection = _targetLocation.transform.position - _cam.transform.position;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetDirection);

        //fade out if close to target
        _distance = Vector3.Distance(_cam.transform.position, _targetLocation.transform.position);

        Color _arrowCol = new Color(1, 1, 1, (_distance * 0.8f) - 10);

        if (_distance < 20)
        {
            _arrowCol.b = 0f;
            GetComponent<SpriteRenderer>().color = _arrowCol;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        }
    }
}

