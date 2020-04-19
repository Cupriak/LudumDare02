using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectController2D : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private RigidbodyConstraints2D initialRb2dConstrains;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        initialRb2dConstrains = rb2d.constraints;
    }
    public void Stop(bool xAxis, bool yAxis)
    {
        if(xAxis && yAxis)
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else if (xAxis)
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionX;
        }
        else if (yAxis)
        {
            rb2d.constraints = RigidbodyConstraints2D.FreezePositionY;
        }
        else
        {
            rb2d.constraints = initialRb2dConstrains;
        }
    }
    public void SetHorizontalVelocity(float speed)
    {
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
    }
    public void SetVerticalVelocity(float speed)
    {
        rb2d.velocity = new Vector2(rb2d.velocity.x, speed);
    }
    public void SetVelocityInDirection(Vector3 direction, float speed)
    {
        rb2d.velocity = direction.normalized * speed;
    }
    public void SetRotation(float angle)
    {
        transform.eulerAngles = new Vector3(0, 0, angle);
    }
}
