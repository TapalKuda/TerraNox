using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float kecepatanGerak = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (spriteRenderer == null)
        {
            Debug.LogError("Tidak ada komponen SpriteRenderer pada objek Karakter.");
        }

        animator.SetBool("isAttacking", false);
        animator.SetBool("isWalking", false);
    }


    void Update()
    {
        float gerakHorizontal = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(gerakHorizontal * kecepatanGerak, rb.velocity.y);

        animator.SetBool("isWalking", Mathf.Abs(gerakHorizontal) > 0);

        if (spriteRenderer != null)
        {
            if (gerakHorizontal < 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (gerakHorizontal > 0)
            {
                spriteRenderer.flipX = true;
            }
        if (Input.GetKeyDown(KeyCode.Space))
        {
                animator.SetBool("isAttacking", true);
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("dinda_attack"))
        {
                // Reset setelah animasi attack selesai
                animator.SetBool("isAttacking", false);
        }
        }
    }
}