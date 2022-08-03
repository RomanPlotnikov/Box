using UnityEngine;

public class Hat : MonoBehaviour
{
    [SerializeField] private Transform _target;

    public void MoveToTarget()
    {
        transform.position = _target.position;
        transform.rotation = _target.rotation;
    }
}