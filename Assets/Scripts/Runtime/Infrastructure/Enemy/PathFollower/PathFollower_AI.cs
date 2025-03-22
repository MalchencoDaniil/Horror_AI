using UnityEngine;

public class PathFollower_AI : Enemy
{
    private StateMachine _stateMachine;

    private EnemyIdleState _enemyIdleState;
    private EnemyWalkState _enemyWalkState;
    private EnemyChaseState _enemyChaseState;

    private void Start()
    {
        _stateMachine = new StateMachine();

        _enemyIdleState = GetComponent<EnemyIdleState>();
        _enemyWalkState = GetComponent<EnemyWalkState>();
        _enemyChaseState = GetComponent<EnemyChaseState>();

        _stateMachine.Initialize(_enemyIdleState);
    }

    private void Update()
    {
        _stateMachine._currentState.UpdateState();

        if (Input.GetKeyDown(KeyCode.Space))
            Idle();

        if (Input.GetKeyDown(KeyCode.E))
            Walk();

        if (Input.GetKeyDown(KeyCode.LeftShift))
            Chase();
    }

    protected override void Idle()
    {
        _stateMachine.ChangeState(_enemyIdleState);
    }

    protected override void Walk()
    {
        _stateMachine.ChangeState(_enemyWalkState);
    }

    private void Chase()
    {
        _stateMachine.ChangeState(_enemyChaseState);
    }
}