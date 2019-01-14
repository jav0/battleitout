using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMove))]
public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;
    
    [SerializeField]
    private float mouseSensitivity = 3f;
    
    [SerializeField]
    private float jumpForce = 1000f;
    
    private PlayerMove move;
    public bool isGrounded;
    public bool jumped;
    
    public void Start()
    {
        move = GetComponent<PlayerMove>();
        mouseSensitivity = PlayerPrefs.GetFloat("Sensitivity");
    }
    
    void Update()
    {
        // Movement
        float _xMove = 0f;
        float _zMove = 0f;
        if (gameObject.tag == "Player")
        {
            _xMove = Input.GetAxisRaw("Horizontal");
            _zMove = Input.GetAxisRaw("Vertical");
        } else if (gameObject.tag == "Player2")
        {
            _xMove = Input.GetAxisRaw("Horizontal2");
            _zMove = Input.GetAxisRaw("Vertical2");
        }
        
        Vector3 _moveHorizontal = transform.right * _xMove;
        Vector3 _moveVertical = transform.forward * _zMove;
        
        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * speed;
        
        move.Move(_velocity);
        
        // Rotation
        float _yRot = 0f;
        if (gameObject.tag == "Player")
        {
            _yRot = Input.GetAxisRaw("Mouse X");
        } else if (gameObject.tag == "Player2")
        {
            _yRot = Input.GetAxisRaw("Mouse X2");
        }
        
        Vector3 _rotation = new Vector3 (0f, _yRot, 0f) * mouseSensitivity;
        
        move.Rotate(_rotation);
        
        // Camera
        float _xRot = 0f;
        if (gameObject.tag == "Player")
        {
            _xRot = Input.GetAxisRaw("Mouse Y");
        } else if (gameObject.tag == "Player2")
        {
            _xRot = Input.GetAxisRaw("Mouse Y2");
        }
        
        float _cameraRotationX = _xRot * mouseSensitivity;
        
        move.RotateCamera(_cameraRotationX);
        
        // Jump
        Vector3 _jumpForce = Vector3.zero;
        
        if (gameObject.tag == "Player")
        {
            if (Input.GetButton("Jump1"))
            {
                if (isGrounded)
                {
                    _jumpForce = Vector3.up * jumpForce;
                    jumped = true;
                }
            }
        } else if (gameObject.tag == "Player2")
        {
            if (Input.GetButton("Jump2"))
            {
                if (isGrounded)
                {
                    _jumpForce = Vector3.up * jumpForce;
                    jumped = true;
                }
            }
        }
        
        move.Jump(_jumpForce);
        
        // Cursor lock
        if (Cursor.lockState != CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Ground")
        {
            isGrounded = true;
            jumped = false;
        }
    }
    
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "Ground" && jumped)
        {
            isGrounded = false;
        }
    }
}
