using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGebControl : MonoBehaviour
{
    [SerializeField]
    private GameObject wallPrefab;
    [SerializeField]
    private GameObject floorPrefab;
    [SerializeField]
    private GameObject arrowSpawnPosition;
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private int arrowSpawnGen = 0;
    [SerializeField]
    private int targetSpawnGen = 0;

    private List<List<bool>> theMap = new List<List<bool>>(); 
    // Start is called before the first frame update
    void Start()
    {
        ReGenMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReGenMap()
    {
        int difference = 0;
        arrowSpawnGen = Random.Range(0, 80);
        do
        {
            targetSpawnGen = Random.Range(0, 80);
            difference = Mathf.Abs((arrowSpawnGen / 9) - (targetSpawnGen / 9)) + Mathf.Abs((arrowSpawnGen % 9) - (targetSpawnGen % 9));
        } while (difference <= 2);
        theMap.Clear();
        SetLine(arrowSpawnGen, targetSpawnGen);
        //int rowCount = 1;
        //int columCount = 0;
        FillTheMap();
    }

    private void SetLine(int start, int end)
    {
        for (int i = 0; i < 10; i++)
        {
            List<bool> aRow = new List<bool>();
            
            for (int j = 0; j < 10; j++)
            {
                bool aCell = false;
                aRow.Add(aCell);
            }
            theMap.Add(aRow);
        }

        int startRow = start / 9;
        int startColum = start % 9;
        int endRow = end / 9;
        int endColum = end % 9;

        theMap[startRow][startColum] = true;
        theMap[startRow][startColum + 1] = true;
        theMap[startRow + 1][startColum] = true;
        theMap[startRow + 1][startColum + 1] = true;
        theMap[endRow][endColum] = true;
        theMap[endRow][endColum + 1] = true;
        theMap[endRow + 1][endColum] = true;
        theMap[endRow + 1][endColum + 1] = true;

        arrowSpawnPosition.transform.position = new Vector3(startColum - 4, 0, startRow - 4);
        target.transform.position = new Vector3(endColum - 4, 0, endRow - 4);

        while (true)
        {            
            if (Random.value < 0.5f)
            {
                if (startRow < endRow)
                {
                    startRow++;
                    theMap[startRow + 1][startColum] = true;
                    theMap[startRow + 1][startColum + 1] = true;
                }
                else if (startRow != endRow)
                {
                    startRow--;
                    theMap[startRow][startColum] = true;
                    theMap[startRow][startColum + 1] = true;
                }
            }
            else
            {
                if (startColum < endColum)
                {
                    startColum++;
                    theMap[startRow][startColum + 1] = true;
                    theMap[startRow + 1][startColum + 1] = true;
                }
                else if (startColum != endColum)
                {
                    startColum--;
                    theMap[startRow][startColum] = true;
                    theMap[startRow + 1][startColum] = true;
                }
            }

            if (((Mathf.Abs(startRow - endRow) < 2) && (startColum == endColum)) || ((Mathf.Abs(startColum - endColum) < 2) && (startRow == endRow)))
            {
                if (startColum == endColum)
                {
                    target.transform.eulerAngles = new Vector3(0, 0, 0);
                }
                else
                {
                    target.transform.eulerAngles = new Vector3(0, 90, 0);
                }
                break;
            }
        }

        int m = 0;
        float therand = Random.value;
        if (Random.value > 0.75f)
        {
            m = 3;
        }
        else if (Random.value < 0.75f && Random.value > 0.5f)
        {
            m = 2;
        }
        else if (Random.value > 0.25f && Random.value < 0.5f)
        {
            m = 1;
        }
        else
        {
            m = 0;
        }

        while (m != 0)
        {
            ExpandMap();
            m--;
        }
    }

    private void FillTheMap()
    {
        int row = 0;
        int colum = 0;
        //arrowSpawnPosition.transform.position = new Vector3();
        foreach (List<bool> theRow in theMap)
        {
            colum = 0;
            foreach (bool theCell in theRow)
            {
                if (theCell)
                {
                    GameObject theFloor = GameObject.Instantiate(floorPrefab, gameObject.transform);
                    theFloor.transform.localPosition = new Vector3(colum - 6, 0, row - 6);
                    if ((colum == 0) || (!theRow[colum - 1]))
                    {
                        GameObject theWall = GameObject.Instantiate(wallPrefab, gameObject.transform);
                        theWall.transform.localPosition = new Vector3(colum - 6, 0, row - 5);
                        theWall.transform.eulerAngles = new Vector3(0, 90, 0);
                    }
                    if ((colum == 9) || (!theRow[colum + 1]))
                    {
                        GameObject theWall = GameObject.Instantiate(wallPrefab, gameObject.transform);
                        theWall.transform.localPosition = new Vector3(colum - 5, 0, row - 5);
                        theWall.transform.eulerAngles = new Vector3(0, 90, 0);
                    }
                    if ((row == 0) || (!theMap[row - 1][colum]))
                    {
                        GameObject theWall = GameObject.Instantiate(wallPrefab, gameObject.transform);
                        theWall.transform.localPosition = new Vector3(colum - 6, 0, row - 6);
                    }
                    if ((row == 9) || (!theMap[row + 1][colum]))
                    {
                        GameObject theWall = GameObject.Instantiate(wallPrefab, gameObject.transform);
                        theWall.transform.localPosition = new Vector3(colum - 6, 0, row - 5);
                    }
                }
                colum++;
            }
            row++;
        }
    }

    private void ExpandMap()
    {
        for (int row = 0; row < 10; row++)
        {
            for (int colum = 0; colum < 10; colum++)
            {
                if (theMap[row][colum])
                {
                    if (Random.value > 0.5)
                    {
                        if (Random.value < 0.5f)
                        {
                            if (Random.value < 0.5f)
                            {
                                if (row != 9)
                                {
                                    theMap[row + 1][colum] = true;
                                }
                            }
                            else
                            {
                                if (row != 0)
                                {
                                    theMap[row - 1][colum] = true;
                                }
                            }
                        }
                        else
                        {
                            if (Random.value < 0.5f)
                            {
                                if (colum != 9)
                                {
                                    theMap[row][colum + 1] = true;
                                }
                            }
                            else
                            {
                                if (colum != 0)
                                {
                                    theMap[row][colum - 1] = true;
                                }
                            }
                        }
                    }                    
                }
            }
        }
    }
}
