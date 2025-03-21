using UnityEngine;

public class EnemyWalkState : State
{
    public override void Enter()
    {
        Debug.Log("Я вошел в состояние прогулки");
    }

    public override void Exit()
    {
        Debug.Log("Я вышел из состояния прогулки");
    }

    public override void Update()
    {
        Debug.Log("Я в состоянии прогулки");
    }
}