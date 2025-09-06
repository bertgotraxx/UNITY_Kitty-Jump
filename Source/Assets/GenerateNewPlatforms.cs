using Unity.Mathematics;
using UnityEngine;

public class GenerateNewPlatforms : MonoBehaviour
{
    public GameObject basicPlatformPrefab, 
        unstablePlatformPrefab, 
        spikyPlatformPrefab, 
        movingPlatformPrefab,
        boostPlatformPrefab;

    public GameObject Player;
    public Camera gameCamera;
    private Vector2 screenBounds;
    private float heightLevel;
    //private bool onCooldown = false;
    
    void Start()
    {
        screenBounds = gameCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, gameCamera.transform.position.z));
        heightLevel = Player.transform.position.y + 4f;
        for (int i = 0; i < 2; i++)
        {
            Vector2 randomVector = new Vector2(
                UnityEngine.Random.Range(screenBounds.x * -1, screenBounds.x),
                UnityEngine.Random.Range((screenBounds.y - 4.8f) + (i * math.PI), (screenBounds.y - 4f) + (i * math.PI)));
            GameObject basicPlatform = Instantiate(basicPlatformPrefab, randomVector, transform.rotation);
            basicPlatform.GetComponent<selfDestroy>().enabled = true;
        }

        for (int i = 0; i < 2; i++)
        {
            Vector2 randomVector = new Vector2(
                UnityEngine.Random.Range(screenBounds.x * -1, screenBounds.x),
                UnityEngine.Random.Range((screenBounds.y + 0.8f) + (i * math.PI), (screenBounds.y + 1.8f) + (i * math.PI)));
            //Instantiate(basicPlatformPrefab, randomVector, transform.rotation);
            GameObject basicPlatform = Instantiate(basicPlatformPrefab, randomVector, transform.rotation);
            basicPlatform.GetComponent<selfDestroy>().enabled = true;
        }
    }


    void Update()
    {
        if (Player == null)
        {
            return;
        }
        else
        {
            screenBounds = gameCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, gameCamera.transform.position.z));
            //Debug.Log(screenBounds);
            if (Player.transform.position.y > heightLevel)
            {
                //Debug.Log("NEW PLATFORM CREATED");
                heightLevel = Player.transform.position.y + 5f;
                int randomChoice = UnityEngine.Random.Range(1, 20);
                for (float i = 0; i < 4; i++)
                {
                    Vector2 randomVector = new Vector2(
                    UnityEngine.Random.Range(screenBounds.x * -1, screenBounds.x),
                    UnityEngine.Random.Range((screenBounds.y + 1f) + (i * math.PI), (screenBounds.y + 2.5f) + (i * math.PI)));
                    //Instantiate(basicPlatformPrefab, randomVector, transform.rotation);
                    switch (i)
                    {
                        case 0:
                            GameObject basicPlatform = Instantiate(basicPlatformPrefab, randomVector, transform.rotation);
                            basicPlatform.GetComponent<selfDestroy>().enabled = true;
                            break;
                        case 1:
                            if (randomChoice >= 5 && randomChoice <= 8)
                            {
                                GameObject unstablePlatform = Instantiate(unstablePlatformPrefab, randomVector, transform.rotation);
                                unstablePlatform.GetComponent<selfDestroy>().enabled = true;
                            } 
                            else if (randomChoice >= 9 && randomChoice <= 12)
                            {
                                GameObject spikyPlatform = Instantiate(spikyPlatformPrefab, randomVector, transform.rotation);
                                spikyPlatform.GetComponent<selfDestroy>().enabled = true;
                            }
                            else if (randomChoice >= 13 && randomChoice <= 15)
                            {
                                GameObject movingPlatform = Instantiate(movingPlatformPrefab, new Vector3(0, randomVector.y, 0), transform.rotation);
                                movingPlatform.GetComponent<selfDestroy>().enabled = true;
                                movingPlatform.GetComponent<movingPlatformScript>().enabled = true;
                            }
                            else if (randomChoice >= 18 && randomChoice <= 20)
                            {
                                GameObject boostPlatform = Instantiate(boostPlatformPrefab, randomVector, transform.rotation);
                                boostPlatform.GetComponent<selfDestroy>().enabled = true;
                            }
                            else
                            {
                                basicPlatform = Instantiate(basicPlatformPrefab, randomVector, transform.rotation);
                                basicPlatform.GetComponent<selfDestroy>().enabled = true;
                            }
                            break;
                        case 2:
                            GameObject basicPlatform_1 = Instantiate(basicPlatformPrefab, randomVector, transform.rotation);
                            basicPlatform_1.GetComponent<selfDestroy>().enabled = true;
                            break;
                        case 3:
                            if (randomChoice >= 5 && randomChoice <= 8)
                            {
                                GameObject unstablePlatform = Instantiate(unstablePlatformPrefab, randomVector, transform.rotation);
                                unstablePlatform.GetComponent<selfDestroy>().enabled = true;
                            }
                            else
                            {
                                basicPlatform = Instantiate(basicPlatformPrefab, randomVector, transform.rotation);
                                basicPlatform.GetComponent<selfDestroy>().enabled = true;
                            }
                            break;
                    }
                }
            }
        }
    }
}
