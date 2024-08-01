using UnityEngine;

public class DraggableTrash : MonoBehaviour
{
    public TrashItem trashItem; // Çöp nesnesinin TrashItem bileþeni

    private bool isDragging = false;
    private Vector3 startPosition;

    private void OnMouseDown()
    {
        isDragging = true;
        startPosition = transform.position;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector3(mousePosition.x, mousePosition.y, startPosition.z);
        }
    }
}
