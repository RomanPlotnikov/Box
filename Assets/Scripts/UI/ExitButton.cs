using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private Button _exitButton;

    private void OnEnable()
    {
        _exitButton.onClick.AddListener(Application.Quit);
    }

    private void OnDisable()
    {
        _exitButton.onClick.RemoveListener(Application.Quit);
    }
}