using UnityEngine;

public class Playerabuelo : MonoBehaviour
{
    Animator animator;

    bool cojinA = false;
    bool cojinB = false;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // BOTÓN COJIN A
    public void CojinA()
    {
        cojinA = true;
        cojinB = false;

        Debug.Log("Cojin A seleccionado");
    }

    // BOTÓN COJIN B
    public void CojinB()
    {
        cojinB = true;
        cojinA = false;

        Debug.Log("Cojin B seleccionado");
    }

    // BOTÓN SENTARSE
    public void Sentarse()
    {
        // Primero apagar ambas animaciones
        animator.SetBool("Sentado1", false);
        animator.SetBool("Sentado2", false);

        // Activar según selección
        if (cojinA)
        {
            animator.SetBool("Sentado2", true);
        }

        if (cojinB)
        {
            animator.SetBool("Sentado1", true);
        }
    }

    // BOTÓN PARARSE
    public void Pararse()
    {
        animator.SetBool("Sentado1", false);
        animator.SetBool("Sentado2", false);

        cojinA = false;
        cojinB = false;
    }
}