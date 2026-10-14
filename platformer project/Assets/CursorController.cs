using UnityEngine;
using UnityEngine.InputSystem;

public class CursorController : MonoBehaviour
{
    public bool isLeft = false;

    [SerializeField] topdowncontroller playerPosition;

    float playerX;
    float playerY;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        
        playerX = playerPosition.xPos;
        playerY = playerPosition.yPos;

        Vector2 scale = transform.localScale;
        
        //Debug.Log($"Mouse at {mouseWorld} Player at {playerX}, {playerY}");

        if(mouseWorld.x > playerX)
        {
            if(isLeft)
            {
                scale.y *= -1;
                transform.localScale = scale;
            }
            isLeft = false;
        }
        else
        {
            if(!isLeft)
            {
                scale.y *= -1;
                transform.localScale = scale;
            }
            isLeft = true;
        }

        if(isLeft)
        {
            transform.position = new Vector2(playerX - 2f, playerY);
        }
        else
        {
            transform.position = new Vector2(playerX + 2f, playerY);
        }
    }
}
