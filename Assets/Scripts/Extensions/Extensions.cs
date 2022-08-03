using System.Collections.Generic;
using TMPro;
using UnityEngine;

public static class Extensions
{
    public static void SetOptionsName<T>(this TMP_Dropdown dropdown, List<T> list) where T : MonoBehaviour
    {
        dropdown.ClearOptions();

        List<string> optionsName = new List<string>(list.Count);

        foreach (T item in list)
            optionsName.Add(item.name);

        dropdown.AddOptions(optionsName);
    }
}