using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickUpDistance = 1.5f;
    [SerializeField] float ttl = 1f;

    private void Awake()
    {
        player = GameManager.Instance.player.transform;
    }

    private void Update()
    {
        if (this == null) return; // Check if the object is already destroyed

        ttl -= Time.deltaTime;
        if (ttl < 0)
        {
            Destroy(gameObject);
            return;
        }

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > pickUpDistance)
        {
            return;
        }

        transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

        if (distance < 0.1f)
        {
            // Handle the pickup logic here (e.g., increase player inventory)
            Destroy(gameObject);
        }
    }
}