using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{ public float speed;
    public float timeToDestroy;
    Rigidbody2D m_rb;
    GameController m_gc;
    // Start is called before the first frame update
    void Start()
    {
        
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
        Destroy(gameObject, timeToDestroy);
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = Vector2.up * speed;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy"))
        {
            m_gc.ScoreIncrement();
            Debug.Log("va cham enemy");
            Destroy(gameObject);
            Destroy(col.gameObject);
        }

    }
}

