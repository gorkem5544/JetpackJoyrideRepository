using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AlertController : MonoBehaviour, IAlertController
{
    IAlertVerticalMove _alertVerticalMove;

    public IAlertVerticalMove AlertVerticalMove => _alertVerticalMove;

    IPlayerController _playerController;
    public IPlayerController PlayerController => _playerController;


    IAlertVerticalMoveService _alertVerticalMoveService;

    private void Awake()
    {
        _alertVerticalMoveService = new AlertVerticalMoveService(this);
        _alertVerticalMove = new AlertVerticalMoveWithLerp(_alertVerticalMoveService);
    }

    public void Installer(IPlayerController playerController)
    {
        _playerController = playerController;
    }
    private void FixedUpdate()
    {
        _alertVerticalMove.PlayMove();
    }



}
