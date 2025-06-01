using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface IState
{
    void Enter();
    void Update();
    void Exit();
}

public enum ZombieStateType
{
    Idle,
    Patrol,
    Chase,
    Attack,
    Dead
}
public class NormalZombie : MonoBehaviour, IDamageable
{
    protected IdleState idle;
    protected PatrolState patrol;
    protected ChaseState chase;
    protected AttackState attack;
    protected DeadState dead;
    //protected AttackState attack = new AttackState(this);
    //여기서 바로 초기화로 this를 넘겨주는건 못 쓴다.
    //왜? -> 그 시점에서는 this가 완전히 생성되지 않았기 때문

    public Animator anim;
    public Rigidbody rigid;
    public Transform myBody;
    public ZombieData zombieData;

    bool isDead = false;

    [SerializeField] private IState currentState;
    [SerializeField] private IState nextState;
    [SerializeField] bool stateWorking = false;
    [SerializeField] ZombieStateType stateMessage;

    public Vector3 patrolDirection = Vector3.zero;

    public int currentHp;
    public int maxHp;

    private void Awake()
    {
        idle = new IdleState(this);
        patrol = new PatrolState(this);
        chase = new ChaseState(this);
        attack = new AttackState(this);
        dead = new DeadState(this);
        currentHp = zombieData.CurrentHp;
        maxHp = zombieData.MaxHp;
    }

    private void Update()
    {
        if (stateWorking)
        {
            currentState?.Update();
        }
    }
    private void LateUpdate()
    {
        if (currentHp <= 0 && !isDead)
        {
            isDead = true;
            stateWorking = false;
            stateMessage = ZombieStateType.Dead;
            ChangeState();
        }
        if (!stateWorking && !isDead)
        {
            ChangeState();
        }
    }
    private void ChangeState()
    {
        IState choice = idle;
        switch (stateMessage)
        {
            case ZombieStateType.Idle:
                choice = idle;
                break;
            case ZombieStateType.Patrol:
                choice = patrol;
                break;
            case ZombieStateType.Chase:
                choice = chase;
                break;
            case ZombieStateType.Attack:
                choice = attack;
                break;
            case ZombieStateType.Dead:
                choice = dead;
                break;
        }
        nextState = choice;

        currentState?.Exit();
        currentState = nextState;
        stateWorking = true;
        currentState?.Enter();
    }

    public void MessageToFsm(ZombieStateType message)
    {
        stateWorking = false; //idle상태 종료 안내
        stateMessage = message;
    }
    public void TakePhysicalDamage(float damageAmount)
    {
        if (currentHp <= 0 || isDead)
        {
            return;
        }
        else
        {
            currentHp = Mathf.Clamp(currentHp - (int)damageAmount, 0, maxHp);
        }
    }

    public void RemoveThisZombie()
    {
        Destroy(this.gameObject);
    }

}
