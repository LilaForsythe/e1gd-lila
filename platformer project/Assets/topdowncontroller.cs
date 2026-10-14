/*using UnityEngine;
using UnityEngine.InputSystem;

public class topdowncontroller : MonoBehaviour
{

    public Rigidbody2D rb;

    [SerializeField] float moveSpeed = 5.0f;

    private Vector2 moveDir;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rb.linearVelocity = moveDir * moveSpeed;
    }

    //void OnMove(InputValue value)
    //{
    //    moveDir = value.Get<Vector2>();
    //}
}
*/