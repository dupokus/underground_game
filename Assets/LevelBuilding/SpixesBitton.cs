using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpixesBitton : MonoBehaviour
{
    [SerializeField] private GameObject Spixes;

    public Sprite[] sprt;

    public float time, maxtime;

    private const float yS = 0.1021567f, yOF = -0.0001633279f;
    public void Update()
    {
        if(Spixes.activeSelf == true)
        {
            time++;
        }

        if(time >= maxtime)
        {
            Spixes.SetActive(false);
            time = 0;
        }
    }

    public void OnCollisionExit2D(Collision2D collision)
    {
        GetComponent<SpriteRenderer>().sprite = sprt[0];
        GetComponent<BoxCollider2D>().size = new Vector2(GetComponent<BoxCollider2D>().size.x, yS);
        GetComponent<BoxCollider2D>().offset = new Vector2(GetComponent<BoxCollider2D>().offset.x, yOF);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Spixes.SetActive(true);
            GetComponent<SpriteRenderer>().sprite = sprt[1];
            GetComponent<BoxCollider2D>().size = new Vector2(GetComponent<BoxCollider2D>().size.x, 0.04734986f);
            GetComponent<BoxCollider2D>().offset = new Vector2(GetComponent<BoxCollider2D>().offset.x, -0.02789225f);
        }
    }
}
