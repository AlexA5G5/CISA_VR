using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class GrabHandPose : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public HandData rightHandPose;
    public HandData realRightHand;   // MANO REAL (del XR Origin)


    private Vector3 startingHandPosition;
    private Vector3 finalHandPosition;
    private Quaternion startingHandRotation;
    private Quaternion finalHandRotation;

    private Quaternion[] startingFingerRotations;
    private Quaternion[] finalFingerRotations;

    void Start()
    {
        XRGrabInteractable grabInteractable = GetComponent<XRGrabInteractable>();
        
        grabInteractable.selectEntered.AddListener(SetupPose);
        grabInteractable.selectExited.AddListener(UnSetPose);
        
        rightHandPose.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void SetupPose(BaseInteractionEventArgs arg)
    {
        if (arg.interactorObject is XRDirectInteractor)
        {
            //HandData handData = arg.interactorObject.transform.GetComponent<HandData>();

            //handData.animator.enabled= false;
            realRightHand.animator.enabled = false;

            SetHandDataValues(realRightHand, rightHandPose);
            SetHandData(realRightHand,finalHandPosition,finalHandRotation,finalFingerRotations);
        }
    }
    public void UnSetPose(BaseInteractionEventArgs arg)
    {
        if (arg.interactorObject is XRDirectInteractor)
        {
            //HandData handData = arg.interactorObject.transform.GetComponentInChildren<HandData>();
            realRightHand.animator.enabled = true;

            SetHandData(realRightHand, startingHandPosition, startingHandRotation, startingFingerRotations);
        }
    }

    public void SetHandDataValues(HandData h1, HandData h2)
    {
        //startingHandPosition = h1.root.localPosition;
        //finalHandPosition = h2.root.localPosition;

        startingHandPosition = new Vector3 (h1.root.localPosition.x/ h1.root.localScale.x, 
            h1.root.localPosition.y/ h1.root.localScale.y, h1.root.localPosition.z/ h1.root.localScale.z);
        finalHandPosition = new Vector3(h2.root.localPosition.x / h2.root.localScale.x,
            h2.root.localPosition.y / h2.root.localScale.y, h2.root.localPosition.z / h2.root.localScale.z);

        startingHandRotation = h1.root.localRotation;
        finalHandRotation = h2.root.localRotation;

        startingFingerRotations = new Quaternion[h1.fingerBones.Length];
        finalFingerRotations = new Quaternion[h1.fingerBones.Length];

        for (int i = 0; i < h1.fingerBones.Length; i++)
        {
            startingFingerRotations[i] = h1.fingerBones[i].localRotation;
            finalFingerRotations[i] = h2.fingerBones[i].localRotation;
        }

    }
    public void SetHandData(HandData h, Vector3 newPosition, Quaternion newRotation, Quaternion[] newBonesRotation)
    {
        h.root.localPosition = newPosition;
        h.root.localRotation = newRotation;

        for (int i = 0; i < newBonesRotation.Length; i++)
        {
            h.fingerBones[i].localRotation = newBonesRotation[i];
        }
    }



}
