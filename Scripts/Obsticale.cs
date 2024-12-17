using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obsticale : MonoBehaviour
{
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Box"))
        {
            GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }
}
