using Assembly_CSharp.Assets.GameFolders.Scripts.StateMachines.Abstracts;

public class LaserActiveState : IState
{
    LaserController _laserController;
    public LaserActiveState(LaserController laserController)
    {
        _laserController = laserController;
    }
    public void EnterState()
    {
        _laserController.Collider2D.enabled = true;
    }

    public void ExitState()
    {
        _laserController.Center.gameObject.SetActive(false);
        _laserController.Collider2D.enabled = false;
    }

    public void UpdateState()
    {
        if (!_laserController.gameObject.activeSelf)
        {
            _laserController.ChangeLaserState(LaserStateEnum.Starting);
        }
    }
}