using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Concretes;
using Concretes.Pools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LaserStateEnum
{
    Starting, Prepare, Launch
}
public class LaserController : BaseEnemyController
{
    LaserStateEnum _laserStateEnum = LaserStateEnum.Starting;

    [SerializeField] GameObject _top, _down, _center;
    [SerializeField] Transform _topTarget, _downTarget;

    float tirmer = 0;
    Collider2D _collider2D;

    IStateMachine _stateMachine;

    public GameObject Top { get => _top; set => _top = value; }
    public GameObject Down { get => _down; set => _down = value; }
    public GameObject Center { get => _center; set => _center = value; }
    public Transform TopTarget { get => _topTarget; set => _topTarget = value; }
    public Transform DownTarget { get => _downTarget; set => _downTarget = value; }
    public Collider2D Collider2D { get => _collider2D; set => _collider2D = value; }

    private void Awake()
    {
        _stateMachine = new StateMachine();
        Collider2D = GetComponent<Collider2D>();
    }
    private void OnEnable()
    {
        ChangeLaserState(_laserStateEnum = LaserStateEnum.Starting);
    }
    void Start()
    {


        LaserStartingState _laserStartingState = new LaserStartingState(this);
        LaserPrepareState _laserPrepareState = new LaserPrepareState(this);
        LaserActiveState _laserActiveState = new LaserActiveState(this);

        _stateMachine.SetState(_laserStartingState);
        _stateMachine.SetNormalStateTransitions(_laserStartingState, _laserPrepareState, () => _laserStateEnum == LaserStateEnum.Prepare);
        _stateMachine.SetNormalStateTransitions(_laserPrepareState, _laserActiveState, () => _laserStateEnum == LaserStateEnum.Launch);
        _stateMachine.SetNormalStateTransitions(_laserActiveState, _laserStartingState, () => _laserStateEnum == LaserStateEnum.Starting);
    }

    public override void Update()
    {
        base.Update();
        _stateMachine.UpdateTick();
    }

    public override void KillEnemyController()
    {
        LaserPool.Instance.Set(this);
    }
    public void ChangeLaserState(LaserStateEnum laserStateEnum)
    {
        _laserStateEnum = laserStateEnum;
    }
}
public class LaserStartingState : IState
{
    LaserController _laserController;
    public LaserStartingState(LaserController lazerController)
    {
        _laserController = lazerController;
    }
    public void EnterState()
    {
        _laserController.Collider2D.enabled = false;
        _laserController.Center.gameObject.SetActive(false);
    }

    public void ExitState()
    {

    }

    public void UpdateState()
    {
        MoveAction(_laserController.Top.transform, _laserController.TopTarget);
        MoveAction(_laserController.Down.transform, _laserController.DownTarget);
        if (CheckForDistance(_laserController.Top.transform, _laserController.TopTarget) && CheckForDistance(_laserController.Down.transform, _laserController.DownTarget))
        {
            _laserController.ChangeLaserState(LaserStateEnum.Prepare);
        }
    }
    public bool CheckForDistance(Transform thisTransform, Transform targetTransform, float distance = 0.5f)
    {
        return Vector2.Distance(thisTransform.position, targetTransform.position) < distance;
    }
    public void MoveAction(Transform thisTransform, Transform targetTransform, float maxDistanceDelta = 0.5f)
    {
        thisTransform.position = Vector3.MoveTowards(thisTransform.position, targetTransform.position, maxDistanceDelta);
    }


}
public class LaserPrepareState : IState
{
    LaserController _lazerController;
    private float _currentTime;
    public LaserPrepareState(LaserController lazerController)
    {
        _lazerController = lazerController;
    }
    public void EnterState()
    {
        resetTime();
    }

    public void ExitState()
    {
        resetTime();
    }

    public void UpdateState()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > 1.5f)
        {
            _lazerController.Center.gameObject.SetActive(true);
            _lazerController.ChangeLaserState(LaserStateEnum.Launch);
        }
    }
    private void resetTime()
    {
        _currentTime = 0;
    }

}
public class LaserActiveState : IState
{
    LaserController _lazerController;
    public LaserActiveState(LaserController lazerController)
    {
        _lazerController = lazerController;
    }
    public void EnterState()
    {
        _lazerController.Collider2D.enabled = true;
    }

    public void ExitState()
    {
        _lazerController.Center.gameObject.SetActive(false);

        _lazerController.Collider2D.enabled = false;
    }

    public void UpdateState()
    {
        if (!_lazerController.gameObject.activeSelf)
        {
            _lazerController.ChangeLaserState(LaserStateEnum.Starting);
        }
    }
}