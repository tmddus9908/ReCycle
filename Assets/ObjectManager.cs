using System.Collections;
using UnityEngine;
using UnityEngine.Tilemaps;
using Random = UnityEngine.Random;

public class ObjectManager : Singleton<ObjectManager>
{
    private IEnumerator _coroutine;
    
    public Sprite[] plasticObjectSprite;
    public Sprite[] paperObjectSprite;
    public Sprite[] glassObjectSprite;
    public Sprite[] metalObjectSprite;

    [SerializeField] private Tilemap[] maps;
    
    [SerializeField] private GameObject entity;
    private float _currTime;
    public enum RecycleType
    {
        Metal,
        Glass,
        Paper,
        Plastic
    }

    private void FixedUpdate()
    {
        _currTime += Time.deltaTime;
        if (_currTime >= 2)
        {
            CreateObj();
            _currTime = 0;
        }
    }
    public void CreateObj()
    {
        int idx = Random.Range(0, maps.Length);
        
        float randomX = Random.Range(maps[idx].transform.position.x - 20, maps[idx].transform.position.x + 20);
        float randomY = Random.Range(maps[idx].transform.position.y - 20, maps[idx].transform.position.y + 20);
        GameObject obj = Instantiate(entity, new Vector3(randomX, randomY), Quaternion.identity);
        obj.AddComponent<RecycleObj>();
    }
}
