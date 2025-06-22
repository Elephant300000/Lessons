using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using State.EnemyState;

public class MainUpdate : MonoBehaviour
{
    private Dictionary<EnemyBase, EnemyStateHandler> _enemyStateHans = new();
    private Dictionary<EnemyBase, EnemyInitBexaviors> _initBexaviors = new();
    private Dictionary<EnemyBase, IBehaviourHandler> _behaveourhandler = new();
    private List<EnemyBase> _enemyBases = new();

    private void Awake()
    {
        _enemyBases.AddRange(FindObjectsOfType<EnemyBase>());
    }
    private void OnEnable()
    {

    }

    private void Start()
    {
        foreach (EnemyBase e in _enemyBases)
        {
            StartInitDictionory(e);

        }
    }

    private void StartInitDictionory(EnemyBase e)
    {
        var enemyBehInit = new EnemyInitBexaviors();
        var enemyState = new EnemyStateHandler();
        var enemyBehaviourHandler = new BehaviourHandler();
        InitBexaviours(e, enemyBehInit, enemyBehaviourHandler);
        InitStates(enemyState, enemyBehaviourHandler, e);
        enemyState.SetState(EnemyStateType.Idel);
        _enemyStateHans[e] = enemyState;
        _behaveourhandler[e] = enemyBehaviourHandler;
        _initBexaviors[e] = enemyBehInit;
    }

    void Update()
    {
        foreach (EnemyStateHandler eSH in _enemyStateHans.Values)
            eSH?.UpdateState();
    }
    private void LateUpdate()
    {
        foreach (EnemyStateHandler eSH in _enemyStateHans.Values)
            eSH?.LateUpdateState();        
    }
    private void FixedUpdate()
    {
        foreach (EnemyStateHandler eSH in _enemyStateHans.Values)
            eSH?.FixedUpdateState();
    }
   

    private void InitBexaviours(EnemyBase e, EnemyInitBexaviors bex,IBehaviourHandler behaviourHandler)
    {
        if (bex != null)
        {
            bex.InitIdleBehaviour(new EnemyIdel(e, behaviourHandler));
            bex.InitRandomMove(new EnemyRandomMove(e, behaviourHandler));
            bex.InitRandomRotate(new EnemyRandomRotate(e, behaviourHandler));
            bex.InitFollowTarget(new EnemyFollowPlayer(e, behaviourHandler));
            bex.InitLoockTarget(new EnemyLookRotate(e, behaviourHandler));
        }
    }
    public void InitStates(IStateHandler _stateHandler,
        IBehaviourHandler behaviourHandler,
        EnemyBase enemy)
    {
        _stateHandler.RegistorStates(EnemyStateType.Idel, new EnemyIdleState(_stateHandler, behaviourHandler, enemy));
       // _stateHandler.RegistorStates(EnemyStateType.Move, new EnemyMoveState(_stateHandler, behaviourHandler, enemy));
       // _stateHandler.RegistorStates(EnemyStateType.Follow, new EnemyFollowStates(_stateHandler, behaviourHandler, enemy));

    }
}
