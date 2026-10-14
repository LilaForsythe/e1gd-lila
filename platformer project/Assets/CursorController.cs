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
        Vector2 pos = Mouse.current.position.ReadValue();
        

        Vector2 screenCenter = new Vector2(Screen.width / 2f, Screen.height / 2f);

        Vector2 relativeFromCenter = pos - screenCenter;

        Debug.Log($"Mouse at {relativeFromCenter}");

        playerX = playerPosition.xPos;
        playerY = playerPosition.yPos;

        Vector2 scale = transform.localScale;
        

        if(relativeFromCenter.x/5 > playerX)
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
