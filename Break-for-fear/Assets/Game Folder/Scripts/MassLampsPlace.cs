//using UnityEngine;

//public class MassLampsPlace : MonoBehaviour
//{
//    public GameObject treePrefab;  // Assign only the specific tree species here
//    public int amount = 1000;
//    public Vector3 areaSize;

//    void Start()
//    {
//        for (int i = 0; i < amount; i++)
//        {
//            Vector3 position = new Vector3(
//                Random.Range(0, areaSize.x),
//                0,
//                Random.Range(0, areaSize.z)
//            );

//            // Raycast to terrain height if needed
//            Instantiate(treePrefab, position, Quaternion.identity);
//        }
//    }

//}
using UnityEngine;

public class MassLampsPlace : MonoBehaviour
{
    public GameObject treePrefab; // The specific tree/pole prefab
    public int amount = 1000;
    public Vector3 areaSize;

    void Start()
    {
        Terrain terrain = Terrain.activeTerrain;

        for (int i = 0; i < amount; i++)
        {
            // Random X and Z inside area
            float x = Random.Range(0, areaSize.x);
            float z = Random.Range(0, areaSize.z);

            // Get correct terrain height at that position
            float y = terrain.SampleHeight(new Vector3(x, 0, z));

            // Optionally align with terrain position
            y += terrain.GetPosition().y;

            // Instantiate the object at correct ground height
            Vector3 position = new Vector3(x, y, z);
            Instantiate(treePrefab, position, Quaternion.identity);
        }
    }
}
