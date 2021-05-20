using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndShoot : MonoBehaviour
{

    private Vector3 mousePressDownPos;
    private Vector3 mouseReleasePos;
    private Rigidbody rb;

    private bool isShoot;

    float forceMultiplier = 2;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {     
        mousePressDownPos = Input.mousePosition;
    }

    private void OnMouseDrag()
    {
        Vector3 forceInit = (Input.mousePosition - mousePressDownPos);
        Vector3 forceV = new Vector3(forceInit.x, forceInit.y/2, forceInit.y) * forceMultiplier;

        if(!isShoot)
        DrawTrajectory.Instance.UpdateTrajectory(forceV, rb, transform.position);
    }

    private void OnMouseExit()
    {
        DrawTrajectory.Instance.HideLine();
    }
    private void OnMouseUp()
    {
        DrawTrajectory.Instance.HideLine();
        mouseReleasePos = Input.mousePosition;
        Shoot(mousePressDownPos - mouseReleasePos);
        transform.parent = null;
    }

    void Shoot(Vector3 force)
    {
        if (isShoot)
            return;
        
        rb.AddForce(new Vector3(force.x, force.y/2, force.y) * forceMultiplier);
        isShoot = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
