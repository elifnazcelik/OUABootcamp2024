using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolsCharacterController : MonoBehaviour
{
    Vector2 position;
    CustomCharacterController character;
    Rigidbody2D rgbd2d;
    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float sizeOfInteractableArea = 1.2f;
    [SerializeField] LayerMask tree;

    private void Awake()
    {
        character = GetComponent<CustomCharacterController>();
        rgbd2d = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        position = rgbd2d.position + character.lastMotionVector * offsetDistance;
        if (Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }

    private void UseTool()
    {
        

        Collider2D[] colliders = Physics2D.OverlapCircleAll(position, sizeOfInteractableArea, tree);

        

        foreach (Collider2D c in colliders)
        {
            Debug.Log(colliders);
            TreeCuttable hit = c.GetComponent<TreeCuttable>();
            if (hit != null)
            {
                hit.Hit();
                break;
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (rgbd2d != null)
        {
            // Draw a red sphere at the calculated position
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(position, 1.2f);
        }
    }

}
