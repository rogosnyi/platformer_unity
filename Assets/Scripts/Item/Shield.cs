using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    PlayerMover playerMover;
    private void OnCollisionEnter2D(Collision2D other)
    {
        // = other.collider.GetComponent<Cup>();
        playerMover = other.collider.GetComponent<PlayerMover>();
        if (playerMover._hasLever)
        {
            Destroy(gameObject);
        }
        
    }
}
