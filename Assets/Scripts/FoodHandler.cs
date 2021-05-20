using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodHandler : MonoBehaviour
{
    #region Attributes
    [Header("Attributes")]
    [SerializeField] float spawnRate;
    // [SerializeField] int maxSpawn;
    int currentSpawned;
    float startTime;
    bool isSpawning;

    [Header("Component References")]
    [SerializeField] List<GameObject> foodItems;
    [SerializeField] List<Transform> spawnPoints;

    #endregion

    #region Monobehavior Functions
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {

        if (startTime + spawnRate < Time.time && isSpawning)
        {
            startTime = Time.time;
            isSpawning = false;
            foreach (Transform t in spawnPoints)
            {
                if (t.childCount == 0)
                {
                    SpawnItem(foodItems[Random.Range(0,foodItems.Count)], Vector3.zero, t);
                    break;
                }
            }
        }

        if (!isSpawning)
        {
            foreach (Transform t in spawnPoints)
            {
                if (t.childCount == 0)
                {
                    isSpawning = true;
                    startTime = Time.time;
                    break;
                }
            }
        }

    }

    #endregion

    #region Core Functions

    public void SpawnItem(GameObject item, Vector3 pos, Transform parent)
    {
        GameObject g =  Instantiate(item, pos, item.transform.rotation);
        g.transform.SetParent(parent);
        g.transform.localPosition = Vector3.zero;
    }

    #endregion
}
