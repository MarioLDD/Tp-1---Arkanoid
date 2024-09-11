using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;

    void Update()
    {
        var horizontalInput = Input.GetAxis("Horizontal");

        Vector3 movement = new Vector3(horizontalInput, 0, 0);

        transform.Translate(movement * speed * Time.deltaTime);


        Vector2 position = transform.position;

        Vector2 bottomRightScreen = new Vector3(Screen.width, 0);
        Vector2 topLeft = Camera.main.ScreenToWorldPoint(bottomRightScreen);

        position.x = Mathf.Clamp(position.x, -topLeft.x + 1, topLeft.x - 1);
        transform.position = position;
    }
}
