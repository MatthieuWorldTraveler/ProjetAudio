using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _normalSpeed = 12f;
    [SerializeField] private float _sprintSpeed = 25f;

    private Transform _transform;
    private CharacterController _characterController;
    private AudioSource _audioSource;

    private void Awake()
    {
        _transform = transform;
        _characterController = GetComponent<CharacterController>();
        _audioSource = GetComponentInChildren<AudioSource>();
    }
    private void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        float actualSpeed = Input.GetAxisRaw("Sprint") != 0f ? _sprintSpeed : _normalSpeed;

        Vector3 direction = _transform.right * horizontal + _transform.forward * vertical;
        Vector3 move = direction * actualSpeed * Time.deltaTime;
        _characterController.Move(move);
        _audioSource.pitch = Mathf.Clamp(_characterController.velocity.magnitude / _normalSpeed, 0f, 2f);
    }
}

