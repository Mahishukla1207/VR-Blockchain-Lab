using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorKnobSceneLoader : MonoBehaviour
{
    public string sceneToLoad = "Module1_CentralizedWorld";
    public float requiredRotation = 45f;

    private bool sceneLoaded = false;

    void Update()
    {
        float yRotation = transform.localEulerAngles.y;

        if (yRotation > 180f)
            yRotation -= 360f;

        if (!sceneLoaded && Mathf.Abs(yRotation) >= requiredRotation)
        {
            sceneLoaded = true;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
