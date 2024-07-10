using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbitFollow : MonoBehaviour
{
    public Transform player;  // Oyuncu karakterinin Transform'u
    public float offset = 2.0f;  // Tavþanýn oyuncunun yanýnda duracaðý mesafe

    private Vector3 targetPosition;  // Tavþanýn gitmek istediði hedef pozisyon
    private SpriteRenderer spriteRenderer;  // Tavþanýn SpriteRenderer'ý

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();  // SpriteRenderer bileþenini al
    }

    void Update()
    {
        // Oyuncunun pozisyonuna göre tavþanýn hedef pozisyonunu ayarla
        if (player.position.x > transform.position.x)  // Oyuncu tavþanýn saðýndaysa
        {
            targetPosition = new Vector3(player.position.x - offset, transform.position.y, transform.position.z);  // Tavþaný oyuncunun soluna koy
            spriteRenderer.flipX = false;  // Tavþaný saða bakacak þekilde ayarla
        }
        else if (player.position.x < transform.position.x)  // Oyuncu tavþanýn solundaysa
        {
            targetPosition = new Vector3(player.position.x + offset, transform.position.y, transform.position.z);  // Tavþaný oyuncunun saðýna koy
            spriteRenderer.flipX = true;  // Tavþaný sola bakacak þekilde ayarla
        }

        // Tavþaný hedef pozisyona ayarla (senkron hareket)
        transform.position = targetPosition;
    }
}