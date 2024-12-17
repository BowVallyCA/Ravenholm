using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    PlayerMovement PM;
    public GameObject GM;

    AudioSource audioSource;

    [SerializeField] private float _dmg = 5f;

    // Start is called before the first frame update
    void Start()
    {
        PM = GM.GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PM._health -= _dmg;
            GetComponent<AudioSource>().Play();
        }
    }
}
