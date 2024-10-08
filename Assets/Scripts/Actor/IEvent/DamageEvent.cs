using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DamageEvent : IEvent
{
    public int damage;

    public DamageEvent(int damage)
    {
        this.damage = damage;
    }
    public void ExcuteEvent(IActor target)
    {
        target.ReceiveEvent(this);
    }
}
