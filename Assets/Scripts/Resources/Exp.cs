using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exp : MonoBehaviour
{
    public Player player;

    public float moveSpeed;
    public float rotSpeed;
    Vector3 initializedPos;
    Vector3 dir;
    bool isActiveObj = false;
    private void Update()
    {
        if (!isActiveObj)
        {
            ActiveExpObj();
        }
        else
        {
            MoveToPlayer();
            RotToPlayer();
        }
    }
    private void OnEnable()
    {
        dir = transform.position - player.transform.position;
        initializedPos = transform.position + dir.normalized * 2;
    }
    private void OnDisable()
    {
        isActiveObj = false;
    }
    void ActiveExpObj()
    {
        if (Vector3.Distance(transform.position, initializedPos) > 0.3f)
        {
            transform.position = Vector3.Lerp(transform.position, initializedPos, Time.deltaTime * moveSpeed * 2);

            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, dir);
            transform.rotation = targetRotation;
        }
        else
        {
            isActiveObj = true;
        }
    }
    void MoveToPlayer()
    {
        transform.position = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * moveSpeed);
    }
    void RotToPlayer()
    {
        Vector3 dir = player.transform.position - transform.position;

        if (dir != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, dir);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotSpeed * Time.deltaTime);
        }
    }
}
