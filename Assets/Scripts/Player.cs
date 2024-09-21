using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public GameObject laserPrefab;
    Vector2 movementVector;

    private float speed = 6f;
    private float horizontalScreenLimit = 10f;
    private float verticalScreenLimit = 6f;

    // Start is called before the first frame update
    void OnEnable()
    {
        PlayerInput.onMove += MovementInput;
        PlayerInput.onShoot += Shooting;
        
    }

    void OnDisable()
    {
        PlayerInput.onMove -= MovementInput;
        PlayerInput.onShoot -= Shooting;
    }
    private void Update()
    {
        Movement();
    }
    private void MovementInput(Vector2 input)
    {
        movementVector = input;
    }

    void Movement()
    {
        transform.Translate(new Vector3(movementVector.x, movementVector.y, 0) * Time.deltaTime * speed);
        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1f, transform.position.y, 0);
        }
        if (transform.position.y > verticalScreenLimit || transform.position.y <= -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }
    }

    void Shooting()
    {
        Instantiate(laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
    }
}
