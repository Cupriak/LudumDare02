using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostEnemy : MonoBehaviour, IEnemy, IDamagable
{
    public int health = 1;
    public float speed = 5f;
    public ObjectController2D objectController;
    public float targetCloseness = 1f;

    private Transform targetTransform;
    private void Start()
    {
        targetTransform = FindObjectOfType<PlayerController>().transform;
        Debug.LogWarning("YANUSH NOTE! Dostosuj wykrywanie gracza do glownej klasy playera");
    }
    public void OnEnemyTouch(GameObject target)
    {
        throw new System.NotImplementedException();
    }
    private void Die()
    {
        Destroy(gameObject);
    }
    private void MainAI()
    {
        Vector2 direction = targetTransform.position - transform.position;
        objectController.SetVelocityInDirection(direction, speed);
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
