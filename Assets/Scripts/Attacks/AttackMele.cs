using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMele : MonoBehaviour, IAttack
{
    public GameObject attackAnimation { get; set; }
    public float attack { get; set; }
    public float speed { get; set; }
    public bool isAttacking { get; set; }
    public bool canAttack { get; set; }
    public GameObject enemy { get; set; }
    public GameObject _attackAnimation;

    public void Start()
    {
        isAttacking = false;
        canAttack = true;
        attack = gameObject.AddComponent<Champion>().attack;
        speed = gameObject.AddComponent<Champion>().attackSpeed;
        attackAnimation = _attackAnimation;
    }
    public void AttackChampion(GameObject newEnemy, HitBox hitBox)
    {
        if (!canAttack)
        {
            return;
        }
        canAttack = false;
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

        PlayAnimation();
        bool isAlive = enemy.GetComponent<Champion>().Hurt(attack);
        if (!isAlive)
            CancelAttacking();
    }

    public void CancelAttacking()
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
