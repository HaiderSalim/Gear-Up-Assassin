using UnityEngine;

public class Enemy_Mechanic : MonoBehaviour
{
    [Header("Enemies Fields"), SerializeField]
    private Enemies_Info _Info;

    //Headers
    private Handler_Referencer handler_Referencer;//Holds the reference to all the handlers that the game has
    private First_Person_Handler first_Person_Handler;
    private Camera_effect_Handler camera_Effect_Handler;

    private Transform Player_transform;
    private Vector3 Directional_vector => Player_transform.position - transform.position;//Getting the destance between the player and enemy
    private Rigidbody RB;
    private float Speed_temp = 0;
    private float Attack_delay;

    void Start()
    {
        handler_Referencer = GameObject.FindGameObjectWithTag("Game Handler").GetComponent<Handler_Referencer>();
        first_Person_Handler = handler_Referencer.first_Person_Handler;
        camera_Effect_Handler = handler_Referencer.camera_Effect_Handler;
        Player_transform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        RB = GetComponent<Rigidbody>();

        Attack_delay = _Info.Attack_cooldown;
    }

    void Update()
    {
        Enemy_Behavior();
    }

    void Enemy_Behavior()
    {
        if (_Info.enemy_Type == Enemies_Info.Enemy_type.Melee)
        {
            Movement();
            Attack();
        }
        else if (_Info.enemy_Type == Enemies_Info.Enemy_type.Ranged)
        {
            Movement();
            Attack();
        }
        else if (_Info.enemy_Type == Enemies_Info.Enemy_type.Mechs)
        {
            Movement();
            Attack();
        }
    }

    void Movement()
    {
        if (Directional_vector.magnitude > _Info.Attack_range)
        {
            if (_Info.Speed > Speed_temp)
                Speed_temp += Mathf.Clamp(_Info.Speed * _Info.Acceleration_factor, 0f, _Info.Speed);
            
            if (RB.velocity.magnitude < _Info.Speed)//Make sure that the force is only applyed when needed
                RB.AddForce(Directional_vector.normalized * Speed_temp, ForceMode.VelocityChange);
        }
        else
        {
            Speed_temp = 0f;
            RB.velocity = Vector3.zero;
        }
        //Debug.Log(RB.velocity.magnitude);
    }

    void Attack()
    {
        if (Attack_delay <= 0f)
        {
            if (Directional_vector.magnitude <= _Info.Attack_range)
            {
                camera_Effect_Handler.Trigger_Damaged_Camera_effect();
                Attack_delay = _Info.Attack_cooldown;
                Debug.Log("Attack");
            }
        }
        else
        {
            Attack_delay -= Time.deltaTime;
        }
    }
}
