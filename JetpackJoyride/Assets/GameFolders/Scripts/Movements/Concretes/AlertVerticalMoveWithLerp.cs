using System;
using Unity.Mathematics;
using UnityEngine;

public class AlertVerticalMoveWithLerp : IAlertVerticalMove
{
    IAlertController _alertController;
    public Action OnStopEvent { get; set; }
    public bool CanStop { get; set; }
    public AlertVerticalMoveWithLerp(IAlertController alertController)
    {
        _alertController = alertController;
    }

    public void PlayMove()
    {
        _alertController.transform.position = new Vector3(_alertController.transform.position.x, Lerp());
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
        return math.lerp(_alertController.transform.position.y, PlayerManager.Instance.CurrentInstantiatePlayer.transform.position.y, 1f * Time.deltaTime);
    }
}