using UnityEngine;
using FirstGearGames.SmoothCameraShaker;

public class Camera_effect_Handler : MonoBehaviour
{
    [Header("Camera Shake data")]
    public ShakeData Gun_Recoil_shake;
    public ShakeData Grenade_explosion_shake;
    public ShakeData Dash_shake;

    [Header("Animators")]
    public Animator Camera_animator;

    //Camera variables
    private Camera Main_cam;

    //Handles
    private Handler_Referencer handler_Referencer;//Holds the reference to all the handlers that the game has
    private First_Person_Handler first_Person_Handler;

    void Start()
    {
        handler_Referencer = GameObject.FindGameObjectWithTag("Game Handler").GetComponent<Handler_Referencer>();
        Main_cam = Camera.main;
        Camera_animator = Main_cam.GetComponent<Animator>();
        first_Person_Handler = handler_Referencer.first_Person_Handler;
    }

    public void Trigger_Dash_Camera_effect()
    {
        if (first_Person_Handler.Has_dashed)
        {
            Camera_animator.SetTrigger("Play_Dash_anime");
            CameraShakerHandler.Shake(Dash_shake);
        }
    }

    public void Trigger_Damaged_Camera_effect()
    {
        Camera_animator.SetTrigger("Play_damage_anime");
    }
}