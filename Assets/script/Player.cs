using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public GameObject projectile;
    public Transform shootingPoint;
    public Transform shootingPoint2;
    GameController m_gc;
    public GameObject hit;
    public AudioSource aus;
    public AudioClip shootingsound;
    // Start is called before the first frame update
    void Start()
    {
        m_gc = FindObjectOfType<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        float xDir = Input.GetAxisRaw("Horizontal");
        if((xDir < 0 && transform.position.x <=-7) || (xDir > 0 && transform.position.x >= 7))
                {
            return;
        }
        transform.position += Vector3.right * moveSpeed * xDir * Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
            {
            shoot();
            shoot2();
        }

    }
    public void shoot()
    {   if(projectile && shootingPoint)
        {   if(aus && shootingsound)
            {
                aus.PlayOneShot(shootingsound);
            }
            Instantiate(projectile, shootingPoint.position, Quaternion.identity);
        }
    }
    public void shoot2()
    {
        if (projectile && shootingPoint2)
        {
            Instantiate(projectile, shootingPoint2.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy"))
        {
            Debug.Log("o day bien mat nay");
            Instantiate(hit, transform.position, Quaternion.identity);
            Destroy(gameObject,0.085f);
            Destroy(col.gameObject);

        }
    }
}
