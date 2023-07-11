using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;
    public Animator anim;
    public Rigidbody2D rig;
    public Camera cam;

   public Transform StartPos;

  
    public float Huy;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
        IsMoving();
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("SecretWays"), true);

    }



    public bool Ismoving;
    public bool left;
    public bool isJumped;

    [SerializeField] private float JumpForce, vel;
    [SerializeField] private AnimationCurve JumpTraectory;
    [SerializeField] float jumpTime, maxJimpTime;
    private float jumpY;
    [SerializeField] private bool curveJmp;
    public int jumpNum;

    public void IsMoving()
    {
        if (Ismoving == true)
        {
            if (Input.GetKey("d"))
            {
            
                transform.Translate(Vector2.right * Time.deltaTime * speed);
                left = false;
            }

            if (Input.GetKey("a"))
            {
                transform.Translate(Vector2.right * Time.deltaTime * speed);
                left = true;
            }

        }

        if (left == true)
        {
            transform.rotation = new Quaternion(0, 180, 0, 0);
            
        }

        else
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
          
        }

        //Jump

      
        if (jumpNum >= 2)
        {
            isJumped = true;
        }
        if (Input.GetKeyDown(KeyCode.Space) && jumpNum <2  && isJumped == false)
        {
            //anim.Play("Jump");
            //rig.AddForce(Vector2.up * JumpForce);
            jumpY = transform.position.y;
            curveJmp = true;
            jumpNum++;
            //anim.SetBool("IsJump", isJumped);

            Ismoving = true;
        }

        if (curveJmp == true)
        {
            jumpTime += Time.deltaTime;
           

            float progress = jumpTime / maxJimpTime;



            transform.position = new Vector3(transform.position.x, jumpY + JumpTraectory.Evaluate(jumpTime), transform.position.z);

        }

        if (jumpTime >= maxJimpTime)
        {
            
           
            curveJmp = false;
            jumpTime = 0;
            transform.position = new Vector3(transform.position.x, jumpY + JumpTraectory.Evaluate(maxJimpTime), transform.position.z);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, -6.6f);
            if (GetComponent<Rigidbody2D>().velocity.y < -6.6)
            {
                
            }
            if(jumpNum == 1)
            {
                vel = GetComponent<Rigidbody2D>().velocity.y;
            }
            else
            {
                //GetComponent<Rigidbody2D>().velocity = new Vector2(0, vel);
            }
           
            //Debug.Log(rig.velocity);
            //rig.velocity = new Vector3(0, 0, 0);
        }

     

    }


    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            isJumped = false;
            jumpNum = 0;
        }

        if(collision.gameObject.GetComponent<PlatformMove>() != null)
        {
            transform.parent = collision.gameObject.transform;
        }
        else
        {
            transform.parent = null;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Dammage")
        {
            transform.position = StartPos.position;
        }
    }
}
