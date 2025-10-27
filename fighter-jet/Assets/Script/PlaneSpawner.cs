using UnityEngine;
using System.Collections;

public class PlaneSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] plane;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("StartSpawning", 5f, 7f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnPlanes(int Height)
    {
        Vector2 SpawnPos = new Vector2(transform.position.x, transform.position.y + Height);
        Instantiate(plane[0], SpawnPos, Quaternion.identity);
    }

    void StartSpawning()
    {
        StartCoroutine(SpawnPlatoon());
        Debug.Log("One Spawn Happening");
    }

    public IEnumerator SpawnPlatoon()
    {
        int platoonType = Random.Range(0, 4); 
        //0 = diagonalUp, 1 = diagonalDown, 2 = wave
        //3 = column, 4 = line

        if (platoonType == 0)
        {
            for (int i = -1; i <= 1; i++)
            {
                SpawnPlanes(i * -3);
                Debug.Log("Planes Spawn Happening");
                yield return new WaitForSeconds(1f);
            }
        }

        else if (platoonType == 1)
        {
            for (int i = -1; i <= 1; i++)
            {
                SpawnPlanes(i * 3);
                Debug.Log("Planes Spawn Happening");
                yield return new WaitForSeconds(1f);
            }
        }

        else if (platoonType == 2)
        {
            for (int i = -1; i <= 1; i++)
            {
                SpawnPlanes(i * 3);
                Debug.Log("Planes Spawn Happening");
                yield return new WaitForSeconds(1f);
            }
            for (int i = -1; i <= 1; i++)
            {
                SpawnPlanes(i * -3);
                Debug.Log("Planes Spawn Happening");
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(3f);
        }

        else if (platoonType == 3)
        {
            SpawnPlanes(3);
            SpawnPlanes(0);
            SpawnPlanes(-3);
            yield return new WaitForSeconds(1f);
        }

        else if (platoonType == 4)
        {
            SpawnPlanes(0);
            yield return new WaitForSeconds(1f);
            SpawnPlanes(0);
            yield return new WaitForSeconds(1f);
            SpawnPlanes(0);
            yield return new WaitForSeconds(1f);
        }

    }
}
