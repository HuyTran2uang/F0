using System.Collections.Generic;
using UnityEngine;

public class SkillView : MonoBehaviour
{
    [SerializeField] private SkillItemView _skillItemViewPrefab;
    [SerializeField] private Transform _container;

    private List<SkillItemView> _items = new List<SkillItemView>();

    public void Init(Skill[] skills)
    {
        for (int i = _items.Count; i < skills.Length; i++)
        {
            var item = Instantiate(_skillItemViewPrefab, _container);
            _items.Add(item);
        }

        for (int i = 0; i < _items.Count; i++)
        {
            _items[i].Init(skills[i].Icon, skills[i].Select, skills[i].IsPassive);
            _items[i].Show();
        }
    }

    public void Hide()
    {
        _items.ForEach(i => i.Hide());
    }
}
