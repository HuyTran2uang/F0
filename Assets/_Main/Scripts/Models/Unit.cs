using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{
    //info
    public string Name;
    public int Element; //1=Fire,2=Water,3=Wild,4=Dard,5=Light
    //level
    public int Awaken;//0->2
    public int Stars;//1->6
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
    public int CurrentHP;
    public int SpeedBar;
    public bool IsAlive => CurrentHP > 0;

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
        yield return new WaitForSeconds(.5f);//anim hurt
        if(CurrentHP < 0)
        {
            gameObject.SetActive(false);
        }
    }
}
