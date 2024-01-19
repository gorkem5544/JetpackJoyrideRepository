using UnityEngine;
using UnityEngine.UI;

public abstract class BaseButton : MonoBehaviour
{
    [SerializeField] protected Button _button;
    protected virtual void OnEnable()
    {
        _button.onClick.AddListener(ButtonOnClick);
    }
    private void OnDisable()
    {
        _button.onClick.RemoveListener(ButtonOnClick);
    }
    protected abstract void ButtonOnClick();
}
