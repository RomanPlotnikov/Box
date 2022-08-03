using System.Collections.Generic;
using UnityEngine;

public class EyeContainer : MonoBehaviour
{
    [SerializeField] private List<Eye> _eyes;

    public List<Eye> Items => _eyes;

    public void UpdateEyePosition()
    {
        foreach (Eye eye in _eyes)
            eye.MoveToTarget();
    }
}