public interface IAlertController : IEntityController
{
    IAlertVerticalMove AlertVerticalMove { get; }
    IPlayerController PlayerController { get; }
}
