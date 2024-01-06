using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private int _maxHp;

    [SerializeField] private Slider _slider;
    [SerializeField] private TMP_Text _hpText;
    private int _currentHp;

    [SerializeField] public Animator _animator;
    [SerializeField] public string _damageAnimationKey;
    [SerializeField] public Rigidbody2D _rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        _currentHp = _maxHp;
        _slider.maxValue = _maxHp;
        _slider.value = _currentHp;
        _hpText.text = _currentHp.ToString();
    }
    
    public void TakeDamage(int damage, int pushPower=0, float enemyPosX=0 )
    {

        _animator.SetBool(_damageAnimationKey, true);
        _currentHp -= damage;
        _slider.value = _currentHp;
        _hpText.text = _currentHp.ToString();

        if (_currentHp <= 0)
        {
            Die();
        }
        if (pushPower!=0)
        {
            int direction = transform.position.x > enemyPosX ? 1 : -1;
            _rigidbody.AddForce(new Vector2(direction*pushPower/2,pushPower));
        }
        //_animator.Invoke(nameof(_animator.SetBool), 3);

        _animator.SetBool(_damageAnimationKey, false);
    }
    public void Heal(int _heal)
    {
        if (_currentHp+_heal>_maxHp)
        {
            _currentHp = _maxHp;
            _slider.value = _currentHp;
            _hpText.text = _currentHp.ToString();
        }
        else 
        {
            _currentHp +=_heal;
            _slider.value = _currentHp;
            _hpText.text = _currentHp.ToString();
        }
    }
    public void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
