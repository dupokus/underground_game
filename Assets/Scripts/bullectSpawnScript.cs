using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullectSpawnScript : MonoBehaviour
{
    public GameObject spawnee, SpawnPos;
    public bool stopSpawning = false;
    public float spawnTime;
    public float spawnDelay;
    // Start is called before the first frame update

    public Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
        InvokeRepeating("SpawnObject", spawnTime, spawnDelay);
    }
    public void SpawnObject()
    {
        anim.Play("SkullAnim");
        //Instantiate(spawnee, SpawnPos.transform.position, SpawnPos.transform.rotation);

        if(stopSpawning)
        {
            CancelInvoke("SpawnObject");
        }
    }
    // Update is called once per frame
    void Update()
    {
      
    }
}
