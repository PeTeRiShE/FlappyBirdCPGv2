using UnityEngine;

public class FloorMoveController : MonoBehaviour
{
    private float GroundBorderLine = -1.5f;
 
    void Update()
    { 
        if (transform.localPosition.x < GroundBorderLine)
        {
                
            transform.localPosition = new Vector3(0, transform.localPosition.y, transform.localPosition.z);
        }
        transform.Translate(-Time.deltaTime, 0, 0);
        
    }
}
