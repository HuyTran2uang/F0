using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

    public IEnumerator Healing(int heal)
    {
        CurrentHP += heal;
        transform.DOShakePosition(0.2f);
        yield return new WaitForSeconds(.5f);//anim heal
    }

    public void OnTurn()
    {
        selected.SetActive(true);
        Battle.Instance.skillView.Init(Skills);
        currentSkill = Skills[0];
        currentSkill.Select();
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

    public void ChangeSkill(Skill skill)
    {
        Battle.Instance.targetSelected?.UnTargeted();
        Battle.Instance.targets.ToList().ForEach(i => i.UnTargeted());
        currentSkill.Unselect();
        currentSkill = skill;
    }
}
