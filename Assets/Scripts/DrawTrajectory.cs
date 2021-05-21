using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrajectory : MonoBehaviour
{


    [SerializeField]
    [Range(3, 30)]
    private int _lineSegmentCount=40;

    private List<Vector3> _linePoints = new List<Vector3>();
    [SerializeField] private List<GameObject> _sphere = new List<GameObject>();



    #region Singleton
    public static DrawTrajectory Instance;

    private void Awake()
    {
        Instance = this; 
    }
    #endregion
    void Start()
    {
        
    }

    public void UpdateTrajectory(Vector3 forceVector, Rigidbody rigidbody, Vector3 startingPoint)
    {
        Vector3 velocity = (forceVector / rigidbody.mass) * Time.fixedDeltaTime;
        float flightDuration = (2 * velocity.y) / Physics.gravity.y;
        float stepTime = flightDuration / _lineSegmentCount;
        _linePoints.Clear();
        foreach (GameObject g in _sphere)
        {
            Destroy(g);
        }
        _sphere.Clear();
        for (int i = 0; i < _lineSegmentCount; i++)
        {
            float stepTimePassed = stepTime * i;
            Vector3 MovementVector = new Vector3(
                velocity.x * stepTimePassed,
                velocity.y * stepTimePassed - 0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed,
                velocity.z * stepTimePassed
                );
            _linePoints.Add(-MovementVector + startingPoint);
        }
      
        foreach(Vector3 v in _linePoints)
        {
            _sphere.Add(Instantiate(GameManager.Instance.sphere, v, Quaternion.identity));
        }
    }

    public void HideLine()
    {
       
        foreach (GameObject g in _sphere)
        {
            Destroy(g);
        }
        _sphere.Clear();
    }
    // Start is called before the first frame update
   

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            foreach (GameObject g in _sphere)
            {
                Destroy(g);
            }
            _sphere.Clear();

        }
      
    }
}
