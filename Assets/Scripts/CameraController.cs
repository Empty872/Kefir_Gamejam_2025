using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Collider2D collider2D;
    [SerializeField] private float speed;
    private Vector3 previousMousePosition;


    private void Start()
    {
        previousMousePosition = Input.mousePosition;
    }

    private void Update()
    {
        var input = Vector3.zero;
        var currentMousePosition = Input.mousePosition;
        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.visible = !Cursor.visible;
        }

        input += currentMousePosition - previousMousePosition;
        var delta = input * speed * Time.deltaTime;
        var newPosition = transform.position + delta;
        var boundsMin = collider2D.bounds.min;
        var boundsMax = collider2D.bounds.max;
        newPosition.x = Mathf.Clamp(newPosition.x, boundsMin.x, boundsMax.x);
        newPosition.y = Mathf.Clamp(newPosition.y, boundsMin.y, boundsMax.y);
        transform.position = newPosition;
        previousMousePosition = currentMousePosition;
    }
}