using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Statistics))]
public class Controller2D : MonoBehaviour
{
    public BoxCollider2D BoxCollider2D;
    public Rigidbody2D Rigidbody2D;
    public SpriteRenderer SpriteRenderer;
    public Pickaxe Pickaxe;
    public float Speed;
    public float JumpForce;
    public float GroundRaycastOffset;
    public bool FacingRight;
    public LayerMask GroundLayer;
    public AudioSource Jump;

    // Start is called before the first frame update
    void Start()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SpriteRenderer = GetComponent<SpriteRenderer>();

        FacingRight = true;

        if (!Rigidbody2D.freezeRotation)
            Rigidbody2D.freezeRotation = true;
    }

    // Update is called once per frame
    void Update()
    {
        var h = Input.GetAxisRaw("Horizontal");
        var movement = new Vector2(h * Speed * Time.deltaTime, 0.0f);
        transform.Translate(movement);

        if (h > 0.0f)
            SpriteRenderer.flipX = false;
        else if (h < 0.0f)
            SpriteRenderer.flipX = true;

        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            Rigidbody2D.velocity = Vector2.up * JumpForce;
            Jump.Play();
        }
        // Debug.Log(IsGrounded());

        if (Input.GetButtonDown("Fire1"))
            PickaxeAttackAccess();
    }

    private bool IsGrounded()
    {
        var hit = Physics2D.BoxCast(BoxCollider2D.bounds.center, BoxCollider2D.bounds.size, 0.0f, Vector2.down, GroundRaycastOffset, GroundLayer);

        return hit.collider != null;
    }

    private void PickaxeAttackAccess()
    {
        // prevents dirty bug.
        if (Time.timeScale == 0.0f)
            return;

        // Debug.Log("attack");
        Pickaxe.Attack();
    }
}