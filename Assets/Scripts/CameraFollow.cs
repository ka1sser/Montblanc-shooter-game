using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform playerPosition;
    [SerializeField] float cameraSpeed = 0f;
    [SerializeField] float minX = 0f;
    [SerializeField] float maxX = 0f;
    [SerializeField] float minY = 0f;
    [SerializeField] float maxY = 0f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = playerPosition.position;
    }

    // Update is called once per frame
    void Update()
    {
        ClampedPosition();
    }

    private void ClampedPosition()
    {
        if (playerPosition != null)
        {
            float clampedX = Mathf.Clamp(playerPosition.position.x, minX, maxX);
            float clampedY = Mathf.Clamp(playerPosition.position.y, minY, maxY);
            Vector2 clampedVector = new Vector2(clampedX, clampedY);
            transform.position = Vector2.Lerp(transform.position, clampedVector, cameraSpeed);
        }
    }
}
