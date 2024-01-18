using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControls : MonoBehaviour
{
    public static PlayerControls instance { get; private set; }

    [SerializeField] Rigidbody2D rb;

    [SerializeField] Transform groundCheck;
    [SerializeField] LayerMask groundLayer;

    float horizontal;

    public float Speed { get; set; } = 3f;
    public float JumpPower { get; set; } = 5f;
    public Rigidbody2D RB { get; set; }


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Found more than one Player Controller in the scene.");
        }
        instance = this;
        RB = rb;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(horizontal * Speed, rb.velocity.y);
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position,0.2f,groundLayer);
    }


    public void Move(InputAction.CallbackContext contex)
    {
        horizontal = contex.ReadValue<Vector2>().x;
        
    }

    public void Jump(InputAction.CallbackContext contex)
    {
        if (contex.performed && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, JumpPower);
        }

        if (contex.canceled && rb.velocity.y > 0f)
        {
            rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        }

    }

}
