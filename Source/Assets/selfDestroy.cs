using Unity.VisualScripting;
using UnityEngine;

public class selfDestroy : MonoBehaviour
{
    public GameObject Player;

    void Update()
    {
        if (Player == null)
        {
            return;
        }
        // In case if player is too far from platform, the platform destroys itself
        else
        {
            float distanceY = Player.transform.position.y - transform.position.y;

            if (distanceY > 10)
            {
                Destroy(gameObject);
            }
        }
    }
}
