using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 _inputV;
    private Rigidbody2D _rigid;
    private SpriteRenderer _sprite;
    private Animator _anim;

    [SerializeField] private float speed;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
        _sprite = GetComponent<SpriteRenderer>();
        _anim = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Vector2 moveV = _inputV * speed * Time.fixedDeltaTime   ;
        _rigid.MovePosition(_rigid.position + moveV);
    }
    void OnMove(InputValue value)
    {
        _inputV = value.Get<Vector2>();
    }

    private void LateUpdate()
    {
        if (_inputV.x != 0 && _inputV.y == 0)
        {
            _anim.SetFloat("speedX", _inputV.magnitude);
            _anim.SetFloat("speedY", 0);

            _sprite.flipX = _inputV.x > 0;
        }
        else if(_inputV.x == 0 & _inputV.y > 0)
        {
            _anim.SetTrigger("UpTrigger");
            _anim.SetFloat("speedX", 0);
            _anim.SetFloat("speedY", _inputV.magnitude);
        }
        else if (_inputV.x == 0 & _inputV.y < 0)
        {
            _anim.SetTrigger("DownTrigger");
            _anim.SetFloat("speedX", 0);
            _anim.SetFloat("speedY", _inputV.magnitude);
        }
        else if (_inputV.x == 0 & _inputV.y == 0)
        {
            _anim.Play("Idle");
        }
    }
}
