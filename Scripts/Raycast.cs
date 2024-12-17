using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{
    [SerializeField] private Transform targetOrigin;
    [SerializeField] private float targetDistance = 1000f;
    [SerializeField] private LayerMask hitLayer;
    [SerializeField] private Rigidbody _Rb;

    AudioSource audioSource;

    private Target _targetObj;

    public bool _enabled = true;

    private void Start()
    {
        _Rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 orgin = targetOrigin.position;
        RaycastHit hit;

        Debug.DrawLine(orgin, targetOrigin.transform.forward * targetDistance, Color.green);

        if (/*_enabled = true &&*/ Physics.Raycast(orgin, targetOrigin.forward, out hit, targetDistance, hitLayer) && Input.GetMouseButton(0))
        {
            Debug.Log("Hit Target!");
            if (hit.collider.gameObject.TryGetComponent<Target>(out Target target))
            {
                if (Input.GetMouseButtonDown(1))
                {
                    GetComponent<AudioSource>().Play();
                    Debug.Log("I made it!");
                    _targetObj?.Throw();
                    _targetObj = null;
                }
                else
                {
                    _targetObj = target;
                    target.StartTarget();
                }
            }

        }
        else
        {
            _targetObj?.StopTarget();
            _targetObj = null;
        }
    }
}
