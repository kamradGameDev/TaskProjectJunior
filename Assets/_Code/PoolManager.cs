using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    public static PoolManager instance { get; private set; }
    [SerializeField] private Transform cubesParent;
    [SerializeField] private List<Cube> cubes;
    public List<Cube> Cubes
    {
        get { return cubes; }
        private set { cubes = Cubes; }
    }

    private void Awake()
    {
        if (!instance)
            instance = this;
    }
    public void ReturnItemToPooled<T>(List<T> list, T item) =>
        list.Add(item);

    public T GetItem<T>(List<T> list)
    {
        T item = TRandom.RandomItemList(list);
        list.Remove(item);

        return item;
    }

    public void InstanceNewItem<T>(T item)
    {
        if(item as Cube)
        {
            Cube cube = item as Cube;
            cube = Instantiate(cube, cubesParent);
            cube.gameObject.SetActive(false);
            cubes.Add(cube);
        }
    }
}
