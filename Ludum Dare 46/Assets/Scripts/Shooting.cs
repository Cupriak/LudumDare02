﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject armL;
    public GameObject armR;
    public float vector2;
    public SpriteRenderer spriteL;
    public SpriteRenderer spriteR;

    private CharacterController2D characterController2D;

    // Start is called before the first frame update
    void Start()
    {
        spriteL = armL.GetComponent<SpriteRenderer>();
        spriteR = armR.GetComponent<SpriteRenderer>();

        characterController2D = GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        LookAtPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition),spriteL);
        LookAtPosition(Camera.main.ScreenToWorldPoint(Input.mousePosition), spriteR);

    }

    private void LookAtPosition(Vector3 position, SpriteRenderer sprite)
    {
        Vector2 vector = position - transform.position;

        if (vector.y == 0)
        {
            vector = new Vector2(vector.x, 0.001f);
        }

        //-90 stopni bo zakladamy ze sprite jest obrocony w prawo
        float angle = Mathf.Abs((Mathf.Atan(vector.x / vector.y) * Mathf.Rad2Deg) - 90f);

        //1st quoter
        if (position.x > transform.position.x && position.y > transform.position.y)
        {
            sprite.flipX = false;
            sprite.flipY = false;
        }
        //2nd quoter
        else if (position.x < transform.position.x && position.y > transform.position.y)
        {
            sprite.flipX = false;
            sprite.flipY = true;
        }
        //3rd quoter
        else if (position.x < transform.position.x && position.y < transform.position.y)
        {
            sprite.flipX = true;
            sprite.flipY = false;
        }
        //4th quoter
        else if (position.x > transform.position.x && position.y < transform.position.y)
        {
            sprite.flipX = true;
            sprite.flipY = true;
        }

        characterController2D.SetRotation(angle, armL);
        characterController2D.SetRotation(angle, armR);

    }
}
