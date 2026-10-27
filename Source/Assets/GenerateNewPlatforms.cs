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
    
    void Start()
    {
        // Variable that contains device's screen dimensions in order to prevent
        // platforms from spawning outside of game's screen
        screenBounds = gameCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, gameCamera.transform.position.z));

        // Variable that contains current player's Y coordinate and adds 4 to it
        // in order to spawn new platforms that will be slightly higher
        heightLevel = Player.transform.position.y + 4f;

        // "Randomizers" that spawn 2 random platforms abit ahead of player on game start
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
            GameObject basicPlatform = Instantiate(basicPlatformPrefab, randomVector, transform.rotation);
            basicPlatform.GetComponent<selfDestroy>().enabled = true;
        }
    }


    void Update()
    {
        // Do nothing in case if player is dead or don't exist
        if (Player == null)
        {
            return;
        }
        else
        {
            // Variable that contains screen bounds. Here it gets new value each update in order to get new Game Camera's Z coordinate
            screenBounds = gameCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, gameCamera.transform.position.z));

            // If Player's Y coordinate is bigger than value in "heightLevel" variable then
            // choose a random number that will determine platform's type (Regular, Unstable, Spiky, Moving, Boost)
            if (Player.transform.position.y > heightLevel)
            {
                heightLevel = Player.transform.position.y + 5f;
                int randomChoice = UnityEngine.Random.Range(1, 20);
                for (float i = 0; i < 4; i++)
                {
                    // Randomly choose new X and Y coordinates for new platform
                    Vector2 randomVector = new Vector2(
                    UnityEngine.Random.Range(screenBounds.x * -1, screenBounds.x),
                    UnityEngine.Random.Range((screenBounds.y + 1f) + (i * math.PI), (screenBounds.y + 2.5f) + (i * math.PI)));

                    // Switch construction that determines the type of platform basing on
                    // platform's number and value in "randomChoice"
                    switch (i)
                    {
                        // Platform no. 1 - it's always a basic platform
                        case 0:
                            GameObject basicPlatform = Instantiate(basicPlatformPrefab, randomVector, transform.rotation);
                            basicPlatform.GetComponent<selfDestroy>().enabled = true;
                            break;

                        // Platform no. 2 - randomly chosen between basic, unstable, spiky, moving and boost platforms
                        case 1:
                            // If "randomChoice" equals between 5 and 8 then spawn unstable platform
                            if (randomChoice >= 5 && randomChoice <= 8)
                            {
                                GameObject unstablePlatform = Instantiate(unstablePlatformPrefab, randomVector, transform.rotation);
                                unstablePlatform.GetComponent<selfDestroy>().enabled = true;
                            }
                            // If "randomChoice" equals between 9 and 12 then spawn spiky platform
                            else if (randomChoice >= 9 && randomChoice <= 12)
                            {
                                GameObject spikyPlatform = Instantiate(spikyPlatformPrefab, randomVector, transform.rotation);
                                spikyPlatform.GetComponent<selfDestroy>().enabled = true;
                            }
                            // If "randomChoice" equals between 13 and 15 then spawn moving platform
                            else if (randomChoice >= 13 && randomChoice <= 15)
                            {
                                GameObject movingPlatform = Instantiate(movingPlatformPrefab, new Vector3(0, randomVector.y, 0), transform.rotation);
                                movingPlatform.GetComponent<selfDestroy>().enabled = true;
                                movingPlatform.GetComponent<movingPlatformScript>().enabled = true;
                            }
                            // If "randomChoice" equals between 18 and 20 then spawn boost platform
                            else if (randomChoice >= 18 && randomChoice <= 20)
                            {
                                GameObject boostPlatform = Instantiate(boostPlatformPrefab, randomVector, transform.rotation);
                                boostPlatform.GetComponent<selfDestroy>().enabled = true;
                            }
                            // Else spawn basic platform
                            else
                            {
                                basicPlatform = Instantiate(basicPlatformPrefab, randomVector, transform.rotation);
                                basicPlatform.GetComponent<selfDestroy>().enabled = true;
                            }
                            break;
                        // Platform no. 3 - it's always a basic platform
                        case 2:
                            GameObject basicPlatform_1 = Instantiate(basicPlatformPrefab, randomVector, transform.rotation);
                            basicPlatform_1.GetComponent<selfDestroy>().enabled = true;
                            break;
                        // Platform no. 4 - randomly chosen between basic and unstable platform
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
