using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField]
    float speed;

    float radius;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = Vector2.one.normalized;
        radius = transform.localScale.x / 2; //half width;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);

        //bounce off top and bottom
        if (transform.position.y > PongGameManager.topRight.y - radius && direction.y > 0)
        {
            direction.y = -direction.y;
        }
        if (transform.position.y < PongGameManager.bottomLeft.y + radius && direction.y < 0)
        {
            direction.y = -direction.y;
        }

        if (transform.position.x > PongGameManager.topRight.x - radius && direction.x > 0)
        {
            print("left wins");
            Time.timeScale = 0;
            enabled = false;
        }
        if (transform.position.x < PongGameManager.bottomLeft.x + radius && direction.x < 0)
        {
            print("right wins");
            Time.timeScale = 0;
            enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "paddle")
        {
            string side = other.GetComponent<Paddle>().paddleSide;

            if(side == "right" && direction.x > 0)
            {
                direction.x = -direction.x;
                speed = speed * 1.4f;
            }
            else if (side == "left" && direction.x < 0)
            {
                direction.x = -direction.x;
                speed = speed * 1.4f;

            }



        }
    }

}
