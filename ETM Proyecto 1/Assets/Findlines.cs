using UnityEngine;

public class FindComponents : MonoBehaviour
{
    void Start()
    {
        GameObject rightHand = GameObject.Find("Right hand");

        if (rightHand != null)
        {
            Component[] components = rightHand.GetComponentsInChildren<Component>(true);

            Debug.Log("===== COMPONENTES EN RIGHT HAND =====");

            foreach (Component comp in components)
            {
                if (comp != null)
                {
                    Debug.Log(
                        "Objeto: " + comp.gameObject.name +
                        " | Componente: " + comp.GetType().Name
                    );
                }
            }
        }
        else
        {
            Debug.Log("No se encontró Right hand");
        }
    }
}