using UnityEngine;

public class HandData : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public enum HandModelType { Left, Right}

    public HandModelType handType;
    public Transform root;
    public Animator animator;
    public Transform[] fingerBones;

}
