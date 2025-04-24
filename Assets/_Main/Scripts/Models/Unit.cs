using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    //info
    public string Name;
    //level
    public int Level;
    public int Exp;
    public int MaxExp;
    //stats
    public int HP;
    public int Atk;
    public int Def;
    public int CritRate;
    public int CritDamage;
    public int Speed;
    public int Resistance;
    public int Accuracy;
    //other
    //TODO: skills
    public Skill[] Skills;
    //TODO: runes

    //status battle
    public Skill currentSkill;
    public int CurrentHP;
    public int SpeedBar;
    public bool IsAlive => CurrentHP > 0;

    public GameObject selected;
    public GameObject targeted;

    //attack
    public void AttackSingleTarget(Unit target)
    {
        int damage = Atk;
        target.TakeDamage(damage);
    }

    public void AttackListTargets(List<Unit> targets)
    {
        int damage = Atk;
        targets.ForEach(target => target.TakeDamage(damage));
    }

    public IEnumerator TakeDamage(int damage)
    {
        CurrentHP -= damage;
        transform.DOShakePosition(0.2f);
        yield return new WaitForSeconds(.5f);//anim hurt
        if(CurrentHP < 0)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnTurn()
    {
        selected.SetActive(true);
        Skills[0].Select();
        Battle.Instance.skillView.Init(Skills);
    }

    public void EndTurn()
    {
        selected.SetActive(false);
    }

    public void Targeted()
    {
        targeted.SetActive(true);
    }

    public void UnTargeted()
    {
        targeted.SetActive(false);
    }
}
