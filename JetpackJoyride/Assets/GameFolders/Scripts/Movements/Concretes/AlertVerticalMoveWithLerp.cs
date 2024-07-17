using System;
using Unity.Mathematics;
using UnityEngine;

public class AlertVerticalMoveWithLerp : IAlertVerticalMove
{
    IAlertVerticalMoveService _alertVerticalMoveService;
    public Action OnStopEvent { get; set; }
    public bool CanStop { get; set; }
    public AlertVerticalMoveWithLerp(IAlertVerticalMoveService alertVerticalMoveService)
    {
        _alertVerticalMoveService = alertVerticalMoveService;
    }

    public void PlayMove()
    {
        _alertVerticalMoveService.AlertController.transform.position = new Vector3(_alertVerticalMoveService.AlertController.transform.position.x, Lerp());
        CanStop = false;
    }

    public void StopMove()
    {
        OnStopEvent?.Invoke();
        CanStop = true;
        return;
    }
    private float Lerp()
    {
        return math.lerp(_alertVerticalMoveService.AlertController.transform.position.y, _alertVerticalMoveService.PlayerController.transform.position.y, 1f * Time.deltaTime);
    }
}

public class AlertVerticalMoveService : IAlertVerticalMoveService
{
    IAlertController _alertController;
    IPlayerController _playerController;


    public AlertVerticalMoveService(IAlertController alertController)
    {
        _alertController = alertController;
        _playerController = alertController.PlayerController;
    }

    public IAlertController AlertController { get => _alertController; set => _alertController = value; }
    public IPlayerController PlayerController { get => _playerController; set => _playerController = value; }
}

public interface IAlertVerticalMoveService
{
    IAlertController AlertController { get; }
    IPlayerController PlayerController { get; }
}