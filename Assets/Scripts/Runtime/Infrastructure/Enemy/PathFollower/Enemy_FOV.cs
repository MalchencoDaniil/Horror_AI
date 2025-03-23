using System.Collections;
using UnityEngine;

public class Enemy_FOV : MonoBehaviour
{
    [Range(0, 360)]
    [SerializeField]
    private float _viewAngle = 90f;
    [SerializeField]
    private Transform _player;
    [SerializeField]
    private LayerMask _obstacleMask;

    [HideInInspector]
    public bool _playerInSight;

    private void Start()
    {
        StartCoroutine(FindTargetWithDelay(0.2f));
    }

    private IEnumerator FindTargetWithDelay(float _delay)
    {
        while (true)
        {
            yield return new WaitForSeconds(_delay);
            FindVisibleTarget();
        }
    }

    private void FindVisibleTarget()
    {
        _playerInSight = false;

        Vector3 _directionToTarget = (_player.position - transform.position).normalized;

        if (Vector3.Angle(transform.forward, _directionToTarget) < _viewAngle / 2)
        {
            float _distanceToTarget = Vector3.Distance(transform.position, _player.position);

            if (!Physics.Raycast(transform.position, _directionToTarget, _distanceToTarget, _obstacleMask))
            {
                _playerInSight = true;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Vector3 _viewAngleA = DirectionFromAngle(transform.eulerAngles.y, -_viewAngle / 2);
        Vector3 _viewAngleB = DirectionFromAngle(transform.eulerAngles.y, _viewAngle / 2);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.position + _viewAngleA * 6);
        Gizmos.DrawLine(transform.position, transform.position + _viewAngleB * 6);

        if (_player != null && _playerInSight)
        {
            Gizmos.color = Color.green;
            Gizmos.DrawLine(transform.position, _player.position);
        }
    }

    private Vector3 DirectionFromAngle(float _eulerY, float _angleInDegrees)
    {
        _angleInDegrees += _eulerY;
        return new Vector3(Mathf.Sin(_angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(_angleInDegrees * Mathf.Deg2Rad));
    }
}