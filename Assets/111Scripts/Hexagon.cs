using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hexagon : MonoBehaviour
{
    [SerializeField] public GameObject hexagon;

    [SerializeField] private GameObject points;
    [SerializeField] private GameObject line;
    [SerializeField] private GameObject surface;

    struct Point
    {
        public float x;
        public float y;
    }

    private Point point = new Point();

    [SerializeField] private Vector3 center;
    [SerializeField] private float size;
    [SerializeField] private int i;


    private Vector3[] cubeVectors;
    private int direction;

    private void Start()
    {
        // cubeVectors[1] = new Vector3(1, 0, -1);
        // cubeVectors[2] = new Vector3(1, -1, 0);
        // cubeVectors[3] = new Vector3(0, -1, 1);
        // cubeVectors[4] = new Vector3(-1, 0, 1);
        // cubeVectors[5] = new Vector3(-1, 1, 0);
        // cubeVectors[6] = new Vector3(0, 1, -1);
        
    }

    private void Update()
    {
        
        //hexagon.transform.localPosition = PointyHexCorner(center, size, i);
        
        var hex = PointyHexCorner(center, size, i);

        Debug.DrawLine(Vector3.zero, hex, Color.white, 2.5f);
    }

    public Vector3 PointyHexCorner(Vector3 center, float size, int i)
        {
            float angle_deg = 60 * i - 30;
            float angle_rad = Mathf.PI / 180 * angle_deg;

            return new Vector3(point.x = center.x + size * Mathf.Cos(angle_rad),point.y = center.y + size * Mathf.Sin(angle_rad), center.z);
        }


    // function cube_to_axial(cube)
    // {
    //     var q = cube.q
    //     var r = cube.r
    //     return Hex(q, r)
    // }
    //
    //
    // function axial_to_cube(hex)
    // {
    //     var q = hex.q
    //     var r = hex.r
    //     var s = -q-r
    //     return Cube(q, r, s)
    // }
    //
    //     
    // Vector3 cube_direction(int direction)
    // {
    //     return cubeVectors[direction];
    // }
    //
    //
    // GameObject cube_add(hex, vec)
    // {
    //     return Cube(hex.q + vec.q, hex.r + vec.r, hex.s + vec.s);
    // }
    //
    //
    // void cube_neighbor(cube, int direction)
    // {
    //     return cube_add(cube, cube_direction(direction));
    // }
        

    //PointyHexCorner();
//
// //
// private void Update()
// {
//  //   points.transform.localPosition(0, 0, 0);//= nwe Vector3();    
// //    print(points);
// // }


//     // //private Vector3 center = new Vector3(1f, 1f, 1f);
//     //
//     // public GameObject Point
//     // {
//     //     get => points;
//     //     set => points = value;
//     //
//     //
//     //     // private int x;
//     //     // private int y;
//     //
//     //     // private void OnDestroy()
//     //     // {
//     //     //     throw new NotImplementedException();
//     //     // }
//     // }
//     //
//     //
//     // struct PointPosition
//     // {
//     //     private int x;
//     //     private int y;
//     // }
//     //
//     // struct PointRotation
//     // {
//     // }
//     //
//     //
//     // //float 
//     //
//     // public GameObject Line
//     // {
//     //     get => line;
//     //     set => line = value;
//     // }
//     //
//     // public GameObject Surface
//     // {
//     //     get => surface;
//     //     set => surface = value;
//   //  }
//
// //private Vector2 center = new Vector2();

//     //
//     // private float size;
//     // private float i;
//
//     // struct Points
//     // {
//     //     public float x;
//     //     public float y;
//     // }
//
//
//     // struct IO64
//     // {
//     //     int I;
//     //     int O;
//     // }
//
//  //   private IO64 io64 = new IO64();
//
//
// // public IO64 IO64
// // {
// //     get => io64;
// //     set => io64 = value;
// //}
//
//
// //private Points points = new Points();
//
}