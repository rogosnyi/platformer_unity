using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealCup : MonoBehaviour
{
    [SerializeField] private int _heal;
    PlayerStats playerStats;
    public int Heal => _heal;
  

    private void OnCollisionEnter2D(Collision2D other)
    {
        // = other.collider.GetComponent<Cup>();
        playerStats = other.collider.GetComponent<PlayerStats>();
        if (this != null)
        {
            playerStats.Heal(_heal);
            Destroy(gameObject);
        }
    }
}
