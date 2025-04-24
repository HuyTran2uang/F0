using UnityEngine;

[CreateAssetMenu(fileName = "Normal Single Attack", menuName = "Skills/Attack/Normal Single Attack")]
public class NormalSingleAttack : Skill
{
    public int Power;

    public override void Select()
    {
        Battle.Instance.targetCount = 1;
        Battle.Instance.SelectTargetEnemy();
    }

    public override void Unselect()
    {
        Battle.Instance.targetCount = 0;
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
