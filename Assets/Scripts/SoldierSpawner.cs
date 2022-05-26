using UnityEngine;

public class SoldierSpawner : MonoBehaviour
{
    public int NumberOfSoldiers;
    public GameObject SoldierPrefab;
    public float SpawnRadius;
    public LayerMask Obstacles;

    bool CheckPosition(Vector3 position)
    {
        if (!Physics.CheckSphere(position, SpawnRadius , Obstacles))
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    void Awake()
    {
        for (int i = 0; i < NumberOfSoldiers; i++)
        {
            Vector3 position = new Vector3(Random.Range(-190, 190), 0, Random.Range(-190, 190));
            while (!CheckPosition(position))
            {
                position = new Vector3(Random.Range(-190, 190), 0, Random.Range(-190, 190));
            }
            Instantiate(SoldierPrefab, position, Quaternion.identity , transform);
        }
    }

    public void Revive(GameObject Soldier)
    {
        Vector3 position = new Vector3(Random.Range(-190, 190), 0, Random.Range(-190, 190));
        while (!CheckPosition(position))
        {
            position = new Vector3(Random.Range(-190, 190), 0, Random.Range(-190, 190));
        }
        Soldier.transform.position = position;
        Soldier.SetActive(true);
    }
}
