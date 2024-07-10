using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbitFollow : MonoBehaviour
{
    public Transform player;  // Oyuncu karakterinin Transform'u
    public float offset = 2.0f;  // Tav�an�n oyuncunun yan�nda duraca�� mesafe

    private Vector3 targetPosition;  // Tav�an�n gitmek istedi�i hedef pozisyon
    private SpriteRenderer spriteRenderer;  // Tav�an�n SpriteRenderer'�

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // SpriteRenderer bile�enini al
    }

    void Update()
    {
        // Oyuncunun pozisyonuna g�re tav�an�n hedef pozisyonunu ayarla
        if (player.position.x > transform.position.x)  // Oyuncu tav�an�n sa��ndaysa
        {
            targetPosition = new Vector3(player.position.x - offset, transform.position.y, transform.position.z);  // Tav�an� oyuncunun soluna koy
            spriteRenderer.flipX = false;  // Tav�an� sa�a bakacak �ekilde ayarla
        }
        else if (player.position.x < transform.position.x)  // Oyuncu tav�an�n solundaysa
        {
            targetPosition = new Vector3(player.position.x + offset, transform.position.y, transform.position.z);  // Tav�an� oyuncunun sa��na koy
            spriteRenderer.flipX = true;  // Tav�an� sola bakacak �ekilde ayarla
        }

        // Tav�an� hedef pozisyona ayarla (senkron hareket)
        transform.position = targetPosition;
    }
}