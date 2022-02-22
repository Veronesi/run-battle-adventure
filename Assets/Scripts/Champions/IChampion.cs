using UnityEngine;

public interface IChampion
{
    public int id { get; set; }
    public GameObject cardObject { get; set; }
    public GameObject championObject { get; set; }
    public Sprite spriteIamge { get; set; }
}
