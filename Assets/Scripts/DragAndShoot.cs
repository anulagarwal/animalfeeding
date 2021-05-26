using System;
using System.Collections;
using System.Collections.Generic;
using D2D.Gameplay;
using D2D.Utilities;
using D2D.Utilities.CodeSugar;
using DG.Tweening;
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

        var x = force.x;
        var z = force.y;
        var y = force.y / 2;
        if (z < 0)
        {
            var f = GameplaySettings.Instance.forceFactor; 
            z *= -f;
            y *= f;
            x *= -f;
        }

        transform.DOJump(DrawTrajectory.Instance.LastPoint, 1, 1, 1f);
        // rb.AddForce(new Vector3(x, y, z) * forceMultiplier);
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
            mouseReleasePos = Input.mousePosition;

            // if (Input.GetMouseButtonUp(0) && mousePressDownPos.y - mouseReleasePos.y>100)
            // {
            //     mouseReleasePos = Input.mousePosition;
            //
            //     DrawTrajectory.Instance.HideLine();
            //     Shoot(mousePressDownPos - mouseReleasePos);
            //     transform.parent = null;
            //     isDrag = false;
            //     AnimalManager.Instance.isTrajectoryOn = false;
            // }
            // else if(Input.GetMouseButtonUp(0) && mousePressDownPos.y - mouseReleasePos.y < 100)
            // {
            //     DrawTrajectory.Instance.HideLine();
            //     isDrag = false;
            //     AnimalManager.Instance.isTrajectoryOn = false;
            // }
        }
    }

    private void Update()
    {
        // #patch
        if (isDrag && DInput.IsMouseReleased)
        {
            mouseReleasePos = Input.mousePosition;
            DrawTrajectory.Instance.HideLine();
            Shoot(mousePressDownPos - mouseReleasePos);
            transform.parent = null;
            isDrag = false;
            AnimalManager.Instance.isTrajectoryOn = false;
        }
    }
}
