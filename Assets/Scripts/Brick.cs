using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    public static event Action<int> OnBrickEvent;
    [SerializeField] private int points = 1;

  
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            OnBrickEvent?.Invoke(points);
            Destroy(gameObject);
        }
    }
}
