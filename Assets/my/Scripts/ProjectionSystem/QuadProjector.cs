using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadProjector : FigureProjector
{
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;
    public GameObject testSpere;
    public GameObject polygonProjRef;
    private GameObject projection;
    private GameObject projection2;

    // Start is called before the first frame update
    void Start()
    {
        Plane plane = new Plane(plPoints[0].position, plPoints[1].position, plPoints[2].position);
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        triangles = mesh.triangles;
        Vector3 center3 = CalculatePoint(plane, cameraPoint.position, transform.position);


        projection = Instantiate(polygonProjRef, center3, Quaternion.identity);
        PolygonCollider2D polyCol = projection.GetComponent<PolygonCollider2D>();
        Vector2[] newPoints = new Vector2[3];
        for (int i = 0; i < 3; i++)
        {
            newPoints[i] = CalculatePoint(plane, cameraPoint.position, transform.TransformPoint(vertices[triangles[i]])) - center3; // works with planes perpendicular z

        }
        polyCol.points = newPoints;

        projection2 = Instantiate(polygonProjRef, center3, Quaternion.identity);
        PolygonCollider2D polyCol2 = projection2.GetComponent<PolygonCollider2D>();
        Vector2[] newPoints2 = new Vector2[3];
        for (int i = 3; i < 6; i++)
        {
            newPoints2[i - 3] = CalculatePoint(plane, cameraPoint.position, transform.TransformPoint(vertices[triangles[i]])) - center3; // works with planes perpendicular z

        }
        polyCol2.points = newPoints2;
    }
}
