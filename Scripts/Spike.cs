using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEngine.EventSystems.EventTrigger;

public class Spike : MonoBehaviour
{
    PlayerMovement PM;
    public GameObject GM;

    [SerializeField] private float _dmg = 1f;
    [SerializeField] private Transform _Up;
    [SerializeField] private Transform _Down;
    [SerializeField] private float cooldown = 3f;
    [SerializeField] private float cooldownMax = 3f;
    [SerializeField] private float Stay = 1f;
    [SerializeField] private float StayMax = 1f;

    public UnityEvent TriggerEvent;

    // Start is called before the first frame update
    void Start()
    {
        PM = GM.GetComponent<PlayerMovement>();

        transform.position = _Down.position;
    }

    private void Update()
    {
        cooldown -= 1f;

        if (cooldown <= 0f)
        {
            transform.position = _Up.position;
            Stay -= 1f;

            if (Stay <= 0f)
            {
                transform.position = _Down.position;
                cooldown += cooldownMax;
                Stay += StayMax;
            }


        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            PM._health -= _dmg;
        }
    }

}
