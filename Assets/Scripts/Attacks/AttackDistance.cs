using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDistance : MonoBehaviour, IAttack
{
    public GameObject attackAnimation { get; set; }
    public float attack { get; set; }
    public float speed { get; set; }
    public bool isAttacking { get; set; }
    public bool canAttack { get; set; }
    public GameObject enemy { get; set; }
    public GameObject projectile { get; set; }

    public float _attack;
    public float _speed;
    public GameObject _projectile;

    public void Start()
    {
        isAttacking = false;
        canAttack = true;
        attack = _attack;
        speed = _speed;
        projectile = _projectile;
    }
    public void AttackChampion(GameObject newEnemy, HitBox hitBox)
    {
        if (!canAttack)
        {
            return;
        }
        isAttacking = true;
        enemy = newEnemy;
        InvokeRepeating("LoopAttack", 0f, speed);
    }

    public void LoopAttack()
    {
        if (!enemy)
        {
            CancelAttacking();
            return;
        }

        GameObject newProjectile = Instantiate(projectile, gameObject.transform.position, Quaternion.identity);
        newProjectile.GetComponent<Projectile>().damadge = attack;
        newProjectile.GetComponent<Projectile>().SetDestination(enemy.transform.position);
    }

    public void CancelAttacking()
    {
        isAttacking = false;
        canAttack = true;
        CancelInvoke();
        gameObject.GetComponent<ChampionMovement>().Walk();
    }
}
