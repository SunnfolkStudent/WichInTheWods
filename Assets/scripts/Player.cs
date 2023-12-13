using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 5f;
    
    [Header("Components")]
    private Rigidbody2D _rigidbody2D;
    private Input_Controler _input;
    private Animator _animator;

    [Header("Audio")] 
    public AudioSource audioSource;
    public AudioClip audioClip;

    public LayerMask solidObjectsLayer;
    public LayerMask interacebleLayer;

    private bool _isMoving;
    private bool _interactable;
    [HideInInspector] public static bool frozen;

    private Vector2 _inputAxis;
    private Vector3 targetPos;

    public Vector2 facing;

    
    
    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _input = GetComponent<Input_Controler>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        _inputAxis.x = _input.moveDirection.x;
        _inputAxis.y = _input.moveDirection.y;
        if (_input.interactPressed) Interact();
        if (_input.openNoteBook) SceneManager.LoadScene("Notbok", LoadSceneMode.Additive);

    }

    private void FixedUpdate()
    {
       
        if (!_isMoving && !frozen)
        {
            //_rigidbody2D.velocity = new Vector2(_input.moveDirection.x * moveSpeed, _input.moveDirection.y * moveSpeed);
      
            
            //print(_inputAxis.magnitude);
            if (_inputAxis.magnitude > 1)
            {
                _inputAxis = _inputAxis.normalized;
            }

            //remove diogonal movment
            if (_input.moveDirection.x != 0) _inputAxis.y = 0;
            
            if (_inputAxis != Vector2.zero)
            {
                _animator.SetFloat("horizontal", _inputAxis.x);
                _animator.SetFloat("vertikcal", _inputAxis.y);
                targetPos = new Vector3((int) transform.position.x, (int)transform.position.y);
               
                targetPos.x += (int)_inputAxis.x;
                targetPos.y += (int)_inputAxis.y;
                
                if (IsWalkeble(targetPos))
                    StartCoroutine(Move(targetPos));
                
                
            }
        }
        _animator.SetBool("isMoving", _isMoving);

      
    }
    void Interact()
    {
        var faceingDir = new Vector3(_animator.GetFloat("horizontal"),_animator.GetFloat("vertikcal"));
        facing = faceingDir;
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
        if (Physics2D.OverlapCircle (targetPos,0.3f,solidObjectsLayer | interacebleLayer) != null)
        {
            return false;
        }

        return true;
    }

    public void WalkSound()
    {
        audioSource.PlayOneShot(audioClip);
    }
    
}