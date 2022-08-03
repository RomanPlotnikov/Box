using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerValuesSetter : MonoBehaviour
{
    [Header("Scale")]
    [SerializeField] private Slider _widthSlider;
    [SerializeField] private Slider _heightSlider;
    [SerializeField][Range(0.1f, 0.9f)] private float _scaleLimit;
    [Header("Material")]
    [SerializeField] private Renderer _playerRenderer;
    [Header("Physcs")]
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Button _jumpButton;
    [SerializeField] private float _jumpForce;
    private bool _isGrounded;

    public event UnityAction PositionChanged;

    private void Awake()
    {
        SetScaleLimits(_widthSlider, _scaleLimit);
        SetScaleLimits(_heightSlider, _scaleLimit);

        _widthSlider.value = transform.localScale.x;
        _heightSlider.value = transform.localScale.y;
    }

    private void OnEnable()
    {
        _widthSlider.onValueChanged.AddListener(SetWidth);
        _heightSlider.onValueChanged.AddListener(SetHeight);
        _jumpButton.onClick.AddListener(Jump);
    }

    private void OnDisable()
    {
        _heightSlider.onValueChanged.RemoveListener(SetHeight);
        _widthSlider.onValueChanged.RemoveListener(SetWidth);
        _jumpButton.onClick.RemoveListener(Jump);
    }

    private void Update()
    {
        if (!_isGrounded)
            PositionChanged.Invoke();
    }

    private void OnCollisionStay(Collision collision)
    {
        _isGrounded = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        _isGrounded = false;
    }

    private void SetScaleLimits(Slider slider, float scaleLimit)
    {
        slider.minValue = 1f - scaleLimit;
        slider.maxValue = 1f + scaleLimit;
    }

    private void SetHeight(float heith)
    {
        transform.localScale = new Vector3(transform.localScale.x, heith, transform.localScale.z);
        PositionChanged?.Invoke();
    }

    private void SetWidth(float width)
    {
        transform.localScale = new Vector3(width, transform.localScale.y, width);
        PositionChanged?.Invoke();
    }

    public void SetPlayerMaterial(Material material)
    {
        _playerRenderer.material = material;
    }

    private void Jump()
    {
        if (_isGrounded)
            _rigidbody.AddForce(Vector3.up * _jumpForce, ForceMode.VelocityChange);
    }
}