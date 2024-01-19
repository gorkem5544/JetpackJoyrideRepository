using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts;
using UnityEngine;

public class LaserPrepareState : IState
{
    LaserController _laserController;
    private float _currentTime;
    public LaserPrepareState(LaserController laserController)
    {
        _laserController = laserController;
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
            _laserController.Center.gameObject.SetActive(true);
            _laserController.ChangeLaserState(LaserStateEnum.Launch);
        }
    }
    private void resetTime()
    {
        _currentTime = 0;
    }
}
