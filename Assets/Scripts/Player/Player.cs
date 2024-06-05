using UnityEngine;
using UnityEngine.InputSystem;

public class Player : Singleton<Player>
{
    public Vector2 inputV;
    public GameObject miniGame;
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
        if (miniGame.activeSelf == false)
        {
            Vector2 moveV = inputV * speed * Time.fixedDeltaTime;
            _rigid.MovePosition(_rigid.position + moveV);
        }
        else
        {
            if (Input.GetKey(KeyCode.Space))
            {
                if (miniGame.GetComponent<Minigame>().conclude)
                {
                    InventoryDB.Instance.obj.Clear();
                    InventoryDB.Instance.ClearSlotImage();
                    miniGame.GetComponent<Minigame>().conclude = false;
                    miniGame.SetActive(false);
                }
                else
                {
                    miniGame.GetComponent<Minigame>().conclude = false;
                    miniGame.SetActive(false);
                }
            }
        }
    }
    void OnMove(InputValue value)
    {
        inputV = value.Get<Vector2>();
    }
    private void LateUpdate()
    {
        if (miniGame.activeSelf == false)
        {
            if (inputV.x != 0 && inputV.y == 0)
            {
                _anim.SetFloat("speedX", inputV.magnitude);
                _anim.SetFloat("speedY", 0);

                _sprite.flipX = inputV.x > 0;
            }
            else if (inputV.x == 0 & inputV.y > 0)
            {
                _anim.SetTrigger("UpTrigger");
                _anim.SetFloat("speedX", 0);
                _anim.SetFloat("speedY", inputV.magnitude);
            }
            else if (inputV.x == 0 & inputV.y < 0)
            {
                _anim.SetTrigger("DownTrigger");
                _anim.SetFloat("speedX", 0);
                _anim.SetFloat("speedY", inputV.magnitude);
            }
            else if (inputV.x == 0 & inputV.y == 0)
            {
                _anim.Play("Idle");
            }
        }
        else
        {
            _anim.Play("Idle");
        }
    }
}
