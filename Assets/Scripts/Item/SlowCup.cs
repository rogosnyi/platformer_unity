using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowCup : MonoBehaviour
{
    [SerializeField] private float _upgradeTime;
    [SerializeField] private float _upgradePower;
    PlayerMover playerMover;
    public float UpgradeTime => _upgradeTime;
    public float UpgradePower => _upgradePower;

    private void OnCollisionEnter2D(Collision2D other)
    {
        // = other.collider.GetComponent<Cup>();
        playerMover = other.collider.GetComponent<PlayerMover>();
        if (this != null)
        {
            playerMover._speed *= UpgradePower/10;
            playerMover.Invoke(nameof(playerMover.ResetSpeed), UpgradePower);
            Destroy(gameObject);
        }
    }
}
