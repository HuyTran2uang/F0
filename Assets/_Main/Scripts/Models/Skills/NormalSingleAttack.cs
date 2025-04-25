using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "Normal Single Attack", menuName = "Skills/Attack/Normal Single Attack")]
public class NormalSingleAttack : Skill
{
    public int Power;

    public override void Select()
    {
        Battle.Instance.attacker.ChangeSkill(this);
        Battle.Instance.targetCount = 1;
        Battle.Instance.isSelectOwnedTeam = false;
        Battle.Instance.SelectTargetEnemy();
    }

    public override void Unselect()
    {
        Battle.Instance.targetCount = 0;
        Battle.Instance.targetSelected = null;
    }

    public override void Use()
    {
        Helpers.StartCouroutine(
            Helpers.OnAttackSingle(
                attacker: Battle.Instance.attacker, 
                target: Battle.Instance.targetSelected, 
                skill: this
            )
        );
    }
}
