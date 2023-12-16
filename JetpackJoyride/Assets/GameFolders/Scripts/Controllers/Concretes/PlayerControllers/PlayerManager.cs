using UnityEngine;

class PlayerManager : SingletonDontDestroyMonoObject<PlayerManager>
{
    IPlayerController _playerController;


    protected override void Awake()
    {
        base.Awake();
        _playerController = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerController>();

    }
    private void OnEnable()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerController>();

    }
    private void OnValidate()
    {
        _playerController = GameObject.FindGameObjectWithTag("Player").transform.GetComponent<PlayerController>();

    }
    public IPlayerController GetPlayer()
    {
        return _playerController;
    }
}