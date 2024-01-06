using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]private int _damage;
    [SerializeField] private float _damageDelay;
    private float _lastDamageTime;
    
    private PlayerStats _playerStats;

    private void OnTriggerEnter2D(Collider2D collider)
    {
      
        _playerStats = collider.GetComponent<PlayerStats>();
        if (_playerStats != null)
        {
            
            _playerStats.TakeDamage(_damage);
            _lastDamageTime = Time.time;
        }
        
    }
    private void Update()
    {
        if (Time.time- _lastDamageTime>_damageDelay&& _playerStats != null)
        {
            _playerStats.TakeDamage(_damage);
            _lastDamageTime = Time.time;
        }
    }
    private void OnTriggerExit2D(Collider2D collider)
    {

        PlayerStats playerStats = collider.GetComponent<PlayerStats>();
        if (_playerStats == playerStats)
        {
            _playerStats = null;
        }
    }
}
