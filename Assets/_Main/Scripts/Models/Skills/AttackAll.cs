using System.Linq;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "Attack All", menuName = "Skills/Attack/Attack All")]
public class AttackAll : Skill
{
    public int Power;

    public override void Select()
    {
        Battle.Instance.attacker.ChangeSkill(this);
        Battle.Instance.isSelectOwnedTeam = true;
        Battle.Instance.SelectAllEnemy();
    }

    public override void Unselect()
    {
        Battle.Instance.targets = new List<Unit>();
    }

    public override void Use()
    {
        Helpers.StartCouroutine(
            Helpers.OnAttackAll(
                attacker: Battle.Instance.attacker,
                targets: Battle.Instance.targets,
                skill: this
            )
        );
    }
}
