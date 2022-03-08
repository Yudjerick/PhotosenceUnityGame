using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereProjector : FigureProjector
{
    
    private GameObject sphere;
    private float radius;
    public GameObject projectionRef;
    private CircleCollider2D cirCol;
    private Plane plane;
    private GameObject projection;
    void Start()
    {
        sphere = gameObject;

        SphereCollider shpCol = sphere.GetComponent<SphereCollider>();
        radius = shpCol.radius * sphere.transform.localScale.x;
        plane = new Plane(plPoints[0].position, plPoints[1].position, plPoints[2].position);


        float k = (cameraPoint.position - CalculatePoint(plane, cameraPoint.position, sphere.transform.position)).magnitude / (cameraPoint.position - sphere.transform.position).magnitude;
        float newRad = radius * k;
        Vector3 center3 = CalculatePoint(plane, cameraPoint.position, sphere.transform.position);
        projection = Instantiate(projectionRef, center3, Quaternion.identity);
        cirCol = projection.GetComponent<CircleCollider2D>();
        cirCol.radius = newRad;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            
            Destroy(projection);
            

            float k = (cameraPoint.position - CalculatePoint(plane, cameraPoint.position, sphere.transform.position)).magnitude / (cameraPoint.position - sphere.transform.position).magnitude;
            float newRad = radius * k;
            Vector3 center3 = CalculatePoint(plane, cameraPoint.position, sphere.transform.position);

            projection = Instantiate(projectionRef, center3, Quaternion.identity);
            cirCol = projection.GetComponent<CircleCollider2D>();
            cirCol.radius = newRad;
        }
    }

}
