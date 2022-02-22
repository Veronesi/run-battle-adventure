using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public TYPE_ATTACK typeAttack = TYPE_ATTACK.MELE;
    public enum TYPE_ATTACK {
        MELE,
        DISTANCE,
        MELE_AREA
    }

    public void AttackChampion(GameObject newEnemy, HitBox _hitBox)
    {
        switch (typeAttack)
        {
            case TYPE_ATTACK.MELE:
                gameObject.GetComponent<AttackMele>().AttackChampion(newEnemy, _hitBox);
                break;
            case TYPE_ATTACK.DISTANCE:
                gameObject.GetComponent<AttackDistance>().AttackChampion(newEnemy, _hitBox);
                break;
            case TYPE_ATTACK.MELE_AREA:
                gameObject.GetComponent<AttackMeleArea>().AttackChampion(newEnemy, _hitBox);
                break;
        }

    }

}
