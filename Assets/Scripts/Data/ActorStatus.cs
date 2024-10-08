using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatus
{
    public int playerHP = 30;
    public void GetHP(int amount)
    {
    }
    public void ReduceHP(int amount)
    {
    }
}
public class MonsterStatus
{
    public int playerHP = 30;
    public void GetHP(int amount)
    {
    }
    public void ReduceHP(int amount)
    {
    }
}
public class MonsterAttributes 
{
    public float moveSpeed { get; private set; }
    public float originSpeed { get; private set; }
    public void SetMoveSpeed(float amount)
    {
        moveSpeed = amount;
    }
    public void ResetMoveSpeed()
    {
        moveSpeed = originSpeed;
    }
}