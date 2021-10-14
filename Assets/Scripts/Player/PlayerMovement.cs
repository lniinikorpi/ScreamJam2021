using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public Camera mainCamera;
    public float lookSensitivity = .1f;
    public float movementSpeed = 2;
    private Vector3 _movement;
    private Rigidbody _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    void HandleMovement()
    {
        _rb.velocity = _movement;
    }

    public void OnMovement(InputValue value)
    {
        Vector2 moveVector = value.Get<Vector2>();
        _movement = new Vector3(moveVector.x, 0, moveVector.y);
    }

    public void OnMouseLook(InputValue value)
    {
        Vector2 mouseDelta = value.Get<Vector2>();
        Vector3 mouseMovement = new Vector3(-mouseDelta.y, 0);
        mainCamera.transform.localEulerAngles += mouseMovement * lookSensitivity;
        transform.localEulerAngles += new Vector3(0, mouseDelta.x) * lookSensitivity;
    }

    public void OnQuit()
    {
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
