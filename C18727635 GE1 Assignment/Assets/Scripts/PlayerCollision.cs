using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter (Collision collisionInfo) 
    {
        Debug.Log("we hit a " + collisionInfo.collider.name);
    }
    
}
