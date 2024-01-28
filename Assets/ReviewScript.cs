using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.Experimental.GraphView.GraphView;
public class ReviewScript : MonoBehaviour
{
    private int _starRating;
    [SerializeField] private PlayerWeapon _playerWeapon;
    [SerializeField] private Text reviewText;
    [SerializeField] private float[] cutoffTimes; //add 5 numbers as cutoff times for star ratings, e.g. [0, 5, 10, 15, 20] means you would get 5 stars for delivering an order with over 20 seconds remaining
    private string[] fiveStars = new string[]{ "5/5 Stars! So fresh – like I’m eating at the restaurant itself. Thank god. I don’t know how you do it." };
    private string[] fourStars = new string[] { "4/5 Stars it’s about as good as you can get when there are hordes of hungry beaks outside. Thank you — you make the bird-apocalypse bearable." };
    private string[] threeStars = new string[] { "3 Stars, the rice was a bit cold. I would go out and pick it up myself if it weren’t for all those beady eyes." };
    private string[] twoStars = new string[] { "2 Stars. Wish I could go outside again instead of having stuff delivered late all the time. I’m so sick of those mutant birds. Whose idea was it to keep feeding them food orders in the first place?" };
    private string[] oneStar = new string[] { "1 Star. Was so hungry that I was starting to wonder if maybe I should just hunt all the gulls outside and eat them." };
    private string[][] reviews;
    void Start()
    {
       reviews = new string[][] {oneStar, twoStars, threeStars, fourStars, fiveStars};
    }

    
    public void Review(float timeRemaining)
    {
        reviewText.text = null;
        for (int i = 4; i > 0; i--)
        {
            if (timeRemaining > cutoffTimes[i])
            {
                _starRating = i; 
                break;
            }
        }
        if (_starRating > 2) //if over 2 stars give the weapon a fire rate boost
        {
            _playerWeapon.GetComponent<PlayerWeapon>().Boost(0.3f, 8f);
        }
        Debug.Log(reviews[_starRating][0]);
        string temp = reviews[_starRating][0];
        reviewText.text = temp;
    }
}
