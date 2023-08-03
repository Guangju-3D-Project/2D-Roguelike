using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static Completed.BoardManager;

[CreateAssetMenu(fileName = "Level", menuName = "Level/Add level", order = 1)]
public class Board : ScriptableObject
{
    public int Level;

    public int columns = 8;//Number of columns in our game board.
    public int rows = 8;//Number of rows in our game board.
    public Vector2Int size = Vector2Int.one * 8;
    public Count wallCount = new Count(5, 9);//Lower and upper limit for our random number of walls per level.
    public Count foodCount = new Count(1, 5);//Lower and upper limit for our random number of food items per level.

    public bool IsSpawnEnemy = true;
    public int EnemyMinCount = 1;
    public int EnemyMaxCount = 1;

    public GameObject exit;//Prefab to spawn for exit.
    public GameObject[] floorTiles;//Array of floor prefabs.
    public GameObject[] wallTiles;//Array of wall prefabs.
    public GameObject[] foodTiles;//Array of food prefabs.
    public GameObject[] enemyTiles;//Array of enemy prefabs.
    public GameObject[] outerWallTiles; //Array of outer tile prefabs.

    public GameObject Map;

    public void AddNewBoard()
    {
        var newBoard = CreateInstance<Board>();

        int level = GetAllBoards();
        newBoard.Level = level;
        newBoard.columns = columns;
        newBoard.rows = rows;
        newBoard.wallCount = wallCount;
        newBoard.foodCount = foodCount;

        newBoard.IsSpawnEnemy = IsSpawnEnemy;
        newBoard.EnemyMinCount = EnemyMinCount;
        newBoard.EnemyMaxCount = EnemyMaxCount;

        newBoard.exit = exit;
        newBoard.floorTiles = floorTiles;
        newBoard.wallTiles = wallTiles;
        newBoard.foodTiles = foodTiles;
        newBoard.enemyTiles = enemyTiles;
        newBoard.outerWallTiles = outerWallTiles;

        AssetDatabase.CreateAsset(newBoard, $"Assets/_Complete-Game/Levels/Level_{level}.asset");
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();
    }

    private int GetAllBoards()
    {
        List<Board> boards = new List<Board>();
        string[] guids = AssetDatabase.FindAssets("t:Board", new[] { "Assets/_Complete-Game/Levels" });

        foreach (string guid in guids)
        {
            string assetPath = AssetDatabase.GUIDToAssetPath(guid);
            Board board = AssetDatabase.LoadAssetAtPath<Board>(assetPath);
            if (board != null)
            {
                boards.Add(board);
            }
        }

        return boards.Last<Board>().Level + 1;
    }

}