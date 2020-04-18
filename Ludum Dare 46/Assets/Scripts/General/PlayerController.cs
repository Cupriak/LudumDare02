using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private ObjectController2D objectController;
    private SpriteRenderer sprite;
    public float speed = 5f;
    void Start()
    {
        objectController = GetComponent<ObjectController2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void LookAtPosition(Vector3 position)
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

        objectController.SetRotation(angle);
    }

    private void PlayerMovment()
    {
        objectController.SetHorizontalVelocity(InputController.HorizontalMovement * speed);
        if (InputController.Jump)
        {
            objectController.SetVerticalVelocity(speed);
        }
    }
    void Update()
    {
        PlayerMovment();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (InputController.Interact)
        {
            IInteractable interactable = collision.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        IEnemy enemy = collision.collider.GetComponent<IEnemy>();
        if (enemy != null)
        {
            enemy.OnEnemyTouch();
        }
    }
}
