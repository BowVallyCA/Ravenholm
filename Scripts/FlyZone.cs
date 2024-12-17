using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyZone : MonoBehaviour
{
    PlayerMovement PM;
    public GameObject GM;

    AudioSource audioSource;

    [SerializeField] float _jumpPower = 10;

    // Start is called before the first frame update
    void Start()
    {
        PM = GM.GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        PM.movingDirection.y = PM.jumpSpeed + _jumpPower;

        PM.movingDirection.y -= PM.gravity * Time.deltaTime;
        PM.controller.Move(PM.movingDirection * Time.deltaTime);

        GetComponent<AudioSource>().Play();
    }

    private void OnTriggerExit(Collider other)
    {
        
    }
}
