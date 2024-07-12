using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbitFollow : MonoBehaviour
{
    public Transform player; 
    public float horizontalOffset = 2.0f; 
    public float verticalOffset = 0.5f; 
    public float lerpSpeed = 5.0f; 

    private Vector3 targetPosition; 
    private SpriteRenderer spriteRenderer; 
    private SpriteRenderer playerSpriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        playerSpriteRenderer = player.GetComponent<SpriteRenderer>(); 
    }

    void Update()
    {
        if (playerSpriteRenderer.flipX) 
        {
            targetPosition = new Vector3(player.position.x + horizontalOffset, player.position.y + verticalOffset, transform.position.z); 
            spriteRenderer.flipX = true; 
        }
        else 
        {
            targetPosition = new Vector3(player.position.x - horizontalOffset, player.position.y + verticalOffset, transform.position.z); 
            spriteRenderer.flipX = false; 
        }

        transform.position = Vector3.Lerp(transform.position, targetPosition, lerpSpeed * Time.deltaTime);
    }
}


