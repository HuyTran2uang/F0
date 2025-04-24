using System;
using UnityEngine;
using UnityEngine.UI;

public class SkillItemView : MonoBehaviour
{
    [SerializeField] private Button _selectButton;
    [SerializeField] private Image _icon;

    public Action OnSelectButtonClicked;

    private void Awake()
    {
        _selectButton.onClick.AddListener(OnClicked);
    }

    public void Init(Sprite icon, Action onClicked, bool isPassive)
    {
        _icon.sprite = icon;
        OnSelectButtonClicked = onClicked;
        _selectButton.interactable = !isPassive;
    }

    private void OnClicked()
    {
        OnSelectButtonClicked?.Invoke();
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}
