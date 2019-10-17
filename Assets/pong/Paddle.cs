using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField]
    float speed;

    float height;

    string input;
    public string paddleSide;

    // Start is called before the first frame update
    void Start()
    {
        height = transform.localScale.y;
    }


    public void Init(string side)
    {
        paddleSide = side;
        Vector2 pos = Vector2.zero;
        if(side == "right")
        {
            pos = new Vector2(PongGameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;
            input = "paddleRight";
        }
        else
        {
            pos = new Vector2(PongGameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;
            input = "paddleLeft";
        }

        transform.position = pos;
    }




    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis(input) * Time.deltaTime * speed;

        if(transform.position.y > PongGameManager.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }
        if(transform.position.y < PongGameManager.bottomLeft.y + height / 2 && move < 0)
        {
            move = 0;
        }

        transform.Translate(move * Vector2.up);
    }
}
