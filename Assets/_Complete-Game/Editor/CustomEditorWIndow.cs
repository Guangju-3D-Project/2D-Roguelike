using log4net.Core;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Board))]
public class CustomEditorWIndow : Editor
{
    private Board board;
    private int squareSize = 40;
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        board = (Board)target;

        if (GUILayout.Button("Add Level"))
        {
            board.AddNewBoard();
        }
        //DrawMapTable();
    }

    //public void DrawMapPalette()
    //{

    //}


    //public void DrawMapTable()
    //{
    //    int size_X = board.size.x;
    //    int size_Y = board.size.y;

    //    for(int y = 0; y < size_Y; y++)
    //    {
    //        GUILayout.BeginHorizontal();
    //        {
    //            for (int x = 0; x < size_X; x++)
    //            {
    //                if (GUILayout.Button("", GUILayout.Width(squareSize), GUILayout.Height(squareSize)))
    //                {
    //                    Debug.Log("Buttons");
    //                }
    //            }
    //        }
    //        GUILayout.EndHorizontal();
    //    }
    //}


}
