using UnityEngine;

public class OgreBlue : IChampion
{
    public int id { get; set; }
    public GameObject cardObject { get; set; }
    public GameObject championObject { get; set; }
    public Sprite spriteIamge { get; set; }
    public OgreBlue()
    {
        id = 1;
        cardObject = Resources.Load<GameObject>("Prefabs/Cards/CardOrangeBlue");
        championObject = Resources.Load<GameObject>("Prefabs/Champions/OgreBlue");
        spriteIamge = Resources.Load<Sprite>("Sprites/Cards/OgreBlue");
    }
}
