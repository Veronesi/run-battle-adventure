using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public float attack = 2f;
    public float speed = 1f;
    public bool isAttacking = false;
    public bool canAttack = true;
    public GameObject enemy;
    public TYPE_ATTACK typeAttack = TYPE_ATTACK.MELE;
    public GameObject projectile;
    public GameObject attackAnimation;
    private HitBox hitBox;

    public enum TYPE_ATTACK {
        MELE,
        DISTANCE,
        MELE_AREA
    }

    public void AttackChampion(GameObject newEnemy, HitBox _hitBox)
    {
        if (canAttack)
        {
            hitBox = _hitBox;
            switch (typeAttack)
            {
                case TYPE_ATTACK.MELE:
                    canAttack = false;
                    isAttacking = true;
                    enemy = newEnemy;
                    InvokeRepeating("LoopAttackMele", 0f, speed);
                    break;
                case TYPE_ATTACK.DISTANCE:
                    isAttacking = true;
                    enemy = newEnemy;
                    InvokeRepeating("LoopAttackDistance", 0f, speed);
                    break;
                case TYPE_ATTACK.MELE_AREA:
                    isAttacking = true;
                    InvokeRepeating("LoopAttackArea", 0f, speed);
                    break;
            }
        }
    }
    public void LoopAttackArea()
    {
        if(hitBox.enemies.Count == 0)
        {
            CancelAttacking();
            return;
        }

        int countEnnemiesLives = 0;
        PlayAnimation();
        foreach (GameObject targerToAttack in hitBox.enemies)
        {
            if (!targerToAttack.CompareTag(gameObject.tag))
            {
                bool isAlive = targerToAttack.GetComponent<Champion>().Hurt(attack);
                if (isAlive)
                    countEnnemiesLives++;
            }
        }

        if(countEnnemiesLives == 0)
        {
            CancelAttacking();
            return;
        }
    }
    public void LoopAttackMele()
    {
        if(!enemy)
        {
            CancelAttacking();
            return;
        }

        PlayAnimation();
        bool isAlive = enemy.GetComponent<Champion>().Hurt(attack);
        if(!isAlive)
            CancelAttacking();
    }
    public void LoopAttackDistance()
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
    private void CancelAttacking()
    {
        isAttacking = false;
        canAttack = true;
        CancelInvoke();
        gameObject.GetComponent<ChampionMovement>().Walk();
    }

    private void PlayAnimation()
    {
        GameObject attackAnimmationInstanciate = Instantiate(attackAnimation, transform);
        if (gameObject.tag == "Enemy")
        {
            attackAnimmationInstanciate.GetComponent<SpriteRenderer>().flipX = true;
            attackAnimmationInstanciate.transform.localPosition = attackAnimmationInstanciate.transform.localPosition + Vector3.left * attackAnimmationInstanciate.transform.localPosition.x * 2;
        }
        Destroy(attackAnimmationInstanciate, 0.5f);
    }
}
