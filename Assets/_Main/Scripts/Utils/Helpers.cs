using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
    public static Coroutine StartCouroutine(IEnumerator callback)
    {
        GameObject go = new GameObject();
        var a = go.AddComponent<MonoBehaviour>();
        return a.StartCoroutine(callback);
    }

    public static IEnumerator DeplayCall_Couroutine(float duration, Action callback)
    {
        yield return new WaitForSeconds(duration);
        callback?.Invoke();
    }

    public static IEnumerator OnAttackSingle(Unit attacker, Unit target, NormalSingleAttack skill)
    {
        attacker.transform.DOMove(target.transform.position, .5f);
        yield return new WaitForSeconds(.5f);//anim idle -> attack
        int damage = (int)(attacker.Atk * skill.Power / 100f);
        yield return Helpers.StartCouroutine(target.TakeDamage(damage));
        yield return new WaitForSeconds(.5f);//anim attack -> idle
    }

    public static IEnumerator OnAttackAll(Unit attacker, List<Unit> targets, AttackAll skill)
    {
        yield return new WaitForSeconds(.5f);//anim idle -> attack
        int damage = (int)(attacker.Atk * skill.Power / 100f);
        for (int i = 0; i < targets.Count; i++)
        {
            Helpers.StartCouroutine(targets[i].TakeDamage(damage));
        }
        yield return new WaitForSeconds(.5f);//anim attack -> idle
    }

    public static IEnumerator OnHealSingle(Unit attacker, Unit target, HealSingle skill)
    {
        attacker.transform.DOMove(target.transform.position, .5f);
        yield return new WaitForSeconds(.5f);//anim
        int hp = (int)(attacker.Atk * skill.Power / 100f);
        yield return Helpers.StartCouroutine(target.Healing(hp));
        yield return new WaitForSeconds(.5f);//anim
    }
}
