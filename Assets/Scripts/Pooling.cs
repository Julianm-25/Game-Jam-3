using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pooling : MonoBehaviour
{
    public Transform prefab;
    [SerializeField]
    List<Transform> objects;
    private void Awake()
    {
        objects = new List<Transform>();
        if(prefab == null)
        {
            Debug.LogError("Pool " + gameObject.name + " does not have a prefab attached");
        }
    }
    public Transform Spawn()
    {
        if(objects.Count == 0 )
        {
            return Instantiate(prefab, null);
        }
        else
        {
            Transform spawnedT = objects[0];
            objects.RemoveAt(0);
            spawnedT.parent = null;
            spawnedT.position = prefab.position;
            spawnedT.rotation = prefab.rotation;
            spawnedT.localScale = prefab.localScale;
            spawnedT.gameObject.SetActive(true);
            return spawnedT;
        }
    }
    public Transform Spawn(Transform parent)
    {
        if (objects.Count == 0)
        {
            return Instantiate(prefab, parent);
        }
        else
        {
            Transform spawnedT = objects[0];
            objects.RemoveAt(0);
            spawnedT.parent = parent;
            spawnedT.position = prefab.position;
            spawnedT.rotation = prefab.rotation;
            spawnedT.localScale = prefab.localScale;
            spawnedT.gameObject.SetActive(true);
            return spawnedT;
        }
    }
    public void Despawn(Transform spawnedGO)
    {
        spawnedGO.gameObject.SetActive(false);
        spawnedGO.parent = transform;
        objects.Add(spawnedGO);
    }
}