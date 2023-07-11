using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{
    [SerializeField] private Bounds bound;
    public GameObject Player, LeftEx, RightEx;
    public float plusY;
    void Start()
    {
        Player = GameObject.Find("Player");
        bound.center = new Vector2(transform.position.x, transform.position.y + plusY);
        bound.extents = new Vector2(1.5f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(Vector2.Distance(bound.center, Player.transform.position));
        if (Vector2.Distance(bound.center, Player.transform.position) <= 1)
        {
            Debug.Log("Fuck");
            transform.position = new Vector2(transform.position.x, bound.center.y);
        }
    }
}
