using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private ObjectController2D objectController;
    private SpriteRenderer sprite;
    public float speed = 5f;
    public float speedOnPlatform = 0.1f;
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
        //Debug.Log(InputController.HorizontalMovement);
        //Debug.Log(InputController.Jump);
        //if (transform.parent != null)
        //{
        //    Debug.Log("mam parenta");
        //    float velocity = GetComponentInParent<Rigidbody2D>().velocity.x + InputController.HorizontalMovement * speedOnPlatform;
        //    //float maxSpeed = speed;
        //    //float minSpeed = speed;
        //    //if(GetComponent<Rigidbody2D>().velocity.x >= 0)
        //    //{
        //    //    maxSpeed = GetComponentInParent<Rigidbody2D>().velocity.x + speed;
        //    //}
        //    //else
        //    //{

        //    //}
        //    //float velocity = GetComponent<Rigidbody2D>().velocity.x + InputController.HorizontalMovement * speed;
        //    objectController.SetHorizontalVelocity(velocity);
        //}
        //else
        //{
        //    Debug.Log("NIE mam parenta");
        //    objectController.SetHorizontalVelocity(InputController.HorizontalMovement * speed);
        //}
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        IPickable pickable = collision.collider.GetComponent<IPickable>();
        if (pickable != null)
        {
            //pickable.OnTouch(gameObject);
            transform.SetParent(collision.transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        IPickable pickable = collision.collider.GetComponent<IPickable>();
        if (pickable != null)
        {
            //pickable.OnLeft(gameObject);
            transform.SetParent(null);
        }
    }
}
