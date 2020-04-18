using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraController : MonoBehaviour
{
    public Transform playerTransform;
    private Camera mainCamera;
    public float cameraZoom = 5;
    void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    void Update()
    {
        transform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, -10);
        mainCamera.orthographicSize = cameraZoom;
    }
}
