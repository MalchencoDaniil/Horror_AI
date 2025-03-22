using UnityEngine;

public class EnemyIdleState : State
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    public override void Enter()
    {
        _enemy._navMeshAgent.isStopped = true;
    }

    public override void Exit()
    {
        _enemy._navMeshAgent.isStopped = false;
    }

    public override void UpdateState()
    {

    }
}