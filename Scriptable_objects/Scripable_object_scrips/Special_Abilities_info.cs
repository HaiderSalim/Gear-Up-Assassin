using UnityEngine;

[CreateAssetMenu(fileName = "Special_Abilities_data", menuName = "Special_Abilities_info", order = 52)]
public class Special_Abilities_info : ScriptableObject
{
    [Range(0f, 10f)]
    public float duration;
    [Range(0f, 2f)]
    public float fire_Rate;
    [Range(0, 100)]
    public float damage;
    public LayerMask Hit_effect_layer;
    [Range(5, 100), Tooltip("Sets the length of the raycast (This field does not effect Impersive punch)")]
    public float Range;
    public Material indecator_Material;
}
