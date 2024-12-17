using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    PlayerMovement PM;
    public GameObject GM;

    AudioSource audioSource;

    [SerializeField] private Transform _thisCheckPoint;

    // Start is called before the first frame update
    void Start()
    {
        PM = GM.GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PM._spawnPoint = _thisCheckPoint;
        GetComponent<AudioSource>().Play();
    }
}
