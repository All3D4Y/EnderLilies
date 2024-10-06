using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    PlayerMove playerMove;

    void Awake()
    {
        playerMove = GetComponentInParent<PlayerMove>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log(collision.gameObject.name);
            playerMove.JumpCountReset();
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            playerMove.JumpCountReset();
        }
    }
}
