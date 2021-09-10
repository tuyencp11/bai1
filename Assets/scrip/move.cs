using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    [SerializeField] float Spped = 100;
    Vector2 pos;
    Vector2 movement = Vector2.zero;
    Rigidbody2D rigi;
    [SerializeField] Transform FirePoint;
    [SerializeField] float delay;
    float FireTime = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        rigi = this.GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
       if(Input.GetMouseButton(0))
        {
            pos = Camera.main.ScreenToWorldPoint(Input.mousePosition );
            Vector2.MoveTowards(this.transform.position, pos, Spped * Time.deltaTime);
            this.transform.position = pos;
            
        }
        moving();
        Shoot();
        
    }
   public void moving()
    {
        movement.x = Input.GetAxisRaw("Horizontal") * Spped * Time.deltaTime;
        rigi.velocity = movement;
        movement.y = Input.GetAxisRaw("Vertical") * Spped * Time.deltaTime;
        rigi.velocity = movement;
    }
    void Shoot()
    {
        if (FireTime > 0)
        {
            FireTime -= Time.deltaTime;
            return;
        }

            
        if(Input.GetKey(KeyCode.V))
        {
            GameObject bullet= Bullet_Pool.Instant.Get_Obj().gameObject;
            bullet.transform.position = FirePoint.position;
            bullet.SetActive(true);
            FireTime = delay;
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        this.gameObject.SetActive(false);
        //GameManager.Instant.pnlEndGame
    }
}
