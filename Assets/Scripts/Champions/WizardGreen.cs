using UnityEngine;

public class WizardGreen : IChampion
{
    public int id { get; set; }
    public GameObject cardObject { get; set; }
    public GameObject championObject { get; set; }
    public Sprite spriteIamge { get; set; }

    public WizardGreen()
    {
        id = 2;
        cardObject = Resources.Load<GameObject>("Prefabs/Cards/CardWizardGreen");
        championObject = Resources.Load<GameObject>("Prefabs/Champions/WizardGreen");
        spriteIamge = Resources.Load<Sprite>("Sprites/Cards/WizardGreen");
    }
}