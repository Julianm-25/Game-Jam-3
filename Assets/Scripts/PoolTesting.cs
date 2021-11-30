using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PoolTesting : MonoBehaviour
{
    public Pooling cubepool;

    public List<Transform> despawnList;

    public GameObject point1;
    public GameObject point2;
    // Start is called before the first frame update
    void Start()
    {
        //cubepool.Spawn();
        Transform test = cubepool.Spawn();
        cubepool.Despawn(test);
        //cubepool.Spawn();
        //cubepool.Spawn();
        Transform test2 = cubepool.Spawn();

        cubepool.Despawn(test2);
        
        Debug.Log("Spawned Cubes");
        Debug.LogWarning("Spawned Cubes 2");
        Debug.LogError("Spawned Cubes 3");

        int y = 0;
        try
        {
            int x = 10 / y;
        }
        catch(DivideByZeroException e)
        {
            Debug.LogWarning(e.Message);
        }
        catch (Exception e)
        {
            Debug.LogError(e.Message);
        }
        
        Debug.Log("We are here");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            // Spawns an object and places it between the 2 set points
            Transform test = cubepool.Spawn();
            var transformPosition = test.transform.position;
            transformPosition.x = Random.Range(point1.transform.position.x, point2.transform.position.x);
            transformPosition.z = Random.Range(point1.transform.position.z, point2.transform.position.z);
            test.transform.position = transformPosition;
            // Adds it to the list to be despawned
            despawnList.Add(test);
        }

        if (Input.GetKeyDown(KeyCode.E) && despawnList.Count > 0)
        {
            // Despawns the oldest object in the list
            cubepool.Despawn(despawnList[0]);
            despawnList.Remove(despawnList[0]);
        }
    }
}
