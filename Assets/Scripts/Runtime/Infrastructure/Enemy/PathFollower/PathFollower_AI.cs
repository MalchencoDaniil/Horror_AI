using UnityEngine;
using Cysharp.Threading.Tasks;

public class PathFollower_AI : Enemy
{
    private StateMachine _stateMachine;

    private Enemy_FOV _enemyFOV;

    private EnemyIdleState _enemyIdleState;
    private EnemyWalkState _enemyWalkState;
    private EnemyChaseState _enemyChaseState;

    [Header("Detection")]
    [SerializeField]
    private float _detectionRadius = 3;
    [SerializeField] private Color _detectionRangeColor;

    [SerializeField]
    private float _chaseDistance = 10;

    [Header("Stop Settings")]
    [SerializeField]
    private bool _canStopping = true;

    [SerializeField, Range(0, 10)]
    private float _stopTime = 1;

    private void Start()
    {
        _stateMachine = new StateMachine();
        _enemyFOV = GetComponent<Enemy_FOV>();

        _enemyIdleState = GetComponent<EnemyIdleState>();
        _enemyWalkState = GetComponent<EnemyWalkState>();
        _enemyChaseState = GetComponent<EnemyChaseState>();

        _stateMachine.Initialize(_enemyIdleState);
    }

    private void Update()
    {
        _stateMachine._currentState.UpdateState();

        float _distanceToTarget = Vector3.Distance(transform.position, _target.position);

        if (_distanceToTarget <= _detectionRadius || (_enemyFOV._playerInSight && _distanceToTarget <= _chaseDistance))
            Chase();
        else if (_enemyWalkState._stopInPoint && _canStopping)
            Stop().Forget();
        else
            Walk();
    }

    private async UniTask Stop()
    {
        Idle();

        await UniTask.WaitForSeconds(_stopTime);

        _enemyWalkState._stopInPoint = false;
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

    private void OnDrawGizmos()
    {
        Gizmos.color = _detectionRangeColor;
        Gizmos.DrawWireSphere(transform.position, _detectionRadius);
    }
}