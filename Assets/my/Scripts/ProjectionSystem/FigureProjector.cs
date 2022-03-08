using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigureProjector : MonoBehaviour
{
    public Transform[] plPoints;
    public Transform cameraPoint;

    public Vector3 CalculatePoint(Plane pl, Vector3 X, Vector3 Y)
    {
        Vector3 A = pl.ClosestPointOnPlane(X);
        Vector3 N = pl.normal;
        Vector3 V = A - X;
        float d = Vector3.Dot(N, V);
        Vector3 W = Y - X;
        float e = Vector3.Dot(N, W);
        if(e != 0)
        {
            Vector3 O = X + W * d / e;
            return O;
        }
        return Vector3.zero;
    }
    

}
