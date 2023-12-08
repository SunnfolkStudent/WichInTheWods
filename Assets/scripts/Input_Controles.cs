using UnityEngine;

public class Input_Controler : MonoBehaviour
{
    private  Controles _input;

    public Vector2 moveDirection;
    public bool interactPressed;

    private void Update()
    {
        moveDirection = _input.Player.move.ReadValue<Vector2>();
        interactPressed = _input.Player.Interackt.WasPressedThisFrame();
    }

    private void Awake()
    { _input = new Controles(); }
    private void OnEnable() { _input.Enable(); }
    private void OnDisable() { _input.Disable(); }
}