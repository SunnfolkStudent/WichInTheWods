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
    private Animator _animator;

    public LayerMask solidObjectsLayer;
    public LayerMask interacebleLayer;

    private bool _isMoving;
    private bool _interactable;

    private Vector2 _inputAxis;
    private Vector3 targetPos;

    
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<Input_Controler>();
        _animator = GetComponent<Animator>();
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
            

            //remove diogonal movment
            if (_input.moveDirection.x != 0) _inputAxis.Y = 0;

            if (_inputAxis != Vector2.Zero)
            {
                _animator.SetFloat("horizontal", _inputAxis.X);
                _animator.SetFloat("vertikcal", _inputAxis.Y);
                
                targetPos = transform.position;
                targetPos.x += _inputAxis.X;
                targetPos.y += _inputAxis.Y;

                if (IsWalkeble(targetPos))
                    StartCoroutine(Move(targetPos));
                
                
            }
        }
        _animator.SetBool("isMoving", _isMoving);

        if (_input.interactPressed) Interact();
    }
    void Interact()
    {
        var faceingDir = new Vector3(_animator.GetFloat("horizontal"),_animator.GetFloat("vertikcal"));
        var interactPos = transform.position + faceingDir;

        var collider = Physics2D.OverlapCircle(interactPos, 0.3f, interacebleLayer);
        if (collider != null)
        {
            collider.GetComponent<Interaceble>()?.Interact();
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

    private bool IsWalkeble(Vector3 targetPos)
    {
        if (Physics2D.OverlapCircle(targetPos,0.3f,solidObjectsLayer | interacebleLayer) != null)
        {
            return false;
        }

        return true;
    }
    
}