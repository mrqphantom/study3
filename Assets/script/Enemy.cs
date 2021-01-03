using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
    Rigidbody2D m_rb;
    GameController m_gc;
    public GameObject hit;
    AudioSource aus;
    public AudioClip soundboom;
    public AudioClip soundlose;
    public float delay;
  
    // Start is called before the first frame update
    void Start()
    {
        m_rb = GetComponent<Rigidbody2D>();
        m_gc = FindObjectOfType<GameController>();
        aus = FindObjectOfType<AudioSource>();
        
    }

    // Update is called once per frame
    void Update()
    {
        m_rb.velocity = Vector2.down * speed;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if ((col.CompareTag("DeadZone")) || (col.CompareTag("character")))
        {
            if (aus && soundboom && !m_gc.IsGameover())
            {
                aus.PlayOneShot(soundboom);
                aus.PlayOneShot(soundlose);
                aus.Play(0);
                    }
            


            Instantiate(hit, transform.position, Quaternion.identity);
            Destroy(gameObject);
            aus.PlayDelayed(delay);
            m_gc.SetGameoverSate(true);
            

        }

        else if (col.CompareTag("bullet"))
        {
            if (aus && soundboom)
            {
                aus.PlayOneShot(soundboom);
            }
                
            Debug.Log("Cham vao dan");
            Instantiate(hit, transform.position, Quaternion.identity);
            Debug.Log("chay particle");
            m_rb.constraints = RigidbodyConstraints2D.FreezeAll;
        }
        
    }
    
}
