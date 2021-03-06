﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnManager : MonoBehaviour {
    public GameObject enemy;
    public int wavecount = 2;
    [SerializeField]
    private float timeBetweenWaves = 5;
    List<GameObject> spawnpoints = new List<GameObject>();
    [Header("TRACKING")]
    public float countDown;
    private void Start()
    {
        AddToList(GameObject.FindGameObjectsWithTag("Spawnpoints"));
        countDown = timeBetweenWaves;
        StartCoroutine(tick());
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
            countDown = timeBetweenWaves;
        }
    }
    IEnumerator Spawn(GameObject _enemy)
    {
        Debug.Log("Spawn");
        for (int i = 0; i < wavecount; i++)
        {
            System.Random rng = new System.Random();
            int spawnpoint = rng.Next(0, 4);
            GameObject point = spawnpoints[spawnpoint];
            Instantiate(_enemy, point.transform.position, point.transform.rotation);
            yield return new WaitForSecondsRealtime(0.1f);
            
        }
        yield break;
    }
    IEnumerator tick()
    {
        while (true)
        {
            yield return new WaitForSecondsRealtime(3);
            timeBetweenWaves -= 0.1f;
        }
    }
    void AddToList(params GameObject[] list)
    {
        for (int i = 0; i < list.Length; i++)
        {
            spawnpoints.Add(list[i]);
        }
    }
    public void isDead()
    {
        Destroy(gameObject);
    }
}
