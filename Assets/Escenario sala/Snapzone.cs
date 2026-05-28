using UnityEngine;

public class Snapzone : MonoBehaviour
{
    public string objetoTag = "Pieza";

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(objetoTag))
        {
            // apagar física
            Rigidbody rb = other.GetComponent<Rigidbody>();

            if (rb != null)
            {
                rb.linearVelocity = Vector3.zero;
                rb.angularVelocity = Vector3.zero;

                rb.isKinematic = true;
            }

            // mover al punto exacto
            other.transform.position = transform.position;
            other.transform.rotation = transform.rotation;
        }
    }
}
