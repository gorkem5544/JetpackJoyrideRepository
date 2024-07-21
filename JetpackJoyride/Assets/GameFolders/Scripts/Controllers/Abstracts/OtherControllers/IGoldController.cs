using Assembly_CSharp.Assets.GameFolders.Scripts.ScriptableObjects.Concretes.OtherScriptableObjects.GoldScriptableObjects;
using UnityEngine;

public interface IGoldController : IEntityController
{
    Rigidbody2D Rigidbody2D { get; }
    GoldDetailScriptableObject GoldDetailScriptableObject { get; }
}

