using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrajectory : MonoBehaviour
{
    [SerializeField]
    private LineRenderer _lineRenderer;

    [SerializeField]
    [Range(3, 30)]
    private int lineSegmentCount = 20;

    [SerializeField]
    [Range(10, 100)]
    private int _showPercentage = 50;

    [SerializeField]
    private int _linePointCount;


    private List<Vector3> _linePoints = new List<Vector3>();

    #region Singleton
    public static DrawTrajectory Instance;

    private void Awake()
    {
        Instance = this;
    }

    #endregion

    public void UpdateTrajectory(Vector3 forceVector, Rigidbody rigidbody, Vector3 startingPoint)
    {
        Vector3 velocity = (forceVector / rigidbody.mass) * Time.fixedDeltaTime;
        float FlightDuration = (2 * velocity.y) / Physics.gravity.y;
        float stepTime = FlightDuration / lineSegmentCount;

        _linePoints.Clear();
        _linePoints.Add(startingPoint);
        //for (int i = 1; i < _linePointCount; i++)
        for (int i = 1; i < lineSegmentCount; i++)
        {
            float stepTimePassed = stepTime * i; //change in time
            Vector3 MovementVector = new Vector3(
        velocity.x * stepTimePassed,
        velocity.y * stepTimePassed - 0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed,
        velocity.z * stepTimePassed
        );

            Vector3 NewPointOnLine = -MovementVector + startingPoint;
            
            RaycastHit hit;
            if (Physics.Raycast(_linePoints[i - 1], NewPointOnLine - _linePoints[i - 1], out hit, (NewPointOnLine - _linePoints[i - 1]).magnitude))
            {
                _linePoints.Add(hit.point);
                break;
            }
            Debug.DrawLine(_linePoints[i - 1], NewPointOnLine, Color.magenta, 8.0f, true); //drawing for debugging

            //Vector3 direction = (NewPointOnLine - startingPoint).normalized;

            //while ((NewPointOnLine - startingPoint).magnitude > (startingPoint - startingPoint).magnitude)
            //{
            //    _linePoints.Add(NewPointOnLine);
            //    NewPointOnLine += (direction * 0.2f);
            //}


            _linePoints.Add(NewPointOnLine);

        }
       
        _lineRenderer.positionCount = _linePoints.Count;
        _lineRenderer.SetPositions(_linePoints.ToArray());


    }

    public void HideLine()
    {
        _lineRenderer.positionCount = 0;
    }
}
