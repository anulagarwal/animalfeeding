using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] public EnumsManager.FoodType type;
    [SerializeField] public float scaleDownRate = 0.01f;
    bool isDying;
    // Start is called before the first frame update
    void Start()
    {
        //  GetComponent<Rigidbody>().useGravity = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (isDying)
        {
            transform.localScale = new Vector3(transform.localScale.x - scaleDownRate, transform.localScale.y - scaleDownRate, transform.localScale.z - scaleDownRate);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isDying = true;
            Destroy(gameObject, 1.4f);
        }
    }
}
