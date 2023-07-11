using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public float speed;

    void Update()
    {
        transform.position += transform.up * speed * Time.deltaTime;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Walls")
        {
            Destroy(gameObject);

        }
            

        if (collision.gameObject.tag == "Player")
        {
            GameObject Player = collision.gameObject;
            Player.transform.position = Player.GetComponent<Player>().StartPos.position;
        }
       
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
       
    }
}
