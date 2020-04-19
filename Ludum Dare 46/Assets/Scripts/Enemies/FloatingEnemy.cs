using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingEnemy : MonoBehaviour, IEnemy, IDamagable
{
    public int health = 3;
    public float idleSpeed = 5f;
    public float triggeredSpeed = 10f;
    public Transform[] checkPoints;
    public ObjectController2D objectController;
    public float checkPointCloseness = 1f;

    private bool isTriggered;
    private Transform targetTransform;
    private int currentTransformIndex;

    public void OnEnemyTouch(GameObject target)
    {
        throw new System.NotImplementedException();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if(player != null)
        {
            isTriggered = true;
            targetTransform = player.transform;
        }
        Debug.LogWarning("YANUSH NOTE! Dostosuj wykrywanie gracza do glownej klasy playera");
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerController player = collision.GetComponent<PlayerController>();
        if (player != null)
        {
            isTriggered = false;
        }
        Debug.LogWarning("YANUSH NOTE! Dostosuj wykrywanie gracza do glownej klasy playera");
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    private void GetNextTransformIndex()
    {
        currentTransformIndex = (currentTransformIndex != (checkPoints.Length - 1)) ? currentTransformIndex + 1 : 0;
    }
    private void TriggeredAI()
    {
        Vector2 direction = targetTransform.position - transform.position;
        objectController.SetVelocityInDirection(direction, triggeredSpeed);
    }
    private void IdleAI()
    {
        if ((checkPoints[currentTransformIndex].position - transform.position).magnitude < checkPointCloseness)
        {
            GetNextTransformIndex();
        }
        Vector2 direction = checkPoints[currentTransformIndex].position - transform.position;
        objectController.SetVelocityInDirection(direction, idleSpeed);
    }
    private void MainAI()
    {
        if(isTriggered)
        {
            TriggeredAI();
        }
        else
        {
            IdleAI();
        }
    }
    void Update()
    {
        if (health <= 0)
        {
            Die();
        }
        MainAI();
    }

    public void GetDamage(GameObject target)
    {
        health -= 1;
    }
}
