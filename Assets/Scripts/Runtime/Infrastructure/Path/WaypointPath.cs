using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class WaypointPath : MonoBehaviour
{
    public List<Transform> _pathPoints = new List<Transform>();

    [SerializeField]
    private Color _pathColor = Color.green;

    [SerializeField, Range(0, 1)]
    private float _handleSize = 0.3f;

    [SerializeField]
    private GameObject _pointPrefab;

    [SerializeField]
    private bool _isLooped = false;

    public bool IsLooped
    {
        get { return _isLooped; }
        set { _isLooped = value; }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = _pathColor;

        if (_pathPoints.Count > 0)
        {
            for (int i = 0; i < _pathPoints.Count - 1; i++)
            {
                Gizmos.DrawSphere(_pathPoints[i].position, _handleSize);

                if (_pathPoints[i] != null && _pathPoints[i + 1] != null)
                {
                    Gizmos.DrawLine(_pathPoints[i].position, _pathPoints[i + 1].position);
                }
            }

            Gizmos.DrawSphere(_pathPoints[_pathPoints.Count - 1].position, _handleSize);

            if (_isLooped && _pathPoints[0] != null && _pathPoints[_pathPoints.Count - 1] != null)
            {
                Gizmos.DrawLine(_pathPoints[_pathPoints.Count - 1].position, _pathPoints[0].position);
            }
        }
    }

    public void AddPoint()
    {
        GameObject _newPoint = Instantiate(_pointPrefab, this.transform);
        _newPoint.name = "Point " + _pathPoints.Count;

        Transform _pointTransform = _newPoint.GetComponent<Transform>();
        _pathPoints.Add(_pointTransform);

        if (_pathPoints.Count > 2)
            _pathPoints[_pathPoints.Count - 1].position = _pathPoints[_pathPoints.Count - 2].position;

#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this);
#endif

#if UNITY_EDITOR
        Selection.activeGameObject = _newPoint;
#endif
    }

    public void ClearPoints()
    {
        foreach (Transform _point in _pathPoints)
        {
            if (_point != null)
            {
                DestroyImmediate(_point.gameObject);
            }
        }
        _pathPoints.Clear();
#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this);
#endif
    }
}