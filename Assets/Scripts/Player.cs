using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

    public float MaxSpeed = 3;
    public float Speed = 50f;
    public float JumpPower = 150f;

    public bool Grounded;

    private Rigidbody2D Rbd2d;
    private Animator anim;


	// Use this for initialization
	void Start () {
        Rbd2d = gameObject.GetComponent<Rigidbody2D>();
        anim = gameObject.GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        anim.SetBool("Grounded",Grounded);
        anim.SetFloat("Speed", Mathf.Abs(Rbd2d.velocity.x));


        //flip the player 
        if(Input.GetAxis("Horizontal") < -0.1f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (Input.GetAxis("Horizontal") > 0.1f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }

        if (Input.GetButtonDown("Jump") && Grounded)
        {
            Rbd2d.AddForce(Vector2.up * JumpPower);
        }
    }

    void FixedUpdate()
    {

        //moving the player
        float h = Input.GetAxis("Horizontal");                

        Rbd2d.AddForce((Vector2.right * Speed) * h);

        // limiting the speed of the player
        if (Rbd2d.velocity.x > MaxSpeed)
        {
            Rbd2d.velocity = new Vector2(MaxSpeed, Rbd2d.velocity.y);
        }

        if(Rbd2d.velocity.x < -MaxSpeed)
        {
            Rbd2d.velocity = new Vector2(-MaxSpeed, Rbd2d.velocity.y);
        }
    }
}
