using System;
using System.Collections;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    
    [Header("Components")]
    private Rigidbody2D _rigidbody2D;
    private Input_Controler _input;


    private bool _isMoving;
    private bool _interactable;

    private Vector2 _inputAxis;
    private Vector3 targetPos;
    
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<Input_Controler>();
    }

    private void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!_isMoving)
        {
            //_rigidbody2D.velocity = new Vector2(_input.moveDirection.x * moveSpeed, _input.moveDirection.y * moveSpeed);
            _inputAxis.X = _input.moveDirection.x;
            _inputAxis.Y = _input.moveDirection.y;
            

            

            if (_inputAxis != Vector2.Zero)
            {
                targetPos = transform.position;
                targetPos.x += _inputAxis.X;
                targetPos.y += _inputAxis.Y;

                StartCoroutine(Move(targetPos));
            }
        }
    }

    private IEnumerator Move(Vector3 targetPos)
    {
        _isMoving = true;
        while ((this.targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, this.targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = this.targetPos;
        _isMoving = false;
    }
    
}