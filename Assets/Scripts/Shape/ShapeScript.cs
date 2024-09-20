using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShapeScript : MonoBehaviour
{
    [SerializeField] float moveSpeed = 2.5f;
    [SerializeField] ShapesSO myData;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveToGoal();
    }

    void MoveToGoal()
    {
        rb.velocity = Vector2.left * moveSpeed;
        
        if (GameplayManager.instance.hasGameFinished)
        {
            SpawnParticle(GameManager.instance.winParticleEffect);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (GameplayManager.instance.goalCurrentType == myData.shapeType)
        {
            GameplayManager.instance.IncrementScore();
            AudioManager.instance.PlaySound(myData.winSound);
            SpawnParticle(GameManager.instance.winParticleEffect);
        } else {
            GameplayManager.instance.DecreaseHealth();
            AudioManager.instance.PlaySound(myData.loseSound);
            SpawnParticle(GameManager.instance.lossParticleEffect);
        }
        Destroy(gameObject);
    }

    private void SpawnParticle(GameObject hh)
    {
        GameObject go = Instantiate(hh, transform.position, Quaternion.identity);
        Destroy(go, 1);
    }


}
