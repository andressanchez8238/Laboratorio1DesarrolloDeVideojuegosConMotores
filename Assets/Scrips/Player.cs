using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private Rigidbody RB;
    private float speed = 9f;
    private PlayerInput playerInput;
    private Vector2 input;
    private void Awake()
    {
        RB = GetComponent<Rigidbody>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        input=playerInput.actions["Movimiento"].ReadValue<Vector2>();
    }
    private void FixedUpdate()
    {
        RB.AddForce(new Vector3(input.x,0f,input.y)*speed);
    }
}
