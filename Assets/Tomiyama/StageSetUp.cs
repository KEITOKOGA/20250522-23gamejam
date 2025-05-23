using UnityEngine;
using Random = System.Random;

public class StageSetUp : MonoBehaviour
{
    [SerializeField] private GameObject[] _templates;

    private void Start()
    {
        Instantiate(_templates[new Random().Next(0, _templates.Length)], transform.position,Quaternion.identity);
    }
}
