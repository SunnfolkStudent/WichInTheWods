using UnityEngine;

public class Input_Controler : MonoBehaviour
{
    private  Controles _input;

    [HideInInspector]public Vector2 moveDirection;
    public bool bookDirection;
    [HideInInspector] public bool interactPressed;
    [HideInInspector] public bool openNoteBook;

    private void Update()
    {
        bookDirection = _input.Player.move.triggered;
        moveDirection = _input.Player.move.ReadValue<Vector2>();
        interactPressed = _input.Player.Interackt.WasPressedThisFrame();
        openNoteBook = _input.Player.openNotebook.WasPressedThisFrame();
    }

    private void Awake()
    { _input = new Controles(); }
    private void OnEnable() { _input.Enable(); }
    private void OnDisable() { _input.Disable(); }
}