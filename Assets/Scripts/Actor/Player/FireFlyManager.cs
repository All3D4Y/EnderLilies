using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlyManager : MonoBehaviour
{
    public Player player;
    public float moveSpeed = 3;
    public float distanceFromPlayer = 3;
    FireFly[] fireFly;
    float elapsedTime = 0;
    float intervalTime = 0.2f;
    private void Awake()
    {
        fireFly = GetComponentsInChildren<FireFly>();
    }
    private void Update()
    {
        if (player.inputMagnitude == 0)
        {
            foreach (FireFly firefly in fireFly)
            {
                if (!firefly.isFreeMoving)
                {
                    firefly.StartFreeMove();
                }
            }
        }
        else
        {
            foreach (FireFly firefly in fireFly)
            {
                firefly.StopFreeMove();
            }
            MoveToPlayer();

        }
        if (Vector2.Distance(player.transform.position, transform.position) > distanceFromPlayer)
        {
            moveSpeed = 5;
            MoveToPlayer();
        }
        else
        {
            moveSpeed = 3;
        }
    }

    void MoveToPlayer()
    {
        Vector2 dir = (player.transform.position - transform.position).normalized;
        if (Vector2.Distance(transform.position, player.transform.position) > 1f)
        {
            transform.position += (Vector3)dir * moveSpeed * Time.deltaTime;
            foreach (FireFly firefly in fireFly)
            {
                firefly.RotToPlayer();
            }
        }
    }
}
