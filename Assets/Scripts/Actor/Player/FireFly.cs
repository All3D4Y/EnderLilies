using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFly : MonoBehaviour
{
    public Player player;
    public float moveSpeed;
    private Vector2 targetPos;
    public bool isFreeMoving;
    private void OnEnable()
    {
        targetPos = GetRandomTargetPosition();
        Debug.Log(targetPos);
    }
    private void Update()
    {
        if (isFreeMoving)
        {
            MoveFree();
            RotToFreeMove();
        }
        else
        {
            RotToPlayer();
        }
    }
    public void StartFreeMove()
    {
        isFreeMoving = true;
        targetPos = GetRandomTargetPosition();
    }
    public void StopFreeMove()
    {
        isFreeMoving = false;
    }
    private void MoveFree()
    {
        transform.localPosition = Vector2.Lerp(transform.localPosition, targetPos, moveSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.localPosition, targetPos) < 0.1f)
        {
            targetPos = GetRandomTargetPosition();
            Debug.Log(targetPos);
        }
    }
    void RotToFreeMove()
    {
        Vector2 dir = (targetPos - (Vector2)transform.localPosition).normalized;

        if (Vector2.Angle(transform.up, dir) > 1f)
        {
            transform.up = dir;
        }
    }
    private Vector2 GetRandomTargetPosition()
    {
        return new Vector2(UnityEngine.Random.Range(-1, 2), UnityEngine.Random.Range(-1, 2));
    }
    public void RotToPlayer()
    {
        Vector2 dir = (player.transform.localPosition - transform.position).normalized;

        if (Vector2.Angle(transform.up, dir) > 1f)
        {
            transform.up = dir;
        }
    }
}
