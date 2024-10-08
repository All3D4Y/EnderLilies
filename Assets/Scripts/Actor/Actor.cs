using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actor : MonoBehaviour, IActor
{
    Animator anim;


    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public abstract void ReceiveEvent(IEvent iEvent);
}
