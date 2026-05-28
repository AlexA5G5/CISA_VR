using UnityEngine;
using System.Collections;

public class SequenceController : MonoBehaviour
{
    public Transform puntoA;
    public Transform puntoB;

    public float speed = 2f;
    public Animator animator;

    public AudioSource audioNinos;

    private bool enSecuencia = false;

    public void StartSequence()
    {
        if (!enSecuencia)
        {
            StartCoroutine(Secuencia());
        }
    }

    IEnumerator Secuencia()
    {
        enSecuencia = true;

        // 🔊 1. Sonido de niños por 15s
        audioNinos.loop = true;
        audioNinos.Play();

        yield return new WaitForSeconds(15f);

        audioNinos.Stop();

        // 🚶 2. Movimiento por 15s (ida y vuelta)
        float tiempo = 0f;
        bool haciaB = true;

        animator.SetBool("SeMueve", true);

        while (tiempo < 20f)
        {
            Transform objetivo = haciaB ? puntoB : puntoA;

            Vector3 direccion = (objetivo.position - transform.position).normalized;

            transform.position += direccion * speed * Time.deltaTime;

            // Rotación
            if (direccion != Vector3.zero)
            {
                Quaternion rot = Quaternion.LookRotation(direccion);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, 10f * Time.deltaTime);
            }

            // Si llega cerca al punto, cambia dirección
            if (Vector3.Distance(transform.position, objetivo.position) < 0.1f)
            {
                haciaB = !haciaB;
            }

            tiempo += Time.deltaTime;
            yield return null;
        }

        animator.SetBool("SeMueve", false);

        // 🛑 Fin
        enSecuencia = false;
    }
}