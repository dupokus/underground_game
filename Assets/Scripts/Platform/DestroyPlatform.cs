using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlatform : MonoBehaviour
{
    public float spawnTime;
    public float spawnDelay;
    public int time, maxtime;
    void Start()
    {
        
    }

    public void ChangeColour()
    {
        time++;

       
        
        if(time >= maxtime)
        {
            Destroy(gameObject);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            InvokeRepeating("ChangeColour", spawnTime, spawnDelay);
            GetComponent<Animator>().Play("PlatformDestroy");
        }
    }
    void Update()
    {
        
    }
}
