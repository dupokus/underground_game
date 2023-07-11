using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimEvents : MonoBehaviour
{

    public GameObject Bullet;
    public GameObject bulletSpawnPos;

    public void BulletSpawn()
    {
        Instantiate(Bullet, bulletSpawnPos.transform.position, bulletSpawnPos.transform.rotation);
    }
    public void Destroy()
    {
        Destroy(gameObject);
    }
}
