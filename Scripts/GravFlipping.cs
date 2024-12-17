using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravFlipping : MonoBehaviour
{
    [SerializeField] Transform Cam;

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
        PM.gravity = -20;
        Cam.Rotate(0, 0, 180);
        GetComponent<AudioSource>().Play();
    }

    //if you want the players gravity back after exiting the trigger
    //private void OnTriggerExit(Collider other)
    //{
    //    PM.gravity = 10;
    //    Cam.Rotate(0, -180, 0);
    //}
}
