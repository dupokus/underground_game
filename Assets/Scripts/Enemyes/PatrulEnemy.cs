using UnityEngine;


public class PatrulEnemy : MonoBehaviour
{
    public int vecNum, lastNum, doorNum;
    public Vector2[] vect;
    public Vector2[] doors;
    public float speed;
    public bool doormove;


    public bool walk;
    public int walkTime, walkMaxTime;

    public GameObject Player;
    public bool attack;
    
    void Start()
    {
        vecNum = Random.Range(0, vect.Length);
        lastNum = 4;

        Player = GameObject.FindWithTag("Player");


    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(transform.rotation);
        WatchPlayer();

        if(walk == true)
        {
            if (doormove == true)
            {
                transform.position = Vector2.MoveTowards(transform.position, doors[doorNum], speed);
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, vect[vecNum], speed);
            }

            if (transform.position.y - vect[vecNum].y > 0.1f || transform.position.y - vect[vecNum].y < -0.1f)
            {

                doormove = true;



            }
            else /*if(transform.position.y % doors[doorNum].y < 0.05f && transform.position.y % doors[doorNum].y > -0.1f)*/
            {
                //Debug.Log("No");
                //lastNum = vecNum;
                doormove = false;

            }

            if (Vector2.Distance(transform.position, vect[vecNum]) <= 0.1)
            {
                lastNum = vecNum;
                vecNum = Random.Range(0, vect.Length);
            }

            if (Vector2.Distance(transform.position, doors[doorNum]) <= 0.1 && doormove == true)
            {
                switch (doorNum)
                {
                    case 0:
                        doorNum = 1;

                        transform.position = doors[1];


                        break;

                    case 1:
                        doorNum = 2;

                        transform.position = doors[2];


                        break;

                    case 2:

                        doorNum = 0;

                        transform.position = doors[0];

                        break;
                }
            }


        }


        if(walk == false)
        {
            walkTime++;
            if(walkTime >= walkMaxTime)
            {
                walkTime = 0;
               // walk = true;
            }
        }
    }


    public void WatchPlayer()       
    {
        if (attack == true)
        {
            Debug.LogError("Fuck");
            GetComponent<SpriteRenderer>().color = Color.red;
           transform.position =  Vector2.MoveTowards(transform.position, Player.transform.position, speed* 2);
        }

        if (Vector2.Distance(transform.position, Player.transform.position) <= 3)
        {
            if (Player.transform.position.x > transform.position.x && transform.rotation == new Quaternion(0, 0, 0, 1))
            {
              
                walk = false;
                attack = true;
            }
            else if(transform.rotation == new Quaternion(0, 0, 180, 1) && Player.transform.position.x < transform.position.x)
            {
                walk = false;
                attack = true;
            }
        }

      
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Dammage")
        {
            walk = false;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
    }


}
