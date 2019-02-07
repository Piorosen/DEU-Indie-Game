using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public Sprite player;

    public Sword Sword;

    protected int Dir = 0;
    protected Rigidbody2D Rigidbody;

    int jumpCount = 1;

    // Start is called before the first frame update
    protected void Start()
    {
        Rigidbody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        jumpCount = 1;
    }

    // Update is called once per frame
    protected void Update()
    {
        Vector2 move = new Vector2();

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            move.x -= 10.0f;
            Sword.Dir = 1;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            move.x += 10.0f;
            Sword.Dir = 0;
        
        }
        if (Input.GetKey(KeyCode.Space))
        {
            if (jumpCount > 0)
            {
                jumpCount--;
                move.y += 10000.0f;
            }
        }

        move.y -= 980.0f;
        Rigidbody.AddForce(Vector2.up * move.y);

        Rigidbody.transform.Translate(new Vector3(move.x * Time.deltaTime, 0));
    }
}
