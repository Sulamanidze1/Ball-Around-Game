using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    [SerializeField] float speed;
    private Rigidbody rbEnemy;

    void Start()
    {
        player = GameObject.Find("Player");
        rbEnemy = GetComponent<Rigidbody>();
    }


    void Update()
    {
        followEnemy();
        DestroyEnemy();
    }

    void followEnemy()
    {
        Vector3 enemyDirection = (player.transform.position - transform.position).normalized;
        rbEnemy.AddForce(enemyDirection * speed);
    }

    void DestroyEnemy()
    {
        if (transform.position.y < -3f)
        {
            Destroy(gameObject);
        }
    }

}
