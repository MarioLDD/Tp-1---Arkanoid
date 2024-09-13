using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D ball_Rb;
    [SerializeField] private float initialTime;
    [SerializeField] private float initialSpeed;
    public float InitialSpeed { get { return initialSpeed; } }

    private void Awake()
    {
        ball_Rb = GetComponent<Rigidbody2D>();
        ball_Rb.sleepMode = RigidbodySleepMode2D.StartAsleep;

        Invoke("BallLaunch", initialTime);
    }

    private void BallLaunch()
    {
        Vector2 randomDirection = Random.value > 0.5f ? new Vector2(0, 1) : new Vector2(0, 1);
        randomDirection = randomDirection.normalized;
        ball_Rb.velocity = randomDirection * initialSpeed;
    }
    private void FixedUpdate()
    {
        Debug.Log($"Ball velocity: {ball_Rb.velocity}");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeadZone")
        {
            MenuManager.Instance.GameOver();
        }
    }
}
