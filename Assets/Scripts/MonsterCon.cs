using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.iOS;

public class MonsterCon : MonoBehaviour
{

    public enum State
    {
        IDlE,TRACE,ATTACK,DIE
    }

    public State state = State.IDlE;

    public float traceDistance = 10.0f;
    public float attackDistance = 2.0f;

    public bool isDie = false;

    private Transform mosterTr;
    private Transform playerTr;
    private NavMeshAgent agent;
    private Animator animater; 
    private StateMachine stateMachine;

   //
    private readonly int hashTrace = Animator.StringToHash("IsTrace");
    private readonly int hashAttack = Animator.StringToHash("IsAttack");

    // Start is called before the first frame update
    void Awake()
    {
        mosterTr = GetComponent<Transform>();   
        agent = GetComponent<NavMeshAgent>();
        animater = GetComponent<Animator>();
        playerTr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        stateMachine = gameObject.AddComponent<StateMachine>();
        stateMachine.AddState(State.IDlE, new IdleState(this));
        //StateMachine.AddState(State.TRACE, new IdleState(this));
        //StateMachine.AddState(State.ATTACK, new IdleState(this));

    }

    private void Start()
    {
        StartCoroutine(CheckMonState());
    }

    private IEnumerator CheckMonState()
    {
        while(!isDie)
        {
            yield return new WaitForSeconds(0.3f);

            if(state == State.DIE)
            {
                stateMachine.ChangeState(State.DIE);
                yield break;
            }

            float distance = Vector3.Distance(playerTr.position, mosterTr.position);

            if(distance <= attackDistance)
            {

            }
        }
    }
    void Update()
    {
        agent.destination = playerTr.position;
    }

    private class BaseMonsterState : BaseState
    {
        protected MonsterCon MonsterCon;
        public BaseMonsterState(MonsterCon MonsterCon)
        {
            this.MonsterCon = MonsterCon;
        }
    }
    private class IdleState : BaseMonsterState
    {
        public IdleState(MonsterCon MonsterCon) : base(MonsterCon) { }
        public override void Enter()
        {
            MonsterCon.agent.isStopped = true;
        }
    }



    
}
