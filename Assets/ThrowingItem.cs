using UnityEngine;

public class ThrowingItem : MonoBehaviour
{
    public int direction = 0;
    public float speed;
    private void Update()
    {
        transform.position = new Vector3(transform.position.x+ speed * direction*Time.deltaTime,transform.position.y);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))

        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        Debug.Log("tradwqdwq");
    }
}
