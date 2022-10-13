using UnityEngine;
using UnityEngine.Audio;

public class Door : MonoBehaviour, IUsable
{
    [SerializeField] private float _animDuration = 1f;
    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private float _closedDoorCutoff = 500f;
    [SerializeField] private float _openedDoorCutoff = 5000f;
    private float _animTime;
    private DoorState _state;
    private Transform _body;

    public enum DoorState
    {
        CLOSED,
        OPENING,
        OPENED,
        CLOSING
    }

    private void Awake()
    {
        _body = transform.GetChild(0);
        _state = DoorState.CLOSED;
    }

    public void Use()
    {
        if (_state == DoorState.CLOSED)
            _state = DoorState.OPENING;
        else if (_state == DoorState.OPENED)
            _state = DoorState.CLOSING;
    }

    private void Update()
    {
        if (_state == DoorState.OPENING)
        {
            if (_animTime >= _animDuration)
            {
                _state = DoorState.OPENED;
                _animTime = 0f;
            }
            else
            {
                float progress = _animTime / _animDuration;
                _body.localPosition = Vector3.Lerp(Vector3.zero, Vector3.up, progress);
                _audioMixer.SetFloat("LowpassCutoff", Mathf.Lerp(_closedDoorCutoff, _openedDoorCutoff, progress));
                _animTime += Time.deltaTime;
            }
        }
        else if (_state == DoorState.CLOSING)
        {
            if (_animTime >= _animDuration)
            {
                _state = DoorState.CLOSED;
                _animTime = 0f;
            }
            else
            {
                float progress = _animTime / _animDuration;
                _body.localPosition = Vector3.Lerp(Vector3.up, Vector3.zero, progress);
                _audioMixer.SetFloat("LowpassCutoff", Mathf.Lerp(_openedDoorCutoff, _closedDoorCutoff, progress));
                _animTime += Time.deltaTime;
            }
        }
    }


}
