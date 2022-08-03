using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Dresser : MonoBehaviour
{
    [SerializeField] private PlayerValuesSetter _playerValueSetter;
    [Header("UI Components")]
    [SerializeField] private Toggle _hatToggle;
    [SerializeField] private TMP_Dropdown _hatDropdown;
    [Header("Containers")]
    [SerializeField] private HatContainer _hatContainer;
    [SerializeField] private EyeContainer _eyeContainer;

    private void OnEnable()
    {
        _hatDropdown.SetOptionsName(_hatContainer.Items);

        _hatToggle.onValueChanged.AddListener(EnableHat);
        _hatDropdown.onValueChanged.AddListener(ChangeHat);
        _playerValueSetter.PositionChanged += _hatContainer.UpdateHatPosition;
        _playerValueSetter.PositionChanged += _eyeContainer.UpdateEyePosition;
    }

    private void OnDisable()
    {
        _hatToggle.onValueChanged.RemoveListener(EnableHat);
        _hatDropdown.onValueChanged.RemoveListener(ChangeHat);
        _playerValueSetter.PositionChanged -= _hatContainer.UpdateHatPosition;
        _playerValueSetter.PositionChanged -= _eyeContainer.UpdateEyePosition;
    }

    private void EnableHat(bool enable)
    {
        _hatContainer.gameObject.SetActive(enable);
        _hatDropdown.gameObject.SetActive(enable);
    }

    private void ChangeHat(int index)
    {
        foreach (Hat hat in _hatContainer.Items)
            hat.gameObject.SetActive(false);

        _hatContainer.Items[index].gameObject.SetActive(true);
    }
}