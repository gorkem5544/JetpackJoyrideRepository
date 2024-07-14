using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts;
using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Concretes;
using Concretes.Pools;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class LaserController : BaseEnemyController, ILaserController
{
    LaserStateEnum _laserStateEnum = LaserStateEnum.Starting;

    [SerializeField] GameObject _top, _down, _center;
    [SerializeField] Transform _topTarget, _downTarget;
    Collider2D _collider2D;
    private Transform _topObjectStartingTransform, _downObjectStartingTransform;

    StateMachine _stateMachine;

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
        _topObjectStartingTransform.position = _top.transform.position;
        _downObjectStartingTransform.position = _down.transform.position;
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
        _stateMachine.Update();
    }

    public override void KillEnemyController()
    {
        LaserPool.Instance.Set(this);
    }
    public void ChangeLaserState(LaserStateEnum laserStateEnum)
    {
        _laserStateEnum = laserStateEnum;
    }
    public void ResetTopAndDownObjectPosition()
    {
        _top.transform.position = _topObjectStartingTransform.transform.position;
        _down.transform.position = _downObjectStartingTransform.transform.position;
    }
}
