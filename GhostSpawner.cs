using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostSpawner : MonoBehaviour
{
    // The Meat and Potatos of this, this is what spawns the ghosts in the game. 
    // Need to Create the Prefabs to be instantiated
    public Transform parentGhost; // initial ghost
    public GameObject ghostPrefab;
    public float deployTime;
    public float randDeploy;
    private Vector2 gameBoundaries;

    // Ghost Randomizer
    public GameObject[] ghostTypes;

    public float deployFloat = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        deployTime = deployFloat;
        gameBoundaries = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        StartCoroutine(ghostWaves());

        int randomGhost = Random.Range(0, ghostTypes.Length);
    }

    public void Update()
    {
        // should randomize the spawn time with each update
        randDeploy = Random.Range(5f, 10f);
    }

    private void SpawnEntity()
    {
        GameObject ghostType01 = Instantiate(ghostTypes[i], parentGhost) as GameObject;
        //ghostType01.transform.position = new Vector2(gameBoundaries.x * -2, Random.Range(-gameBoundaries.x, gameBoundaries.y));
        ghostType01.transform.SetParent(parentGhost.transform); // spawns it very large and in the wrong area
    }

    IEnumerator ghostWaves()
    {
        while (true)
        {
            yield return new WaitForSeconds(deployFloat); // normally deployFloat
            SpawnEntity();
        }
    }
}



// public GameObject[] ghostPrefabs;
// GameObject ghostType02 = Instantiate(ghostPrefabs[1]) as GameObject;
// GameObject ghostType03 = Instantiate(ghostPrefabs[2]) as GameObject;
// GameObject ghostType04 = Instantiate(ghostPrefabs[3]) as GameObject;