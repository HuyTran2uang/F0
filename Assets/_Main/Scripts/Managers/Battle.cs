using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Battle : Singleton<Battle>
{
    public Unit attacker;
    public Unit targetSelected;
    public Unit[] targets;

    public int targetCount;

    public Unit[] ownedTeam;
    public Unit[] enemyTeam;

    public List<Unit> units;

    public SkillView skillView;

    public void SelectAllEnemy()
    {
        targets = enemyTeam;
        foreach (var target in targets)
        {
            target.Targeted();
        }
    }

    public void SelectTargetEnemy()
    {
        var lifeUnits = enemyTeam.Where(i => i.IsAlive).ToList();
        targetSelected = lifeUnits[lifeUnits.Count / 2];
        targetSelected.Targeted();
    }

    private void Start()
    {
        StartBattle();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out var hit))
            {
                var unit = hit.collider.GetComponent<Unit>();
                if(enemyTeam.Contains(unit))
                {
                    targetSelected.UnTargeted();
                    targetSelected = unit;
                    targetSelected.Targeted();
                }
            }
        }
    }

    public void StartBattle()
    {
        units.AddRange(ownedTeam);
        units.AddRange(enemyTeam);

        //get highest speed unit
        var unit = units.Where(i => i.IsAlive).OrderByDescending(i => i.Speed).FirstOrDefault();

        attacker = unit;
        attacker.OnTurn();
    }
}
