using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Vector2 _inputV;
    private Rigidbody2D _rigid;

    [SerializeField] private float speed;

    private void Awake()
    {
        _rigid = GetComponent<Rigidbody2D>();
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
}
