using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMotor : MonoBehaviour
{

    public float speed = 10;

    private Vector3 targetPosition;
    private bool isMoving;

    const int RIGHT_MOUSE_BUTTON = 1;

    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
        isMoving = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(RIGHT_MOUSE_BUTTON))
            SetTargetPosition();

        if (isMoving)
            MovingPlayer();
    }

    void SetTargetPosition()
    {
        Plane plane = new Plane(Vector3.up, transform.position);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float point = 0f;

        if (plane.Raycast(ray, out point))
            targetPosition = ray.GetPoint(point);

        isMoving = true;
    }

    void MovingPlayer()
    {
        transform.LookAt(targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (transform.position == targetPosition)
            isMoving = false;

        Debug.DrawLine(transform.position, targetPosition, Color.green);
    }
}
