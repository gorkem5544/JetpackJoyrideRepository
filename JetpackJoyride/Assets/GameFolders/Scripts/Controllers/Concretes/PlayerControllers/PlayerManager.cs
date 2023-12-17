using UnityEngine;

class PlayerManager : SingletonDontDestroyMonoObject<PlayerManager>
{
    private PlayerController _playerController;
    public PlayerController PlayerController { get; set; }

    [SerializeField] PlayerDetailListSO _playerDetailListSO;
    public void SelectionPlayer(PlayerDetailSO playerDetailSO, PlayerTypeEnum playerTypeEnum = PlayerTypeEnum.White)
    {
        _playerController = playerDetailSO.playerController;
    }

    public void InstantiatePlayer()
    {
        if (_playerController == null)
        {
            _playerController = _playerDetailListSO.playerDetailSOs[0].playerController;
        }
        PlayerController = Instantiate(_playerController, Vector2.one, Quaternion.identity);

    }
}

