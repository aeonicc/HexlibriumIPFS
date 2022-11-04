using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private bool UseCameraTransform;
    [SerializeField] public Camera _cameraTransform;
    // private Camera camera;
    // private void Awake()
    // {
    //     camera = Camera.main;
    //
    //     if (camera == null)
    //     {
    //         Debug.LogError("We need a MainCamera to work :)");
    //     }
    // }
    
    void Update()
    {
        // if(UseCameraTransform)
        // {
        //transform.LookAt(_cameraTransform.transform.position, -Vector3.up);
        // }
        // else
        // {
            transform.Rotate(Vector3.up * -50 * Time.deltaTime);
        // }
    }

    // private void LateUpdate()
    // {
    //     if (camera is null) return;
    //     
    //     transform.LookAt(camera.transform);
    // }
}