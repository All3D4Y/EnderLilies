using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMove : MonoBehaviour
{
    Monster monster;
    [SerializeField] GameObject warePoint;
    List<Vector2> monsterMovePos = new List<Vector2>();
    Vector2 targetPos;
    int warePointIndex = 0;
    private void Awake()
    {
        monster = GetComponent<Monster>();
        SetMovePos();
    }
    private void OnEnable()
    {
        warePointIndex = 0;
        targetPos = monsterMovePos[warePointIndex];
        transform.position = targetPos;
    }
    private void Update()
    {
        if (targetPos != null)
        {
            MoveWarePoint();
        }
    }
    void SetMovePos()
    {
        for (int i = 0; i < warePoint.transform.childCount; i++)
        {
            Vector2 pos = warePoint.transform.GetChild(i).transform.position;
            monsterMovePos.Add(pos);
        }
    }
    void MoveWarePoint()
    {
        if (Vector2.Distance(transform.position, targetPos) < 0.5f)
        {
            warePointIndex++;
            if (warePointIndex < monsterMovePos.Count)
            {
                targetPos = monsterMovePos[warePointIndex];
            }
            else
            {
                gameObject.SetActive(false);
                return;
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, targetPos, Time.deltaTime * monster.monsterAttributes.moveSpeed);
    }
    void MoveToPlayer()
    {

    }
}
