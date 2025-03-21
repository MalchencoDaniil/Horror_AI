using UnityEngine;

public class EnemyIdleState : State
{
    public override void Enter()
    {
        Debug.Log("Я вошел в состояние покоя");
    }

    public override void Exit()
    {
        Debug.Log("Я вышел из состояния покоя");
    }

    public override void Update()
    {
        Debug.Log("Я в состоянии покоя");
    }
}