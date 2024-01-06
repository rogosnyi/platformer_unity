using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : MonoBehaviour
{
    PlayerMover playerMover;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D other)
    {
        // = other.collider.GetComponent<Cup>();
        playerMover = other.collider.GetComponent<PlayerMover>();
        playerMover._hasLever = true;
        Destroy(gameObject);
    }
}
