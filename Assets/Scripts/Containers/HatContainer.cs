using System.Collections.Generic;
using UnityEngine;

public class HatContainer : MonoBehaviour 
{
    [SerializeField] private List<Hat> _hats;

    public List<Hat> Items => _hats;

    public void UpdateHatPosition()
    {
        foreach (Hat hat in _hats)
         hat.MoveToTarget();
    }
}