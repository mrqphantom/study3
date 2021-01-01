using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public GameObject projectile;
    public Transform shootingPoint;
    public Transform shootingPoint2;
    // Start is called before the first frame update
    void Start()
    {
        
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
        {
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
    private void OnCollistionEnter2D(Collision2D col)
    {
        if(col.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("va cham nguoi choi");
        }
    }
}
