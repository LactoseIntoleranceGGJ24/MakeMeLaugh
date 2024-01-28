using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private GameObject _player;
    //                                          this doesnt work
    void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0);
        //Vector3 actualMousePos = Camera.main.ScreenToWorldPoint(mousePos);

        Vector3 target = mousePos - _player.transform.position;
        Vector3 movement = _player.transform.position + Vector3.ClampMagnitude(target, 4);
        movement.z = -10;
        this.transform.position = movement;

    }
}
