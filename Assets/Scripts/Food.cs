using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] public EnumsManager.FoodType type;
    // Start is called before the first frame update
    void Start()
    {
      //  GetComponent<Rigidbody>().useGravity = false;
    }

  



    // Update is called once per frame
    void Update()
    {

    }
}
