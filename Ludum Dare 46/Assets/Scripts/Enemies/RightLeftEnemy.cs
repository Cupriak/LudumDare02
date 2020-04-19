using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightLeftEnemy : MonoBehaviour, IEnemy
{
    public int health = 3;
    public float speed = 3f;
    public Transform leftBound;
    public Transform rightBound;
    public ObjectController2D objectController;

    private int movingSide = 1;

    private void Die()
    {
        Destroy(gameObject);
    }

    public void MainAI()
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

    public void OnEnemyTouch(GameObject target)
    {
        Debug.Log("Enemy was touched");
    }

    void Update()
    {
        if(health <= 0)
        {
            Die();
        }
        MainAI();
    }
}
