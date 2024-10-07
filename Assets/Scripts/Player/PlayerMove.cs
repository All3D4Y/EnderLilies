using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float maxSpeed = 10.0f;
    public float onAirSpeed = 0.1f;
    public float jumpPower = 5.0f;
    //public float dodgeXPower = 10.0f;
    //public float dodgeYPower = 1.0f;

    // Components
    PlayerInput input;
    Rigidbody2D rigid;
    SpriteRenderer sR;

    // Variables
    Vector2 moveDir = Vector2.zero;
    Vector2 limitXSpeedVec; 
    bool onAir = true;
    bool canDoubleJump = true;
    int isRight = 1;
    [SerializeField]
    int jumpCount = -1;
    WaitForSeconds wait = new WaitForSeconds(0.05f);

    // Properties
    public bool CanDoubleJump
    {
        get => canDoubleJump;
        set => canDoubleJump = value;
    }

    int JumpCount
    {
        get => jumpCount;
        set
        {
            if (value != jumpCount)
            {
                jumpCount = value;
            }
        }
    }

    void Awake()
    {
        input = GetComponent<PlayerInput>();
        rigid = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
    }

    void Start()
    {
        JumpCountReset();
    }

    void OnEnable()
    {
        input.onMove += Move;
        input.onJump += Jump;
        input.onAttack += Attack;
        input.onDodge += Dodge;
    }

    void OnDisable()
    {
        input.onMove -= Move;
        input.onJump -= Jump;
        input.onAttack -= Attack;
        input.onDodge -= Dodge;
    }

    void Update()
    {
        sR.flipX = isRight == -1;
    }
    void FixedUpdate()
    {
        if (!onAir)
        {
            rigid.AddForce(moveSpeed * moveDir, ForceMode2D.Force);
            if (rigid.velocity.x > maxSpeed || rigid.velocity.x < -maxSpeed)
            {
                rigid.velocity = isRight * new Vector2(maxSpeed, rigid.velocity.y); 
            }
        }
        else
        {
            //rigid.transform.Translate(onAirSpeed * Time.deltaTime * moveDir);
            if ((rigid.velocity.x > 0 && moveDir.x < 0) || (rigid.velocity.x < 0 && moveDir.x > 0))
            {
                // 공중에서 진행방향, 입력방향 다르면
                rigid.AddForce(onAirSpeed * moveDir, ForceMode2D.Force);
            }
        }
    }

    void Move(Vector2 input, bool isPressed)
    {
        if (isPressed)
        {
            moveDir = input;
            isRight = input.x > 0 ? 1 : -1;
        }
        else
        {
            moveDir = Vector2.zero;
        }
    }

    void Jump()
    {
        // 바닥인지, 2단점프 구현
        if (IsJumpAvailable())
        {
            rigid.AddForce(jumpPower * Vector2.up, ForceMode2D.Impulse);
            JumpCount--;
            onAir = true;
            StopAllCoroutines();
        }
    }

    void Attack()
    {
        // Animation + Attack Area Collider Enable
    }

    void Dodge()
    {
        // RootAnimation 으로 처리

        //Vector2 dodgeDir = isRight * dodgeXPower * Vector2.right + dodgeYPower * Vector2.up; 
        //if (!onAir)
        //{
        //    rigid.AddForce(dodgeDir, ForceMode2D.Impulse);
        //    onAir = true;
        //}
        //
    }

    bool IsJumpAvailable()
    {
        bool result = false;
        if (JumpCount > 0)
        {
            result = true;
        }
        return result;
    }

    public void JumpCountReset()
    {
        if (rigid.velocity.y < 0.01f && onAir)
        {
            JumpCount = CanDoubleJump ? 2 : 1;
            StartCoroutine(JumpCountResetCoroutine());
        }
    }

    IEnumerator JumpCountResetCoroutine()
    {
        yield return wait;
        onAir = false;
    }

#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + isRight * Vector3.right);
    }
#endif
}
