using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Actor
{
    float moveX;
    float moveY;
    public float inputMagnitude { get; private set; }
    public float decayRate = 2f;
    public float moveSpeed = 10;

    private void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {
        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        Vector2 moveDirection = new Vector2(moveX, moveY).normalized;
        transform.position += (Vector3)moveDirection * moveSpeed * Time.deltaTime;

        if (moveDirection.magnitude > 0)
        {
            inputMagnitude = moveDirection.magnitude;
        }
        else
        {
            inputMagnitude = Mathf.Lerp(inputMagnitude, 0, decayRate * Time.deltaTime);
            if (inputMagnitude < 0.8f)
            {
                inputMagnitude = 0;
            }
        }
    }
    public override void ReceiveEvent(IEvent iEvent)
    {
        throw new System.NotImplementedException();
    }
}
