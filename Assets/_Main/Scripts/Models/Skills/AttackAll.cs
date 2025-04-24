using UnityEngine;

[CreateAssetMenu(fileName = "Normal Single Attack", menuName = "Skills/Attack/Normal Single Attack")]
public class AttackAll : Skill
{
    public int Power;

    public override void Select()
    {
        Battle.Instance.SelectAllEnemy();
    }

    public override void Unselect()
    {
        Battle.Instance.targets = null;
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
