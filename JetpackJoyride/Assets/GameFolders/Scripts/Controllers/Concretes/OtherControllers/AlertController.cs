using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public interface IAlertController : IEntityController
{
    IAlertVerticalMove AlertVerticalMove { get; }
}
public class AlertController : MonoBehaviour, IAlertController
{
    IAlertVerticalMove _alertVerticalMove;

    public IAlertVerticalMove AlertVerticalMove => _alertVerticalMove;

    private void Awake()
    {
        _alertVerticalMove = new AlertVerticalMoveWithLerp(this);
    }

}
public interface IAlertStopMove
{
    void StopMove(); public Action OnStopEvent { get; set; }
    bool CanStop { get; }
}
public interface IAlertPlayMove
{
    void PlayMove();
}
public interface IAlertVerticalMove : IAlertPlayMove, IAlertStopMove
{

}
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