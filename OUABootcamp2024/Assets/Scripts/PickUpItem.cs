using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    Transform player;
    [SerializeField] float speed = 5f;
    [SerializeField] float pickUpDistance = 1.5f;
    [SerializeField] float ttl = 1f;

    public Item item;
    public int count = 1;

    private void Awake()
    {
        player = GameManager.Instance.player.transform;
    }

    private void Update()
    {
        if (this == null) return;

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
            if (GameManager.Instance.inventoryContainer != null)
            {
                GameManager.Instance.inventoryContainer.Add(item, count);
            }
            else
            {
                Debug.LogWarning("No inventory container attached to the game manager");
            }

            Destroy(gameObject);
        }
    }
}