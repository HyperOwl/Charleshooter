using UnityEngine;
using System.Collections.Generic;

public class EnemyController : MonoBehaviour{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float speed = 1;
    //private SpawnManager spawnmanger;
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        //spawnmanger = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
        
    }
    private void Update()
    {
        if (!player) return;
        Vector2 difference = new Vector2(
            player.transform.position.x - transform.position.x,
            player.transform.position.y - transform.position.y);
        transform.up = difference;
        transform.Translate(Vector3.up * speed * Time.deltaTime);
    }
   
    public void Die()
    {
        //spawnmanger.Spawn();
        Destroy(gameObject);
        Debug.Log("MLG PRO");
    }

   
}
