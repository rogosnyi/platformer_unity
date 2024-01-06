    using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMover : MonoBehaviour
{

    [Header("Movement")]
    [SerializeField] public float _groundCheckerRadius;
    [SerializeField] public Rigidbody2D _rigidbody;
    [SerializeField] public Transform _groundChecker;
    [SerializeField] public LayerMask _whatIsGround;
    [SerializeField] public Transform _transform;
    [SerializeField] public float _speed;
    [SerializeField] public float _jumpPower;


    [Header("Animation")]
    [SerializeField] public Collider2D _headCollider;
    [SerializeField] public Transform _cellChecker;
    [SerializeField] public float _cellCheckerRadius;

    [SerializeField] public Animator _animator;
    [SerializeField] public string _runAnimationKey;
    [SerializeField] public string _crouchAnimationKey;
    [SerializeField] public string _jumpAnimationKey;
    [SerializeField] public string _attackAnimationKey;

    [Header("Attack")]
    [SerializeField] private int _swordDamage;
    [SerializeField] private Transform _swordAttackPoint;
    [SerializeField] private float _swordAttackradius;
    [SerializeField] private LayerMask _whatIsEnemy;

    private bool _facingRight = true;
    private bool _needToAttack;
    public float _startSpeed;
    public bool _hasLever = false;

    // Start is called before the first frame update
    void Start()
    {
        _startSpeed = _speed;
    }

    // Update is called once per frame
    void Update()
    {
        var grounded = Physics2D.OverlapCircle(_groundChecker.position, _groundCheckerRadius, _whatIsGround);
        float direction = Input.GetAxisRaw("Horizontal");
        Vector2 velocity = _rigidbody.velocity;
        _animator.SetBool(_runAnimationKey, direction != 0);


        if (grounded)
        {
            _rigidbody.velocity = new Vector2(_speed * direction, velocity.y);
            if (direction < 0 && _facingRight)
            {
                Flip();
            }
            else if (direction > 0 && !_facingRight)
            {
                Flip();
            }
        }
        if(Input.GetButtonDown("Fire1"))
        {
            _needToAttack = true;
        }
        ////Animation Attack
        //if (Input.GetKey(KeyCode.F))
        //{
        //    _animator.SetBool(_attackAnimationKey, true);
        //}
        ////End Animation Attack
        //else
        //{
        //    _animator.SetBool(_attackAnimationKey, false);
        //}
        //_animator.SetBool(_attackAnimationKey, false);
        if (Input.GetButtonUp("Jump") && grounded)
        {

            _rigidbody.velocity = new Vector2(velocity.x, _jumpPower);
        }

        //JumpAnimations
        _animator.SetBool(_jumpAnimationKey, true);

        if (grounded == true)
        {
            _animator.SetBool(_jumpAnimationKey, false);
        }
        //end of Jump animation

        bool cellAbove = Physics2D.OverlapCircle(_cellChecker.position, _cellCheckerRadius, _whatIsGround); ;

        _animator.SetBool(_crouchAnimationKey, !_headCollider.enabled);

        if (Input.GetKey(KeyCode.C))
        {

            _headCollider.enabled = false;
        }
        else if (!cellAbove)
        {
            _headCollider.enabled = true;
        }
    }
    private void FixedUpdate()
    {
        if (_needToAttack)
        {
            StartAttack();
        }
    }
    private void StartAttack()
    {
        if (_animator.GetBool(_attackAnimationKey))
        {
            Attack();
            return;
        }
        _animator.SetBool(_attackAnimationKey, true);
    }
    private void Attack()
    {
        Collider2D[] targets = Physics2D.OverlapBoxAll(_swordAttackPoint.position, new Vector2 (_swordAttackradius, _swordAttackradius), _whatIsEnemy);
        foreach(var target in targets)
        {
            DistanceEnemy distanceEnemy = target.GetComponent<DistanceEnemy>();
            if(distanceEnemy!=null)
            {
                distanceEnemy.TakeDamage(_swordDamage);
            }
        }
        _animator.SetBool(_attackAnimationKey, false);
        _needToAttack = false;
    }
    private void Flip()
    {
        _transform.Rotate(0, 180, 0);
        _facingRight = !_facingRight;
    }
   

    public void ResetSpeed()
    {
        _speed = _startSpeed;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(_groundChecker.position, _groundCheckerRadius);
        Gizmos.color = Color.black;
        Gizmos.DrawWireSphere(_cellChecker.position, _cellCheckerRadius);
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(_swordAttackPoint.position,new Vector3(_swordAttackradius, _swordAttackradius,0));
    }
}
