using UnityEngine;

public class EnemyChaseState : State
{
    private Enemy _enemy;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    public override void Enter()
    {
        _enemy._enemyAnimator.SetBool("CanRun", true);
    }

    public override void Exit()
    {
        _enemy._enemyAnimator.SetBool("CanRun", false);
    }

    public override void UpdateState()
    {
        _enemy._navMeshAgent.SetDestination(_enemy._target.position);
    }
}