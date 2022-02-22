using UnityEngine;

public interface IAttack
{
    // HitBox hitBox { get; }
    public GameObject attackAnimation { get; set; }
    float attack { get; set; }
    float speed { get; set; }
    bool isAttacking { get; set; }
    bool canAttack { get; set; }
    void AttackChampion(GameObject newEnemy, HitBox _hitBox);
    void CancelAttacking();
}
