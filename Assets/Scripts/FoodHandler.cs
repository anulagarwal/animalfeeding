using System.Collections;
using System.Collections.Generic;
using D2D.Utilities;
using UnityEngine;

public class FoodHandler : MonoBehaviour
{
    #region Attributes
    [Header("Attributes")]
    [SerializeField] float spawnRate;

    [Header("Component References")]
    [SerializeField] List<GameObject> foodItems;
    [SerializeField] List<Transform> spawnPoints;


    private float startTime;
    private bool isSpawning;

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
           /* if (AnimalManager.Instance.animalsFed == 0)
            {
                foreach (Transform t in spawnPoints)
                {
                    if (t.childCount == 0)
                    {
                        SpawnItem(foodItems.GetRandomElement(), Vector3.zero, t);
                        break;
                    }
                }
            }
            else if(AnimalManager.Instance.animalsFed < AnimalManager.Instance.animals.Count)
            {*/
                List<EnumsManager.FoodType> availableType = new List<EnumsManager.FoodType>();

                foreach(Animal a in AnimalManager.Instance.animals)
                {
                    if (a.isInField)
                    {
                        availableType.AddRange(a.preferredFood); 
                    }
                }
                
                foreach (Transform t in spawnPoints)
                {
                    if (t.childCount == 0)
                    {                        
                        EnumsManager.FoodType f = availableType[Random.Range(0, availableType.Count)];
                        
                        SpawnItem(foodItems.Find( x=> x.GetComponent<Food>().type== f), Vector3.zero, t);
                        break;
                    }
                }
            //}

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
