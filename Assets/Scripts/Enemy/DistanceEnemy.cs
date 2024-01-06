using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceEnemy : MonoBehaviour
{
    [SerializeField] private float _walkRange;
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private float _speed;
    [SerializeField] private bool _faceRight;
    [SerializeField] private int _damage;
    [SerializeField] private int _pushPower;
    [SerializeField] private int _currentHp;
    [SerializeField] private int _maxHp;
    private Vector2 _startPosition;
    private int _direction = 1;
    private float _lastAttackTime;
    private Vector2 _drawPosition
    {
        get 
        {
            if (_startPosition == Vector2.zero)
            {
                return transform.position;

            }
            else
            {
                return _startPosition;
            }
        }
    }
    private void Start()
    {
        _startPosition = transform.position;
        ChangeHp(_maxHp);
    }
    private void ChangeHp(int hp)
    {
        _currentHp = hp;
        if(_currentHp<=0)
        {
            Destroy(gameObject);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(_drawPosition, new Vector3(_walkRange*2,1,0));
    }
    private void Update()
    {
        if (_faceRight&& transform.position.x>_startPosition.x+_walkRange)
        {
            Flip();
        }
        else if (!_faceRight && transform.position.x < _startPosition.x - _walkRange)
        {
            Flip();
        }
    }
    private void FixedUpdate()
    {
        _rigidbody2D.velocity = Vector2.right * _direction * _speed;
    }
    private void Flip()
    {
        _faceRight = !_faceRight;
        transform.Rotate(0, 180, 0);
        _direction *= -1;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        PlayerStats player = collision.collider.GetComponent<PlayerStats>();
        if (player!=null && Time.time-_lastAttackTime>0.2f)
        {
            _lastAttackTime = Time.time;
            player.TakeDamage(_damage,_pushPower,transform.position.x);
        }
    }
    public void TakeDamage(int damage)
    {
        ChangeHp(_currentHp - damage);
        Debug.Log(_currentHp);
    }    
}
