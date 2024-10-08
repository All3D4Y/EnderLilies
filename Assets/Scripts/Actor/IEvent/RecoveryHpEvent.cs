using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RecoveryHpEvent : IEvent
{
    public int recovery;

    public RecoveryHpEvent(int recovery)
    {
        this.recovery = recovery;
    }
    public void ExcuteEvent(IActor target)
    {
        target.ReceiveEvent(this);
    }
}
