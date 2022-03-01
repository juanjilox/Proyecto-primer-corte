using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class limitesanimales : MonoBehaviour
{
    Rigidbody2D Body;
    float minX, maxX, minY, maxY;
    public Slider barradevida;
    public float dabullet;
    [SerializeField] float speed;
    // Start is called before the first frame update
    void Start()
    {

        Body = GetComponent<Rigidbody2D>();
      


        Vector2 esqInfIzq = (Camera.main).ViewportToWorldPoint(new Vector2(0, 0));
        Vector2 esqSupDer = (Camera.main).ViewportToWorldPoint(new Vector2(1, 1));

        minX = esqInfIzq.x;
        maxX = esqSupDer.x;
        minY = esqInfIzq.y;
        maxY = esqSupDer.y;
    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY)
            ); 

    }

    private void FixedUpdate()
    {
        
            Body.velocity = new Vector2(speed, Body.velocity.y);
       
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        
        if (collision.gameObject.tag == "pared 2")
        {
            speed = speed * -1;
            Body.velocity = new Vector2(speed, Body.velocity.y);
        }
     
        

        


        if (collision.gameObject.tag == "bullet")
        {
            barradevida.value -= dabullet;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "bulletg")
        {
            barradevida.value -= barradevida.value;
            Destroy(collision.gameObject);
        }

        if (barradevida.value == 0)
        {
            Destroy(gameObject);
        }
    }
    
}
