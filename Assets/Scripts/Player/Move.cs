using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Move : MonoBehaviour
{
    public Camera _MC;
    public float _speed;

    public float _coefSpeed;
    public float _jumpForce;

    private float _moveInput;
    private Rigidbody2D _rb;

    private bool _isGrounded;
    public Transform _groundCheck;
    public float _checkRadius;
    public LayerMask _whatIsGrounded;

    public bool _InverseControls = false;

    public float _gravityScaleInitial = 5;

    public bool _OnJump = false;
    public bool _CanShot = true;

    public bool _DelayFollow;

    public Vector2 _MousePosition;
    public GameObject _Cursor;
    public GameObject _MesVisuels;

    public Vector3 _DirectionMouse;

    private float _BetterValueJump;

    void OnMousePosition(InputValue value)
    {
        _MousePosition = value.Get<Vector2>();
        _MousePosition = _MC.ScreenToWorldPoint(_MousePosition);
    }

    void Start()
    {
        _coefSpeed = 1;
        _rb = GetComponent<Rigidbody2D>();
    }

    void OnJump()
    {
        if(_OnJump == false)
        { 
            if (_isGrounded)
            {
                _rb.velocity = Vector2.up * _jumpForce;
            }
        }

    }

    void Update()
    {
        if (_isGrounded == true)
        {
            _OnJump = false;
            _CanShot = true;
        }
        else
        {
            _OnJump = true;
        }

    }

    void FixedUpdate()
    {
        //_isGrounded = Physics2D.OverlapCircle(_groundCheck.position, _checkRadius, _whatIsGrounded);

        _rb.gravityScale = _gravityScaleInitial;

        _Cursor.transform.position = new Vector3(_MousePosition.x, _MousePosition.y, 0);


        if (_OnJump && _CanShot )
        {
            // LookAt 2D
            Vector3 target = _Cursor.transform.position;
            // get the angle
            _DirectionMouse = (target - transform.position).normalized;
            float angle = Mathf.Atan2(_DirectionMouse.y, _DirectionMouse.x) * Mathf.Rad2Deg;
            // rotate to angle
            Quaternion rotation = new Quaternion();
            rotation.eulerAngles = new Vector3(0, 0, angle - 90);
            _MesVisuels.transform.rotation = rotation;

        }
    }

    public void ResetVelocity()
    {
        _rb.velocity = Vector3.zero;
    }


    public void Impulse(Vector2 direction, float Force)
    {
        _rb.velocity += new Vector2(direction.x , direction.y) * Force;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            _isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Ground")
        {
            _isGrounded = false;
        }
    }

    IEnumerator Waiter()
    {


        yield return new WaitForSeconds(.3f);


    }
}