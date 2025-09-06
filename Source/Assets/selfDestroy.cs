using Unity.VisualScripting;
using UnityEngine;

public class selfDestroy : MonoBehaviour
{
    public GameObject Player;

    void Start()
    {
        
    }

    void Update()
    {
        if (Player == null)
        {
            return;
        }
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
