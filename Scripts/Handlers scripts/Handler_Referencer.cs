using UnityEngine;

public class Handler_Referencer : MonoBehaviour
{
    [Header("Handlers List")]
    public Animation_Handler animation_Handler;
    public Camera_effect_Handler camera_Effect_Handler;
    public First_Person_Handler first_Person_Handler;
    public Ui_Handler ui_Handler;
    public PlayerStats playerStats;

    void Start()
    {
        first_Person_Handler = GameObject.FindGameObjectWithTag("GameController").GetComponent<First_Person_Handler>();
        camera_Effect_Handler = GameObject.FindGameObjectWithTag("EffectHandler").GetComponent<Camera_effect_Handler>();
        ui_Handler = GameObject.FindGameObjectWithTag("UIHandler").GetComponent<Ui_Handler>();
        animation_Handler = GameObject.FindGameObjectWithTag("EffectHandler").GetComponent<Animation_Handler>();
        playerStats = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerStats>();
    }
}
