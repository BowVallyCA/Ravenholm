using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WreckingBall : MonoBehaviour
{
    Rigidbody rb;

    AudioSource audioSource;

    PlayerMovement PM;
    public GameObject GM;

    [SerializeField] private float _dmg = 5f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        PM = GM.GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();

        rb.useGravity = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            rb.useGravity = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PM._health -= _dmg;
            GetComponent<AudioSource>().Play();
        }
    }
}
