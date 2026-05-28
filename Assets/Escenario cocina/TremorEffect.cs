using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TremorEffect : MonoBehaviour
{
    [Header("Referencia visual")]
    public Transform visualModel;

    [Header("Temblor")]
    public float intensidad = 0.005f;
    public float velocidad = 25f;

    private XRGrabInteractable grabInteractable;

    private bool agarrado;

    private Vector3 posicionInicial;
    private Quaternion rotacionInicial;

    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();

        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);

        posicionInicial = visualModel.localPosition;
        rotacionInicial = visualModel.localRotation;
    }

    void OnGrab(SelectEnterEventArgs args)
    {
        agarrado = true;
    }

    void OnRelease(SelectExitEventArgs args)
    {
        agarrado = false;

        // resetear
        visualModel.localPosition = posicionInicial;
        visualModel.localRotation = rotacionInicial;
    }

    void Update()
    {
        if (!agarrado)
            return;

        Vector3 offset = new Vector3(
            (Mathf.PerlinNoise(Time.time * velocidad, 0f) - 0.5f),
            (Mathf.PerlinNoise(0f, Time.time * velocidad) - 0.5f),
            (Mathf.PerlinNoise(Time.time * velocidad, Time.time * 0.5f) - 0.5f)
        );

        visualModel.localPosition =
            posicionInicial + offset * intensidad;
    }
}