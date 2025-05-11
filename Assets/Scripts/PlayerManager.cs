using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public float health = 100;
    public float bulletSpeed = 500f;
    public Transform swampPoint;
    public Transform bullet;

    private Transform muzzle;
    private bool dead = false;
    private bool canTouchWater = true;  

    private Collider2D playerCollider;

    public Slider slider;
    public Text coinvalue;
    public int coins = 0;
    public AudioClip clip;
    public AudioSource source;
    void Start()
    {
       
        muzzle = transform.GetChild(1);
        playerCollider = GetComponent<Collider2D>();
        slider.maxValue = health;
        slider.value = health;
        source =transform.GetComponent<AudioSource>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBullet();
        }
    }

    void ShootBullet()
    {
        Transform tempBullet = Instantiate(bullet, muzzle.position, Quaternion.identity);
        tempBullet.GetComponent<Rigidbody2D>().AddForce(muzzle.forward * bulletSpeed);
    }

    public void GetDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            DieInWater();
        }
        slider.value = health;
       
    }

    void DieInWater()
    {
        if (dead) return; 
        dead = true;
        health = 0;

        Debug.Log("Player drowned. Restarting scene...");

        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    IEnumerator EnableWaterTouchAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        canTouchWater = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Water") && canTouchWater)
        {
            DieInWater();
        }
    }


    public void ChangeValue()
    {
        source.volume = 0.10f;
        coinvalue.text = coins.ToString();
        source.PlayOneShot(clip);
    }
}
