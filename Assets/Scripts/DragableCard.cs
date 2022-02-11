using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragableCard : MonoBehaviour
{
    private bool isDraggable = false;
    private bool isOnArea = false;
    public GameObject champion;
    private Vector3 initPosition;
    public int floorSpawn;
    private Transform cooldownSprite;
    private Champion championComponent;

    private void Start()
    {
        initPosition = transform.position;
        cooldownSprite = gameObject.transform.GetChild(0).GetComponent<Transform>();
        championComponent = champion.GetComponent<Champion>();
    }

    public void OnMouseDown()
    {
        isDraggable = true;
        GameManager.instance.AnimationChampionArea(true);
    }
    public void OnMouseUp()
    {
        isDraggable = false;
        GameManager.instance.AnimationChampionArea(false);
    }

    void Update()
    {
        float yScale = GameManager.instance.energy / championComponent.energy;
        if (yScale > 1f)
        {
                yScale = 1f;
        }
        cooldownSprite.localScale = new Vector3(cooldownSprite.localScale.x, 1f - yScale, cooldownSprite.localScale.z);
        
        if(isDraggable)
        {
            Vector2 newPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y));
            transform.position = Vector3.MoveTowards(transform.position,  new Vector3(newPos.x, newPos.y, transform.position.z), Time.deltaTime * 100);
            return;
        }

        if (isOnArea)
        {
            int energy = champion.GetComponent<Champion>().energy;
            if (energy > GameManager.instance.energy)
            {
                transform.position = initPosition;
                return;
            }
            float positionY = 0f;
            switch (floorSpawn)
            {
                case 1: positionY = 0f; break;
                case 2: positionY = 2.88f; break;
            }
            Vector3 spawnPosition = new Vector3(transform.position.x, positionY, transform.position.z);
            GameManager.instance.energy -= energy;
            Instantiate(champion, spawnPosition, Quaternion.identity);
            Destroy(gameObject);
            return;
        }
        if (transform.position != initPosition)
        {
            transform.position = initPosition;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isOnArea = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isOnArea = false;
    }
}
