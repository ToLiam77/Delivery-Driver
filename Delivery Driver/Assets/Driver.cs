using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Driver : MonoBehaviour
{
    [SerializeField] float steerSpeed = 250f;
    [SerializeField] float moveSpeed = 11f;
    float boostSpeed = 20f;
    float bumpSpeed = 7f;

    int SpeedChangeTimer = 0;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag != "Ball")
        {
            moveSpeed = bumpSpeed;
            SpeedChangeTimer = 0;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Boost") 
        {
            moveSpeed = boostSpeed;
            SpeedChangeTimer = 0;
        }
    }

    void LateUpdate()
    {
        SpeedChangeTimer++;
        if (SpeedChangeTimer >= 500) moveSpeed = 11f;

        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveDir = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveDir, 0);
    }
}
