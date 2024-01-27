using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;
public class ReviewScript : MonoBehaviour
{
    private int _starRating;
    private PlayerWeapon _playerWeapon;
    [SerializeField] private float[] cutoffTimes; //add 5 numbers as cutoff times for star ratings, e.g. [0, 5, 10, 15, 20 25] means you would get 5 stars for delivering an order with over 20 seconds remaining
    void Start()
    {
        _playerWeapon = GameObject.FindGameObjectWithTag("PlayerWeapon").GetComponent<PlayerWeapon>();
    }

    // Update is called once per frame
    void Update()
    {


    }
    /*
    public void Review(float timeRemaining, int questsRemaining)
    {
        for (int i = 5; i > 0; i --)
        {
            if (cutoffTimes[i] < timeRemaining);
            {
                _starRating = i; 
                break;
            }
        }
        if (_starRating > 2 && questsRemaining != 0) //if over 2 stars and not at restaurant, give the weapon a fire rate boost
        {
            _playerWeapon.Boost(0.3f, 8f);
        }

    }*/
}
