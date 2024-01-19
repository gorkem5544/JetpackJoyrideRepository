using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts;
using UnityEngine;

public class LaserStartingState : IState
{
    LaserController _laserController;
    public LaserStartingState(LaserController laserController)
    {
        _laserController = laserController;
    }
    public void EnterState()
    {
        _laserController.Collider2D.enabled = false;
        _laserController.Center.gameObject.SetActive(false);
    }

    public void ExitState() { }

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
