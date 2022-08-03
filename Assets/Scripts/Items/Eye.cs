using UnityEngine;

public class Eye : MonoBehaviour
{
    [SerializeField] private Transform _target;

    public void MoveToTarget()
    {
        transform.position = _target.position;
        transform.rotation = _target.rotation;
    }
}