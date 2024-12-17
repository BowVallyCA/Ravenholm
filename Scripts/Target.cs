using Unity.VisualScripting;
using UnityEngine;

public class Target : MonoBehaviour
{
    private bool _isTargeted = false;
    [SerializeField] Transform _Hold;
    Rigidbody rb;
    [SerializeField] float _throwSpeed = 100f;
    [SerializeField] Transform _Trap;

    CubeTrap CP;
    public GameObject GM;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        CP = GM.GetComponent<CubeTrap>();
    }

    public void StartTarget()
    {
        if (_isTargeted == true)
        {
            transform.position = _Hold.position;
            rb.useGravity = false;
        }


        //Destroy(gameObject);


    }

    public void StopTarget()
    {
        if(CP.isTriggering == false)
        {
            _isTargeted = true;
            rb.useGravity = true;
        }

    }

    public void Throw()
    {
        _isTargeted = false;
        rb.useGravity = true;
        rb.AddForce(_Hold.transform.forward * _throwSpeed, ForceMode.Impulse);
    }

    public void TrapTarget()
    {
        _isTargeted = false;
        transform.position = _Trap.position;
        rb.useGravity = false;
    }
}
