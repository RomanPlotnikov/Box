using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WallpaperChanger : MonoBehaviour
{
    [SerializeField] private List<Material> _materials;
    [SerializeField] private Renderer _backgroundRenderer;
    [SerializeField] private TMP_Dropdown _wallpaperDropdown;

    private void OnEnable()
    {
        _wallpaperDropdown.onValueChanged.AddListener(ChangeWallaper);
    }

    private void OnDisable()
    {

        _wallpaperDropdown.onValueChanged.RemoveListener(ChangeWallaper);
    }

    private void ChangeWallaper(int index)
    {
        _backgroundRenderer.material = _materials[index];
    }
}