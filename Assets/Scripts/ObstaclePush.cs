using UnityEngine;

public class ObstaclePush : MonoBehaviour
{
    [SerializeField]
    private float forceMagnitude;
    private Rigidbody rigidbody;
    private Vector3 forceDirection;
    public Interactable interactable;
    public GameObject cube;

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        rigidbody = hit.collider.attachedRigidbody;
        if (rigidbody != null)
        {
            forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0f;
            forceDirection.Normalize();
            
            if (rigidbody.tag == "CressBox")
            {
                if (interactable.KeyCard3Found)
                {
                    if (cube.transform.position.z >= -60.5 || cube.transform.position.z <= -56.0 || cube.transform.position.x >= -67.0 || cube.transform.position.x <= -63.6)
                    {
                        interactable.greenBoxMoved = true;
                    }
                    rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
                }
                else
                {
                    interactable.showLastInfo();
                }
            } 

            //if (rigidbody.tag == "Wardrobe")
            //{
            //    rigidbody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
            //}
        }
    }
}
