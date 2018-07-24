using UnityEngine;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float speed = 1;
    [SerializeField]
    private ParticleSystem death;
    [SerializeField]
    private UIManager uimanager;
    //private SpawnManager spawnmanger;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        uimanager = GameObject.FindGameObjectWithTag("UI").GetComponent<UIManager>();
        //spawnmanger = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        
    }
    private void Update()
    {
        if (!player)
        {
            transform.Rotate(0, 0, 500*Time.deltaTime);
            return;
        }
        Vector2 difference = new Vector2(
            player.transform.position.x - transform.position.x,
            player.transform.position.y - transform.position.y);
        transform.up = difference;
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
   
    public void Die()
    {
        //spawnmanger.Spawn();
        Instantiate(death, transform.position, transform.rotation, null);
        Destroy(gameObject);
        Debug.Log("MLG PRO");
        uimanager.score++;
    }

   
}
