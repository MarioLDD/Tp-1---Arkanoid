using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 1000;
    private Rigidbody2D player_Rb;

    private void Awake()
    {
        player_Rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector2 direction = new Vector2(horizontalInput, 0) * speed;

        player_Rb.velocity = direction * Time.fixedDeltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Vector2 playerSpeed = new Vector2(player_Rb.velocity.x, 1);

            var ball_Rb = collision.rigidbody;
            ball_Rb.velocity = (ball_Rb.velocity + playerSpeed).normalized * collision.gameObject.GetComponent<BallController>().InitialSpeed;
        }
    }
}
