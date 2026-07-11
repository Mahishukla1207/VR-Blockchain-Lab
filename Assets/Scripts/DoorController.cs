using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    public Transform door;
    public Transform knob;
    public float openAngle = 90f;
    public float openSpeed = 2f;
    public float requiredKnobRotation = 30f;
    public string sceneToLoad;

    public AudioSource knobSound;
    public AudioSource doorSound;

    private bool doorOpening = false;
    private bool sceneLoaded = false;
    private bool soundPlayed = false;

    private float initialKnobRotation;

    void Start()
    {
        // Store starting rotation
        initialKnobRotation = knob.localEulerAngles.y;
    }

    void Update()
{
    var grab = knob.GetComponent<UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable>();

    // DO NOTHING unless user is grabbing the knob
    if (!grab || !grab.isSelected)
        return;

    float currentRotation = knob.localEulerAngles.y;
    float rotationDelta = Mathf.DeltaAngle(initialKnobRotation, currentRotation);

    if (Mathf.Abs(rotationDelta) >= requiredKnobRotation)
    {
        doorOpening = true;
    }

    if (doorOpening)
    {
        Quaternion targetRotation = Quaternion.Euler(0, openAngle, 0);
        door.localRotation = Quaternion.Lerp(
            door.localRotation,
            targetRotation,
            Time.deltaTime * openSpeed
        );

        if (!sceneLoaded &&
            Quaternion.Angle(door.localRotation, targetRotation) < 5f)
        {
            sceneLoaded = true;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}

}
