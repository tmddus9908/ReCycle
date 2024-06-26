using UnityEngine;
using Random = UnityEngine.Random;

public class Minigame : MonoBehaviour
{
    [SerializeField] private GameObject square;
    [SerializeField] private GameObject range;
    [SerializeField] public Vector2 vec;
    public bool conclude;
    private void Update()
    {
        square.transform.position += new Vector3(vec.x, 0, 0);
    }

    private void Start()
    {
        RandomScale();
        RandomPosition();
    }

    public void RandomScale()
    {        
        float ran = Random.Range(0.1f, 0.3f);
        range.transform.localScale = new Vector3(ran, 1, 0);
    }

    public void RandomPosition()
    {
        float ran = Random.Range(-0.35f, 0.35f);
        range.transform.localPosition = new Vector3(ran, 0, 0);
    }
}
