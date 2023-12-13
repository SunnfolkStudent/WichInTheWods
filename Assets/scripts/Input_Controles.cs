using UnityEngine;

public class Input_Controler : MonoBehaviour
{
    private  Controles _input;

    [HideInInspector]public Vector2 moveDirection;
    [HideInInspector] public bool interactPressed;
    [HideInInspector] public bool openNoteBook;

    private void Update()
    {
        moveDirection = _input.Player.move.ReadValue<Vector2>();
        interactPressed = _input.Player.Interackt.WasPressedThisFrame();
        openNoteBook = _input.Player.Interackt.WasPressedThisFrame();
    }

    private void Awake()
    { _input = new Controles(); }
    private void OnEnable() { _input.Enable(); }
    private void OnDisable() { _input.Disable(); }
}