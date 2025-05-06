using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class PlayerManager : MonoBehaviour
{
    public float health;

    bool dead = false;
    public GameObject arrow;
    public PlayerController controller;

    //BATU SİL 
    public Transform SpawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            firlat();
    }
    public void GetDamage(float damage)
    {
        if ((health - damage) >= 0)
        {
            health -= damage;

        }
        else
        {
            health = 0;
        }
        AmIDead();
    }
    void AmIDead()
    {
        if (health <= 0)
        {
            dead = true;
        }
    }
    void firlat()
    {
       GameObject arr = Instantiate(arrow,transform.position,Quaternion.identity);
        arr.transform.position = transform.position;
        //arr.transform.position = new Vector3
        if (controller.facingRight)
            arr.GetComponent<ThrowingItem>().direction = 1;
        else
            arr.GetComponent<ThrowingItem>().direction = -1;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Apple"))
        {
            Destroy(collision.gameObject);
            transform.localScale *= 1.5f;




            //BURDAN KUCULME SANİYESİNİ AYARLAYIN
            Invoke("DeScale", 1);
        }
        if (collision.CompareTag("Water"))
            transform.position = SpawnPoint.position;
    }

        //transform.localScale = new Vector3(1.5f, 1, 1);
}
