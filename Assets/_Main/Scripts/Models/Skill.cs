using UnityEngine;

public abstract class Skill : ScriptableObject
{
    public string Name;
    public string Description;
    public Sprite Icon;
    public bool IsPassive;
    public int TurnCooldown;

    public abstract void Use();
}
