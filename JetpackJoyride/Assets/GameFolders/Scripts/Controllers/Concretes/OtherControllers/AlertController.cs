using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class AlertController : MonoBehaviour, IAlertController
{
    IAlertVerticalMove _alertVerticalMove;

    public IAlertVerticalMove AlertVerticalMove => _alertVerticalMove;

    private void Awake()
    {
        _alertVerticalMove = new AlertVerticalMoveWithLerp(this);
    }

}
