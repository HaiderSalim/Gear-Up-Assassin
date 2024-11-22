using UnityEngine;

[CreateAssetMenu(fileName = "Enemy data", menuName = "Enemy_info", order = 49)]
public class Enemies_Info : ScriptableObject
{
    public enum Enemy_type {Melee, Ranged, Mechs}
    public Enemy_type enemy_Type;
    [Range(50, 300)]
    public int Health;
    [Range(0f, 10f)]
    public float Speed;
    [Range(0f, 1f)]
    public float Acceleration_factor;
    [Range(38, 150)]
    public int Damage;
    [Range(0, 10f)]
    public float Attack_range;
    [Range(0, 5f)]
    public float Attack_cooldown;
}