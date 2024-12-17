using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedZone : MonoBehaviour
{
    [SerializeField] private float _speedChange = 200;

    AudioSource audioSource;

    PlayerMovement PM;
    public GameObject GM;

    // Start is called before the first frame update
    void Start()
    {
        PM = GM.GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PM._speed += _speedChange;
        GetComponent<AudioSource>().Play();
    }

    private void OnTriggerExit(Collider other)
    {
        PM._speed -= _speedChange;
    }
}
