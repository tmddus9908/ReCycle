using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

public class ObjectManager : Singleton<ObjectManager>
{
    private IEnumerator _coroutine;
    
    public Sprite[] plasticObjectSprite;
    public Sprite[] paperObjectSprite;
    public Sprite[] glassObjectSprite;
    public Sprite[] metalObjectSprite;

    [SerializeField] private GameObject entity;
    public enum RecycleType
    {
        Metal,
        Glass,
        Paper,
        Plastic
    }

    void Start()
    {
        _coroutine = Instantiate();
    }

    private void FixedUpdate()
    {
        StartCoroutine(_coroutine);
    }

    IEnumerator Instantiate()
    {
        yield return new WaitForSeconds(2.0f);
        CreateObj(GetRendomEnumValue());
    }

    public RecycleType GetRendomEnumValue()
    {
        var enumValues = System.Enum.GetValues(enumType: typeof(RecycleType));
        return (RecycleType)enumValues.GetValue(Random.Range(0, enumValues.Length));
    }
    public void CreateObj(RecycleType rt)
    {
        float random = Random.Range(-40, 40);
        GameObject obj = Instantiate(entity, new Vector3(random, random), Quaternion.identity);
        obj.AddComponent<RecycleObj>();
        obj.GetComponent<RecycleObj>().type = rt;
    }
}
