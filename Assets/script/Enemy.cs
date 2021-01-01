using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    Rigidbody2D m_rb;
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = Vector2.down * speed;
    }
    private void OntriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("DeadZone"))
        {
            Debug.Log("don vi bi tieu diet");
            Destroy(gameObject);
        }
    }
}
