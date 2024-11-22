using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Ui_Handler : MonoBehaviour
{
    [Header("Play Mode UI")]
    public TMP_Text selected_Ability_Name;

    [Header("UI anime fields"), SerializeField, Range(0.01f, 0.1f)]
    private float fade_out_rate;

    [SerializeField] private float yellow_bar_delay = 4f;
    public float yellow_bar_currentfill = 100;

    [SerializeField] private float grey_bar_delay = 4f;
    public float grey_bar_currentfill;

    [SerializeField] private Image Yellow_bar;
    [SerializeField]  private Image Red_Health_bar;


    [SerializeField] private Image Grey_Steam_bar;
    [SerializeField] private Image Blue_Steam_bar;

    //Handler
    private Handler_Referencer handler_Referencer;


    void Start()
    {
        handler_Referencer = GameObject.FindGameObjectWithTag("Game Handler").GetComponent<Handler_Referencer>();
        if(handler_Referencer.playerStats.currentHealth == 0)
        {
            handler_Referencer.playerStats.currentHealth = handler_Referencer.playerStats.player_Info.Health;
        }

        if(handler_Referencer.playerStats.currentSteam == 0)
        {
            handler_Referencer.playerStats.currentSteam = handler_Referencer.playerStats.player_Info.Steam;
        }

        Debug.Log("CurrentHealth" + handler_Referencer.playerStats.currentHealth);

        yellow_bar_currentfill = (float)handler_Referencer.playerStats.currentHealth / handler_Referencer.playerStats.player_Info.Health;
        grey_bar_currentfill =   handler_Referencer.playerStats.currentSteam / handler_Referencer.playerStats.player_Info.Steam;
        
    }

    void Update()
    {
        SteamBarEffect();
        HealthBarEffect();
    }

    public void Text_fade_out(TMP_Text text)
    {
        if (text)
        {
            if (text.alpha > 0)
            text.alpha -= fade_out_rate;
        }
    }
    public void Text_in(TMP_Text text)
    {
        if (text)
        {
            text.alpha = 1;
        }
    }

    public void UpdateHealthBar()
    {
        float fillAmount = (float)handler_Referencer.playerStats.currentHealth/handler_Referencer.playerStats.player_Info.Health;
        Red_Health_bar.fillAmount = fillAmount;
    }

    public void UpdateSteamBar()
    {
        float fillAmount = handler_Referencer.playerStats.currentSteam/handler_Referencer.playerStats.player_Info.Steam;
        Blue_Steam_bar.fillAmount = fillAmount;
    }

    void HealthBarEffect()
    {
        if(Yellow_bar.fillAmount > Red_Health_bar.fillAmount)  //....... This is the update of the Yellow Health Bar
        {
            yellow_bar_currentfill = Mathf.MoveTowards(Yellow_bar.fillAmount, Red_Health_bar.fillAmount,  Time.deltaTime/yellow_bar_delay);
            Yellow_bar.fillAmount = yellow_bar_currentfill;
        }
    }

    void SteamBarEffect()
    {
        if (Grey_Steam_bar.fillAmount > Blue_Steam_bar.fillAmount)
        {
            grey_bar_currentfill = Mathf.MoveTowards(Grey_Steam_bar.fillAmount , Blue_Steam_bar.fillAmount ,  Time.deltaTime/grey_bar_delay);
            Grey_Steam_bar.fillAmount = grey_bar_currentfill;
        }
    }

}