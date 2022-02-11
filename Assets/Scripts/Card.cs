using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public ClassECard.ECard card;
    public void Construct(ClassECard.ECard typeCard)
    {
        card = typeCard;
        Debug.Log(card);
    }

}
