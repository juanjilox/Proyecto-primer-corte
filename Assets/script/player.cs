using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bullet;
    [SerializeField] float fireRate;
    [SerializeField] float fireRatecharge;
    [SerializeField] float nextFire;
    [SerializeField] float nextFire1;
    [SerializeField] GameObject bulletg;
    private bool cdisparo;
   
    
    float minX, maxX, minY, maxY;
    // Start is called before the first frame update
    void Start()
    {   cdisparo = true;
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
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");
        transform.Translate(new Vector2(movH * Time.deltaTime * speed,
            movV * Time.deltaTime * speed));


        transform.position = new Vector2(
            Mathf.Clamp(transform.position.x, minX, maxX),
            Mathf.Clamp(transform.position.y, minY, maxY)
            );


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cdisparo = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cdisparo = true;
        }

        if (Input.GetButton("Fire1") && Time.time > nextFire & cdisparo == true)
            {
                nextFire = Time.time + fireRate;
                Instantiate(bullet, transform.position, transform.rotation);
            }

            if (Input.GetButton("Fire1") && Time.time > nextFire1 & cdisparo == false)
            {
                nextFire1 = Time.time + fireRatecharge;
                Instantiate(bulletg, transform.position, transform.rotation);

            }


        
    }
}
