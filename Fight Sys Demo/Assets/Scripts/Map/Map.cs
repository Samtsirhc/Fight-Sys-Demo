using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : MonoBehaviour
{
    public GameObject Obj;
    public float cellSize;
    public int mapX;
    public int mapY;

    public struct Cell
    {
        public int x;
        public int y;
        public Vector3 coordinate;
    }

    public List<Cell> map;

    private void Awake()
    {
        cellSize = BasicMath.GetCircumHexagonSize(Obj.transform.localScale.x);
        InitMap();
    }

    void InitMap()
    {
        int _x = 0;
        int _y = 0;
        Vector3 _coordinate = Vector3.zero;
        map = new List<Cell>();
        for (int i = 0; i < mapY; i++)
        {
            for (int j = 0; j < mapX; j++)
            {
                Cell _c = new Cell();
                _c.x = _x;
                _c.y = _y;
                _c.coordinate = _coordinate;
                _x += 1;
                _coordinate += new Vector3(cellSize * 1.73205f, 0, 0);
                map.Add(_c);
            }
            _x = 0;
            _y += 1;
            _coordinate = new Vector3((_y % 2) * 1.73205f * cellSize / 2, _y * cellSize * 1.5f, 0);
        }

        foreach (Cell i in map)
        {
            GameObject _obj = Instantiate(Obj);
            _obj.transform.position = i.coordinate;
        }
    }
}
