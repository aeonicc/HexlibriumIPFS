using UnityEngine;

namespace HEXLIBRIUM
{public class RotateBehaviour : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(Vector3.up * 50 * Time.deltaTime);
    }
}
    
}

