using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    private Rigidbody2D ball_Rb;
    [SerializeField] private float initialTime;
    [SerializeField] private float initialSpeed;

    private void Awake()
    {
        ball_Rb = GetComponent<Rigidbody2D>();
        ball_Rb.sleepMode = RigidbodySleepMode2D.StartAsleep;

        Invoke("BallLaunch", initialTime);
    }

    private void BallLaunch()
    {
        ball_Rb.velocity = new Vector2(Random.Range(-1f, 1f), 1).normalized * initialSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "DeadZone")
        {
            MenuManager.Instance.GameOver();
        }
    }
}
