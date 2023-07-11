using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    public int tipe;
    [SerializeField] private GameObject Platform;
    [SerializeField] private Vector2 pos;
    public float speed;
    public bool move;

    public List<Button> buts = new List<Button>();
  
    public void Update()
    {
        if(move == true)
        {
           Platform.transform.position = Vector2.MoveTowards(Platform.transform.position, pos, speed );
        }

        if(Vector2.Distance(Platform.transform.position, pos) <= 0.1)
        {
            move = false;
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            move = true;

            for(int x = 0; x<=buts.Count; x++)
            {
                buts[x].move = false;
            }
        }
    }

    
   
}
