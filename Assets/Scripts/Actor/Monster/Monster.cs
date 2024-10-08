using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : Actor
{
    public FSMController<Monster> fsmController { get; private set; }
    public MonsterStatus monsterStatus { get; private set; }
    public MonsterAttributes monsterAttributes { get; private set; }
    public MonsterAttack monsterAttack { get; private set; }
    MonsterDetector monsterDetector;
    private void Awake()
    {
        monsterDetector = GetComponent<MonsterDetector>();
        monsterAttack = GetComponent<MonsterAttack>();
    }

    protected void Update()
    {
        fsmController.FSMUpdate();
    }
    public override void ReceiveEvent(IEvent iEvent)
    {
        throw new System.NotImplementedException();
    }
}
