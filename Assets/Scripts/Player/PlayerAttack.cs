using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;
    public Transform attackPos;
    public LayerMask enemy;
    public float attackRange;
    public int damage;
    public Animator _animator;
    [SerializeField] public string _attackAnimationKey;

    private void Update()
    {
        
        if (timeBtwAttack <= 0)
        {
           
            if (Input.GetKey(KeyCode.F))
            {
               // Debug.Log('d');
                _animator.SetBool(_attackAnimationKey, true);

                //End Animation Attack



                // anim.SetTrigger("Attack");
                _animator.SetBool(_attackAnimationKey, true);
                Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPos.position, attackRange, enemy);
                for (int i = 0; i < enemies.Length; i++)
                {
                    //enemies[i].GetComponent<Enemy>().TakeDamage(damage);
                }
            }
            else
               // _animator.SetBool(_attackAnimationKey, false);

            timeBtwAttack = startTimeBtwAttack;
            
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
       _animator.SetBool(_attackAnimationKey, false);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
