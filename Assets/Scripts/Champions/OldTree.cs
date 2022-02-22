using UnityEngine;

public class OldTree : IChampion
{
    public int id { get; set; }
    public GameObject cardObject { get; set; }
    public GameObject championObject { get; set; }
    public Sprite spriteIamge { get; set; }
    public OldTree()
    {
        id = 3;
        cardObject = Resources.Load<GameObject>("Prefabs/Cards/CardOldTree");
        championObject = Resources.Load<GameObject>("Prefabs/Champions/OldTree");
        spriteIamge = Resources.Load<Sprite>("Sprites/Cards/OldTree");
    }
}