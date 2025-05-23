using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class sta : MonoBehaviour
{
    [SerializeField, Header("オブジェクト")]
    public GameObject[] _gameobj_ran;
    [SerializeField,Header("オブジェクト数(20以下)")]
    public int _num_of_obj;

    public List<int> listx,listy;
    private int n,s,x,y;
    
    // Start is called before the first frame update
    void Start()
    {
        for(int a= -10; a < 11; a++)
        {
            listx.Add(a);
            listy.Add(a);
        }
        for (s = 0; s < _num_of_obj; s++)
        {
            RNG();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RNG()
    {
       x = Random.Range(-10,10);
        if (listx.Contains(x))
        {
            y = Random.Range(-10, 10);
            if (listy.Contains(y))
            {
                n = Random.Range(0, _gameobj_ran.Length-1);
                var appear = Instantiate(_gameobj_ran[n], new Vector3(x, y, 0), Quaternion.identity);
                int intx = listx.IndexOf(x);
                int inty = listy.IndexOf(y);
                listx.RemoveAt(intx);
                listy.RemoveAt(inty);
            }
            else 
            { 
                RNG();
            }
        }
        else
        {
            RNG();
        }
    }
}
