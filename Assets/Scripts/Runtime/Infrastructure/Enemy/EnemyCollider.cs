using UnityEngine;
using UnityEngine.Events;

public class EnemyCollider : MonoBehaviour
{
    [SerializeField]
    private UnityEvent _onPlayerEnter;

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.gameObject.GetComponent<Player>() && _onPlayerEnter != null)
            _onPlayerEnter.Invoke();
    }
}