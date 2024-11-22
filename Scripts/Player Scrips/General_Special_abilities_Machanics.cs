using System.Collections;
using UnityEngine;

public class General_Special_abilities_Machanics : MonoBehaviour
{
    enum Ability_type {ImpelsivePunch, FlameThrower, IceBlast, ShockBlast}
    [SerializeField]
    private Ability_type ability_Type;

    [Header("Special Abilities Parameters")]
    [SerializeField]
    private Special_Abilities_info impelsive_Punch_Info = null;
    [SerializeField]
    private Special_Abilities_info flame_Thrower_Info = null;
    [SerializeField]
    private Special_Abilities_info ice_Blast_Info = null;
    [SerializeField]
    private Special_Abilities_info shock_Blast_Info = null;

    [Header("Impelsive punch related fields"), Range(0f, 100f), SerializeField]
    private float punch_Force = 5f;
    [SerializeField, Range(0f, 2f)]
    
    private Special_Abilities_info current_Special_Abilities_Info;
    
    //Handler
    private Handler_Referencer handler_Referencer;//Holds the reference to all the handlers that the game has

    private Camera cam;
    private float fire_Rate_Temp;
    private float Scroll_wheel_axis;

    void Start()
    {
        handler_Referencer = GameObject.FindGameObjectWithTag("Game Handler").GetComponent<Handler_Referencer>();
        cam = Camera.main;

        current_Special_Abilities_Info = impelsive_Punch_Info;
        fire_Rate_Temp = 0f;
    }

    void FixedUpdate()
    {
        Scroll_wheel_axis = Input.GetAxis("Mouse ScrollWheel");//get the mouse scroll wheel movement

        if (handler_Referencer.first_Person_Handler.isAbilitySelected)
        {
            handler_Referencer.first_Person_Handler.SP_Hand.SetActive(true);
            Change_currnet_SP_info();
            Change_current_SP();
            Use_ability();
        }
    }
    
    public void Use_ability()
    {
        if (Input.GetMouseButtonDown(0))
        {
            var pos = cam.ViewportToWorldPoint(handler_Referencer.first_Person_Handler.Crosshair_pos_relative_to_viewport);

            if (fire_Rate_Temp <= 0)
            {
                if (ability_Type == Ability_type.ImpelsivePunch)
                {
                    Debug.Log("Impelsive_punch!!!!");
                    Impelsive_punch();
                }
                else if (ability_Type == Ability_type.FlameThrower)
                {
                    Debug.Log("Flame_thrower!!!!");
                    Flame_thrower();
                }
                else if (ability_Type == Ability_type.IceBlast)
                {
                    Debug.Log("Ice_blast!!!!");
                }
                else if (ability_Type == Ability_type.ShockBlast)
                {
                    Debug.Log("Shock_blast!!!!");
                }
                fire_Rate_Temp = current_Special_Abilities_Info.fire_Rate;
            }
        }
        fire_Rate_Temp -= Time.deltaTime;
    }

    private void Change_currnet_SP_info()
    {
        switch (ability_Type)
        {
            case Ability_type.ImpelsivePunch:
                current_Special_Abilities_Info = impelsive_Punch_Info;
                break;
            case Ability_type.FlameThrower:
                current_Special_Abilities_Info = flame_Thrower_Info;
                break;
            case Ability_type.IceBlast:
                current_Special_Abilities_Info = ice_Blast_Info;
                break;
            case Ability_type.ShockBlast:
                current_Special_Abilities_Info = shock_Blast_Info;
                break;
            default:
                current_Special_Abilities_Info = null;
                break;
        }
        handler_Referencer.first_Person_Handler.SP_indecator.material = current_Special_Abilities_Info.indecator_Material;
    }

    public void Change_current_SP()
    {
        if (Scroll_wheel_axis < 0f && ((int)ability_Type) < 3)
        {
            ability_Type++;
            handler_Referencer.ui_Handler.selected_Ability_Name.text = ability_Type.ToString();
            //ResetWeaponTransform();
            //handler_Referencer.first_Person_Handler.Current_selected_SP = handler_Referencer.first_Person_Handler.Guns[(int)ability_Type];
        }
        else if (Scroll_wheel_axis > 0f && ((int)ability_Type) > 0)
        {
            ability_Type--;
            handler_Referencer.ui_Handler.selected_Ability_Name.text = ability_Type.ToString();
            //ResetWeaponTransform();
            //handler_Referencer.first_Person_Handler.Current_selected_SP = handler_Referencer.first_Person_Handler.Guns[(int)ability_Type];
        }

        if (Scroll_wheel_axis != 0)
        {
            fire_Rate_Temp = 0;
            handler_Referencer.ui_Handler.Text_in(handler_Referencer.ui_Handler.selected_Ability_Name);

            // Save new gun's original position and rotation
            //SaveWeaponTransform();

            //handler_Referencer.first_Person_Handler.Current_selected_SP.GetComponent<Animator>().SetTrigger("Play selected");
        }
        handler_Referencer.ui_Handler.Text_fade_out(handler_Referencer.ui_Handler.selected_Ability_Name);
    }

    //Impelsive_punch
    void Impelsive_punch()
    {
        var dir = cam.transform.forward;
        dir.y = 0f;
        StartCoroutine(PunchMovement(dir, current_Special_Abilities_Info.duration));
    }

    IEnumerator PunchMovement(Vector3 direction, float duration)
    {
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            transform.localPosition += direction * punch_Force;
            elapsedTime += Time.deltaTime; // Increment elapsed time
            yield return null; // Wait for the next frame
        }
    }

    //Flame_thrower
    void Flame_thrower()
    {

    }
}
