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

   public bool isDrag = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnMouseDown()
    {
        if (!AnimalManager.Instance.isTrajectoryOn)
        {
            AnimalManager.Instance.isTrajectoryOn = true;
            mousePressDownPos = Input.mousePosition;
            isDrag = true;
        }
    }



    void Shoot(Vector3 force)
    {
        if (isShoot)
            return;
        
        rb.AddForce(new Vector3(force.x, force.y/2, force.y) * forceMultiplier);
        isShoot = true;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (isDrag)
        {
            Vector3 forceInit = (Input.mousePosition - mousePressDownPos);
            Vector3 forceV = new Vector3(forceInit.x, forceInit.y / 2, forceInit.y) * forceMultiplier;

            if (!isShoot)
                DrawTrajectory.Instance.UpdateTrajectory(forceV, rb, transform.position);

            if (Input.GetMouseButtonUp(0))
            {
                DrawTrajectory.Instance.HideLine();
                mouseReleasePos = Input.mousePosition;
                Shoot(mousePressDownPos - mouseReleasePos);
                transform.parent = null;
                isDrag = false;
                AnimalManager.Instance.isTrajectoryOn = false;
            }
        }
        
    }
}
