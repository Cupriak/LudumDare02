using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour, IPickable
{
    public float speed = 10f;
    public Transform leftBound;
    public Transform rightBound;
    public ObjectController2D objectController;

    private int movingSide = 1;

    public void OnLeft(GameObject target)
    {
        target.transform.SetParent(null);
    }
    public void OnTouch(GameObject target)
    {
        target.transform.SetParent(transform);
    }
    void Update()
    {
        if (transform.position.x > rightBound.position.x)
        {
            movingSide = -1;
        }
        if (transform.position.x < leftBound.position.x)
        {
            movingSide = 1;
        }
        objectController.SetHorizontalVelocity(speed * movingSide);
    }
}
