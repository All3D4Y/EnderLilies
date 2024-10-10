using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
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
        if (collision.CompareTag("Ground"))
        {
            //Debug.Log(collision.gameObject.name);
            playerMove.JumpCountReset();
            playerMove.OnAir = false;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            playerMove.JumpCountReset();
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            playerMove.OnAir = true;
        }
    }
}
