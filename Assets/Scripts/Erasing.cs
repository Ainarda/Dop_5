using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erasing : MonoBehaviour
{
    [SerializeField] private GameObject _mask;
    [SerializeField] private GameObject _targetErasing;

    private List<GameObject> spawnedObjects = new List<GameObject>();

    private void Update()
    {
        SpawnMask();
    }

    public void TryCleanMask()
    {
        if (spawnedObjects.Count > 0)
        {
            for (int i = 0; i < spawnedObjects.Count; i++)
            {
                Destroy(spawnedObjects[i].gameObject);
            }
            spawnedObjects.Clear();
        }
    }

    private void SpawnMask()
    {
        if (CheckObjectAtSpawnPoint())
        {
            GameObject newObject = Instantiate(_mask, transform.position, Quaternion.identity);
            newObject.transform.SetParent(_targetErasing.transform);
            spawnedObjects.Add(newObject);
        }
    }

    private bool CheckObjectAtSpawnPoint()
    {
        if (spawnedObjects.Count ==0)
        {
            return true;
        }
        else if( Vector3.Distance(spawnedObjects[spawnedObjects.Count - 1].transform.position,
            transform.position) > 0.02f)
        {
            return true;
        }

        return false;
    }
}
