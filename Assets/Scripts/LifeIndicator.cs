using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeIndicator : MonoBehaviour
{
    public Transform HPbar;
    public float maxLength;
    void Start()
    {
        maxLength = HPbar.localScale.x;
    }
    public void Update()
    {
        float maxLife = gameObject.GetComponentInParent<Champion>().maxLife;
        float life = gameObject.GetComponentInParent<Champion>().life;
        HPbar.localPosition = new Vector3((maxLength * (life / maxLife) - maxLength) / 2, HPbar.localPosition.y, HPbar.localPosition.z);
        HPbar.localScale = new Vector3(maxLength * (life / maxLife), HPbar.localScale.y, HPbar.localScale.z);
    }
}
