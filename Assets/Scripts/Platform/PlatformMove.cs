using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMove : MonoBehaviour
{
    public Vector2[] target;
    private int move;
    public float speed;
    void Start()
    {
        move = 1;
    }

    // Update is called once per frame
    void Update()
    {
      
        
        

        
        
            if(transform.position.x == target[move].x && transform.position.y == target[move].y)  
            {
                move += 1;

                if (move >= target.Length)
                {
                   
                    move = 1;


                }
            }
           
          
        
       

      

        transform.position = Vector2.MoveTowards(transform.position, target[move], speed);
    }
}
