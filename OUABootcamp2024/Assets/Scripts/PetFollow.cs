using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PetFollow : MonoBehaviour
{
    public Transform player;
    public float followDistance = 1f;
    public float moveSpeed = 4f;

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > followDistance)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            transform.position += direction * moveSpeed * Time.deltaTime;
        }
    }
}
