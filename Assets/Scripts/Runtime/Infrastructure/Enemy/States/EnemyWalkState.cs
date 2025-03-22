using UnityEngine;

public class EnemyWalkState : State
{
    private Enemy _enemy;

    private int _currentWaypointId = 0;

    [SerializeField]
    private WaypointPath _waypointPath;

    [SerializeField, Range(0, 5)]
    private float _stopDistance = 1.3f;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    public override void Enter()
    {
        _enemy._enemyAnimator.SetBool("CanWalk", true);
    }

    public override void Exit()
    {
        _enemy._enemyAnimator.SetBool("CanWalk", false);
    }

    public override void UpdateState()
    {
        _enemy._navMeshAgent.SetDestination(_waypointPath._pathPoints[_currentWaypointId].position);

        float _distanceToPoint = Vector3.Distance(transform.position, _waypointPath._pathPoints[_currentWaypointId].position);

        if (_distanceToPoint < _stopDistance)
        {
            CheckWaypointID();
        }
    }

    private bool _moveForward = true;

    private void CheckWaypointID()
    {
        if (_waypointPath.IsLooped)
        {
            _currentWaypointId = (_currentWaypointId + 1) % _waypointPath._pathPoints.Count;
        }
        else
        {
            if (_moveForward)
            {
                _currentWaypointId++;

                if (_currentWaypointId >= _waypointPath._pathPoints.Count - 1)
                    _moveForward = false;
            }
            else
            {
                _currentWaypointId--;

                if (_currentWaypointId <= 0 && !_moveForward)
                    _moveForward = true;
            }
        }
    }
}