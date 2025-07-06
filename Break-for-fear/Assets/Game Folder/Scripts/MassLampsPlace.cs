using UnityEngine;

public class MassLampsPlace : MonoBehaviour
{
    public GameObject treePrefab;  // Assign only the specific tree species here
    public int amount = 1000;
    public Vector3 areaSize;

    void Start()
    {
        for (int i = 0; i < amount; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(0, areaSize.x),
                0,
                Random.Range(0, areaSize.z)
            );

            // Raycast to terrain height if needed
            Instantiate(treePrefab, position, Quaternion.identity);
        }
    }

}
