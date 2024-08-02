using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeCuttable : ToolHit
{
    [SerializeField] GameObject pickUpDrop;
    [SerializeField] int dropCount = 5;
    [SerializeField] float spread = 0.7f;
    int count;
    public float cut;
    private Animator animator;

    private void Awake()
    {
        count = dropCount;
        cut = 0f;
        animator = GetComponent<Animator>();
    }

    public override void Hit()
    {
        while (dropCount > 0)
        {
            dropCount -= 1;

            Vector3 position = transform.position;
            position.x += spread * UnityEngine.Random.value - spread / 2;
            position.y += spread * UnityEngine.Random.value - spread / 2;
            GameObject go = Instantiate(pickUpDrop);
            go.transform.position = position;
        }
        dropCount = count;
        cut = 1f; 
        animator.SetFloat("cut", cut);
        Destroy(transform.gameObject);
    }
}

