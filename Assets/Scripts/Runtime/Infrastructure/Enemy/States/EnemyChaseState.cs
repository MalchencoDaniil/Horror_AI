using UnityEngine;

public class EnemyChaseState : State
{
    public override void Enter()
    {
        Debug.Log("Я вошел в состояние преследования");
    }

    public override void Exit()
    {
        Debug.Log("Я вышел из состояния преследования");
    }

    public override void Update()
    {
        Debug.Log("Я в состоянии преследования");
    }
}