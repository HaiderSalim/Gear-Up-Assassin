using UnityEngine;

public class Animation_Handler : MonoBehaviour
{
    private Handler_Referencer handler_Referencer;//Holds the reference to all the handlers that the game has

    [Header("Gun animation fields")]
    private float Mousex_input;

    private void Start()
    {
        handler_Referencer = GameObject.FindGameObjectWithTag("Game Handler").GetComponent<Handler_Referencer>();
    }

    private void Update()
    {
        Mousex_input = Input.GetAxis("Mouse X");
    }
}
