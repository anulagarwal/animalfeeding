using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class Food : MonoBehaviour
{
    [Header("Attributes")]
    [SerializeField] public EnumsManager.FoodType type;
    // [SerializeField] public float scaleDownRate = 0.01f;
    // bool isDying;
    // // Start is called before the first frame update
    // void Start()
    // {
    //     //  GetComponent<Rigidbody>().useGravity = false;
    // }
    //
    //
    // // Update is called once per frame
    // void Update()
    // {
    //     if (isDying)
    //     {
    //         if (transform.localScale.x < 0)
    //             Destroy(gameObject);
    //         transform.localScale = new Vector3(transform.localScale.x - scaleDownRate, transform.localScale.y - scaleDownRate, transform.localScale.z - scaleDownRate);
    //     }
    // }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            transform.DOScale(0, .7f).SetDelay(.3f).onComplete += () => Destroy(gameObject);
            
            // isDying = true;
            // Destroy(gameObject, 1.4f);
        }
    }
}
