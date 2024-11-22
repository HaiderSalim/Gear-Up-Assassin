using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Stats Fields")] public Player_info player_Info;

    [HideInInspector] public int currentHealth;
    [HideInInspector] public float currentSteam;

    private Ui_Handler ui_Handler;

    void Start()
    {
        ui_Handler = GameObject.FindGameObjectWithTag("UIHandler").GetComponent<Ui_Handler>();

            Debug.Log("CurrentHealth1" + currentHealth);
        //Debug Logs to check initialization values
    }

    void Update()
    {
        // just for testing....
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Reduce_current_health(20);
            Debug.Log("Current Health after reduction: " + currentHealth + " " + "YellowBar" + ui_Handler.yellow_bar_currentfill);

        }        

        if(Input.GetKeyDown(KeyCode.A))
        {
            Reduce_current_steam(5);
            Debug.Log("Current Steam after reduction: " + currentSteam + " " + "Grey Bar" + ui_Handler.grey_bar_currentfill);

        }        
    }

    public void Reduce_current_health(int damage)
    {
        currentHealth -= damage; 
        currentHealth = Mathf.Clamp(currentHealth , 0 , player_Info.Health);
        ui_Handler.UpdateHealthBar();
    }

    public void Reduce_current_steam(int cost)
    {
        currentSteam -= cost;
        currentSteam = Mathf.Clamp(currentSteam , 0 , player_Info.Steam);
        ui_Handler.UpdateSteamBar();
    }
}