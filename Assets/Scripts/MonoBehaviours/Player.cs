using UnityEngine;

public class Player : Character
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CanBePickedUp"))
        {
            Item hitObject = collision.gameObject.
            GetComponent<Consumable>().item;
            if (hitObject != null)
            {
                print("Hit: " + hitObject.objectName);
                // 1
                switch (hitObject.itemType)
                {
                    // 2
                    case Item.ItemType.COIN:
                        break;
                    // 3
                    case Item.ItemType.HEALTH:
                        AdjustHitPoints(hitObject.quantity);
                        break;
                    default:
                        break;
                }
                collision.gameObject.SetActive(false);
            }
        }
    }

    // 4
    public void AdjustHitPoints(int amount)
    {
        // 5
        hitPoints = hitPoints + amount;
        print("Adjusted hitpoints by: " + amount + ". New value: " + hitPoints);
    }
}