using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject enemy;
    public int wavecount = 2;
    [SerializeField]
    private int timeBetweenWaves = 5;
    List<GameObject> spawnpoints = new List<GameObject>();
    [Header("TRACKING")]
    public float countDown;
    private void Start()
    {
        AddToList(GameObject.FindGameObjectsWithTag("Spawnpoints"));
        countDown = timeBetweenWaves;
    }
    private void Update()
    {
        if (countDown >= 0)
        {
            countDown -= Time.deltaTime;
        }
        else
        {
            StartCoroutine(Spawn(enemy));
            countDown = 5;
        }
    }
    IEnumerator Spawn(GameObject _enemy)
    {
        for (int i = 0; i < wavecount; i++)
        {
            Debug.Log("Spawn");
            System.Random rng = new System.Random();
            int spawnpoint = rng.Next(0, 4);
            GameObject point = spawnpoints[spawnpoint];
            Instantiate(_enemy, point.transform.position, point.transform.rotation);
            yield return new WaitForSecondsRealtime(0.1f);
            
        }
        yield break;
    }
    public void Spawn()
    {
        StartCoroutine(Spawn(enemy));
    }
    void AddToList(params GameObject[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            spawnpoints.Add(list[i]);
        }
    }
}
