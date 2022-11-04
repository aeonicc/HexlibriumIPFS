using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeometricGravityGraphGridGate : MonoBehaviour
{
 

    
    struct Car
    {
        private string color;

        public Car(string color)
        {
            this.color = color;
        }

        public string Describe()
        {
            return "This car is " + Color;
        }

        public string Color
        {
            get { return color; }
            set { color = value; }
        }
    }

    private void Update()
    {
        //print(color);
    }

    // public static Vector3 GetGravity (Vector3 position) {
    //     return Quaternion Quaternion; //Physics.gravity;
    // }
    //
    // public static Vector3 GetUpAxis (Vector3 position) {
    //     return -Physics.gravity.normalized;
    // }
    //
    // public static Vector3 GetGravity (Vector3 position, out Vector3 upAxis) {
    //     upAxis = -Physics.gravity.normalized;
    //     return Physics.gravity;
    // }
}
