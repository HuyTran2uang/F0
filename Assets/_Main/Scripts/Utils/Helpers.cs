using System;
using System.Collections;
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
        yield return new WaitForSeconds(.5f);//anim idle -> attack
        int damage = (int)(attacker.Atk * skill.Power / 100f);
        yield return Helpers.StartCouroutine(target.TakeDamage(damage));
        yield return new WaitForSeconds(.5f);//anim attack -> idle
    }
}
