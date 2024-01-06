using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour
{
    PlayerStats playerStats;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        // = other.collider.GetComponent<Cup>();
        playerStats = other.collider.GetComponent<PlayerStats>();
        Debug.Log("Congratulations! You've met the cat ! Game over :>");
        playerStats.Die();
        
    }
}
