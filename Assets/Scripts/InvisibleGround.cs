using UnityEngine;

public class InvisibleGround : MonoBehaviour
{
    private void Awake()
    {
        if (!TryGetComponent<BoxCollider>(out BoxCollider collider))
        {
            collider = gameObject.AddComponent<BoxCollider>();
        }

        collider.isTrigger = false;

        if (!TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb = gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        gameObject.tag = "Ground";
    }
}
