using EzySlice;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class Slice_Object : MonoBehaviour
{
    //public Transform planeDebug;
    //public GameObject target;
    public Transform starSlicePoint;
    public Transform endSlicePoint;
    public VelocityEstimator velocityEstimator;
    public LayerMask sliceableLayer;


    public Material crossSectionMaterial;
    public float cutForce = 10;
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //if (Keyboard.current.spaceKey.wasPressedThisFrame)
        //{
        //Slice(target);
        //}

        bool hasHit = Physics.Linecast(starSlicePoint.position, endSlicePoint.position, out RaycastHit hit, sliceableLayer);
        Debug.Log("Linecast ejecutado. Resultado = " + hasHit);

        if (hasHit) 
        {
            Debug.Log("Detecté objeto para cortar: " + hit.transform.name);
            GameObject target = hit.transform.gameObject;
            Slice(target);
        }


    }

    public void Slice(GameObject target)
    {
        Vector3 velocity = velocityEstimator.GetVelocityEstimate();
        Debug.Log("Velocidad usada para el corte: " + velocity.magnitude);

        Vector3 planeNormal = Vector3.Cross(endSlicePoint.position - starSlicePoint.position, velocity);
        planeNormal.Normalize();
        Debug.Log("Plano normal calculado: " + planeNormal);

        //SlicedHull hull = target.Slice(planeDebug.position, planeDebug.up);
        SlicedHull hull = target.Slice(endSlicePoint.position, planeNormal);


        if (hull != null)
        {
            Debug.Log("¡Corte realizado!");
            GameObject upperHull = hull.CreateUpperHull(target, crossSectionMaterial);
            GameObject loverHull = hull.CreateLowerHull(target,crossSectionMaterial);

            //upperHull.transform.position = target.transform.position;
            //loverHull.transform.position = target.transform.position;
           
            SetupSlicedComponent(upperHull);
            SetupSlicedComponent(loverHull);
            
            Destroy(target);
        }
    }

    public void SetupSlicedComponent(GameObject slicedObject)
    {
        Rigidbody rb = slicedObject.AddComponent<Rigidbody>();
        MeshCollider collider = slicedObject.AddComponent<MeshCollider>();
        collider.convex = true;
        //rb.AddExplosionForce(cutForce, slicedObject.transform.position, 1);
        XRGrabInteractable grab = slicedObject.AddComponent<XRGrabInteractable>();

    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        if (starSlicePoint != null && endSlicePoint != null)
            Gizmos.DrawLine(starSlicePoint.position, endSlicePoint.position);
    }
}

