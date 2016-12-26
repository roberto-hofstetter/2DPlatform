using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{

    public float MaxSpeed = 6;
    public float Speed = 50f;
    public float JumpPower = 150f;

    public bool Grounded;
    public bool CanDoubleJump;

    private Rigidbody2D Rbd2d;
    private Animator anim;

    public int ourHealth;
    public int maxHealth; 


    // Use this for initialization
    void Start()
    {
        Rbd2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("Grounded", Grounded);
        anim.SetFloat("Speed", Mathf.Abs(Input.GetAxis("Horizontal")));


        //flip the player 
        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 180);
        }

        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
            transform.eulerAngles = new Vector2(0, 0);
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (Grounded)
            {
                Rbd2d.AddForce(transform.up * JumpPower);
                CanDoubleJump = true;
            }else
            {
                if (CanDoubleJump)
                {
                    CanDoubleJump = false;
                    Rbd2d.velocity = new Vector2(Rbd2d.velocity.x, 0);
                    Rbd2d.AddForce(Vector2.up * JumpPower / 1.75f);
                }
            }
            
        }
    }
}