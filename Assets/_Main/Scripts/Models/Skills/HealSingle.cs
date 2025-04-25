using UnityEngine;

[CreateAssetMenu(fileName = "HealSingle", menuName = "Skills/Buff/HealSingle")]
public class HealSingle : Skill
{
    public int Power;

    public override void Select()
    {
        Battle.Instance.attacker.ChangeSkill(this);
        Battle.Instance.targetCount = 1;
        Battle.Instance.SelectOwnedTeam();
        Battle.Instance.isSelectOwnedTeam = true;
    }

    public override void Unselect()
    {
        Battle.Instance.targetSelected = null;
        Battle.Instance.targetCount = 0;
    }

    public override void Use()
    {
        Helpers.StartCouroutine(
            Helpers.OnHealSingle(
                attacker: Battle.Instance.attacker,
                target: Battle.Instance.targetSelected,
                skill: this
            )
        );
    }
}
