using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] public float _speed = 100f;
    [SerializeField] private float _mouseSensitivity = 200f;
    private Vector3 _moveVector;
    private CharacterController _controller;
    public float jumpSpeed = 2.0f;
    public float gravity = 10.0f;
    public Vector3 movingDirection = Vector3.zero;
    public CharacterController controller;

    [Header("Camera")]
    [SerializeField] private float _cameraBounds = 60f;
    private Camera _camera;

    #region Smoothing code
    private Vector2 _currentMouseDelta;
    private Vector2 _currentMouseVelocity;
    [SerializeField] private float _smoothtime = .1f;
    private float _xRotation;
    #endregion

    [SerializeField] public float _health = 5f;
    [SerializeField] public Transform _spawnPoint;
    [SerializeField] private Transform _playerPoint;
    [SerializeField] private GameObject _pauseMenu;

    // Start is called before the first frame update
    void Start()
    {
        _controller = GetComponent<CharacterController>();
        _camera = GetComponentInChildren<Camera>();

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        Death();

        Movement();

        Look();
    }

    private void Movement()
    {
        //Get input from player
        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");

        if (Input.GetKey("space"))
        {
            movingDirection.y = jumpSpeed;
        }

        if (Input.GetKey(KeyCode.R))
        {
            Time.timeScale = 0f;
            _pauseMenu.SetActive(true);
        }
        else if (Input.GetKey(KeyCode.T))
        {
            Time.timeScale = 1.0f;
            _pauseMenu.SetActive(false);
        }

        movingDirection.y -= gravity * Time.deltaTime;
        controller.Move(movingDirection * Time.deltaTime);

        _moveVector = transform.forward * moveY + transform.right * moveX;
        _moveVector.Normalize();
        _moveVector *= _speed * Time.deltaTime;

        _controller.SimpleMove(_moveVector);
    }

    private void Look()
    {
        //Moving mouse for camera
        //Get mouse input

        float mouseX = Input.GetAxis("Mouse X") * Time.deltaTime * _mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * Time.deltaTime * _mouseSensitivity;

        Vector2 targetDelta = new Vector2(mouseX, mouseY);
        _currentMouseDelta = Vector2.SmoothDamp(_currentMouseDelta, targetDelta, ref _currentMouseVelocity, _smoothtime);
        _xRotation -= _currentMouseDelta.y;
        _xRotation = Mathf.Clamp(_xRotation, -_cameraBounds, _cameraBounds);
        transform.Rotate(Vector3.up * _currentMouseDelta.x);
        _camera.transform.localRotation = Quaternion.Euler(_xRotation, 0f, 0f);

        //Debug.Log("X: " + mouseX + "/Y: " + mouseY);
    }

    private void Death()
    {
        Debug.Log(_health);

        if (_health <= 0f)
        {
            Debug.Log("Im Dead!");
            _playerPoint.transform.position = _spawnPoint.transform.position;
            Physics.SyncTransforms();
            _health += 5f;
        }
    }
}
