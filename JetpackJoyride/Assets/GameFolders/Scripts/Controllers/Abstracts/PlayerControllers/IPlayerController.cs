using Assembly_CSharp.Assets.GameFolders.Scripts.Combats.Concretes.PlayerCombats;
using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.PlayerScriptableObjects;
using UnityEngine;

public interface IPlayerController : IEntityController
{
    Rigidbody2D Rigidbody2D { get; }
    InputReader InputReader { get; }
    PlayerSO PlayerSO { get; }
    IGoldManger GoldManger { get; }
    PlayerHealth PlayerHealth { get; }
}


