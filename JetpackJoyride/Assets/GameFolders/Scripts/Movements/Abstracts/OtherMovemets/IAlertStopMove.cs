using System;

public interface IAlertStopMove
{
    void StopMove(); public Action OnStopEvent { get; set; }
    bool CanStop { get; }
}
