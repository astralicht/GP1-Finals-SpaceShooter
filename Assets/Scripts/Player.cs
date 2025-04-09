using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float rotationSpeed = 500f;
    [SerializeField] private float maxSpeed = 500f;
    public float speed;
    public float posX;
    public float posY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HandleMovement();
    }

    private void HandleMovement()
    {
        posX = transform.position.x;
        posY = transform.position.y;

        if (!(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)) && speed > 0)
        {
            Decelerate();
        }

        if (Input.GetKey(KeyCode.W))
        {
            if (!(transform.position.x >= 1 && transform.position.x <= 1919 && transform.position.y >= 1 && transform.position.y <= 1079))
            {
                speed = 0;
            }

            speed += acceleration;
            if (speed >= maxSpeed)
            {
                speed = maxSpeed;
            }
            transform.Translate(Vector3.up * speed * Time.deltaTime);

            RotateCheck();
        }

        RotateCheck();
    }

    private void RotateCheck()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.back * rotationSpeed * Time.deltaTime);
        }
        if (!Input.GetKey(KeyCode.W)) {
            Decelerate();
        }
    }

    private void Decelerate()
    {
        if (!(transform.position.x >= 1 && transform.position.x <= 1919 && transform.position.y >= 1 && transform.position.y <= 1079))
        {
            speed = 0;
        }

        speed -= acceleration;
        if (speed <= 0) {
            speed = 0;
            return;
        }
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
}
