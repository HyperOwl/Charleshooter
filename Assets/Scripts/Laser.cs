using UnityEngine;

public class Laser : MonoBehaviour {

    [SerializeField]
    private float speed = 1;

    private void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("hit");
            Destroy(gameObject);
            collision.gameObject.GetComponent<EnemyController>().Die();
        }
        if (collision.gameObject.CompareTag("Edge"))
        {
            //Debug.Log("edge");
            Destroy(gameObject);
        }
    }
}
