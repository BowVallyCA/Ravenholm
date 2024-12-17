using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CubeTrap : MonoBehaviour
{
    //[SerializeField] private Transform _trapPoint;
    public bool isTriggering = false;

    AudioSource audioSource;

    private Target _targetObj;
    public GameObject GM;

    // Start is called before the first frame update
    void Start()
    {
        _targetObj = GM.GetComponent<Target>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            //_targetObj = target;
            isTriggering = true;
            _targetObj.TrapTarget();
            GetComponent<AudioSource>().Play();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isTriggering = false ;
    }
}
