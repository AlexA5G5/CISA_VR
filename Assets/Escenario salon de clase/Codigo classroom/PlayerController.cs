using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 2f;
    public float rotationSpeed = 10f;
    public Animator animator;

    void Update()
    {
        Vector2 input = Vector2.zero;

        if (Keyboard.current != null)
        {
            input.x = (Keyboard.current.dKey.isPressed ? 1 : 0) - (Keyboard.current.aKey.isPressed ? 1 : 0);
            input.y = (Keyboard.current.wKey.isPressed ? 1 : 0) - (Keyboard.current.sKey.isPressed ? 1 : 0);
        }

        Vector3 move = new Vector3(input.x, 0, input.y);

        bool seMueve = move.magnitude > 0.1f;

        if (seMueve)
        {
            move = move.normalized;

            // 🔥 Mover
            transform.position += move * speed * Time.deltaTime;

            // 🔥 Rotar suavemente hacia la dirección
            Quaternion targetRotation = Quaternion.LookRotation(move);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetRotation,
                rotationSpeed * Time.deltaTime
            );
        }

        animator.SetBool("SeMueve", seMueve);
    }
}