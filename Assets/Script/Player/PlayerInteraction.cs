using UnityEngine;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private Image _crosshair;
    [SerializeField] float _maxDistance;
    private Transform _cameraTransform;
    private IUsable _target;
    private RaycastHit _hit;

    private void Awake()
    {
        _cameraTransform = GetComponentInChildren<Camera>().transform;
    }

    private void Update()
    {
        FindTarget();
        UseTarget();
        ChangeCrossHairState();
    }

    void FindTarget()
    {
        Physics.Raycast(_cameraTransform.position, _cameraTransform.forward, out _hit, _maxDistance);
        if(_hit.collider != null)
        {
            _target = _hit.collider.GetComponent<IUsable>();
        }
        else
            _target = null;
    }

    void UseTarget()
    {
        if(Input.GetButtonDown("Use") && _target != null)
        {
            _target.Use();
        }
    }

    void ChangeCrossHairState()
    {
        if(_target != null)
        {
            _crosshair.color = Color.blue;
        }
        else
            _crosshair.color = Color.white;

    }
}
