using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshProjector : FigureProjector
{
    private Mesh mesh;
    private Vector3[] vertices;
    private int[] triangles;
    public GameObject testSpere;
    public GameObject polygonProjRef;
    private GameObject[] projections;

    private int projectionsAmount;
    private Plane plane;
    private Vector3 center3;

    // Start is called before the first frame update
    void Start()
    {
        plane = new Plane(plPoints[0].position, plPoints[1].position, plPoints[2].position);
        mesh = GetComponent<MeshFilter>().mesh;
        vertices = mesh.vertices;
        triangles = mesh.triangles;
        center3 = CalculatePoint(plane, cameraPoint.position, transform.position);

        projectionsAmount = triangles.Length / 3;
        projections = new GameObject[projectionsAmount];

        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && Mode.mode == "3D")
        {
            for (int i = 0; i < projectionsAmount; i++)
            {
                if (projections[i] != null)
                {
                    Destroy(projections[i]);
                }

                projections[i] = Instantiate(polygonProjRef, center3, Quaternion.identity);
                PolygonCollider2D polyCol = projections[i].GetComponent<PolygonCollider2D>();
                Vector2[] newPoints = new Vector2[3];
                for (int j = 0; j < 3; j++)
                {
                    newPoints[j] = CalculatePoint(plane, cameraPoint.position, transform.TransformPoint(vertices[triangles[j + i * 3]])) - center3; // works with planes perpendicular z

                }
                polyCol.points = newPoints;
            }
        }
    }

}
