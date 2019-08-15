using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;
public class SimplifyTools : EditorWindow
{
    List<GameObject> list = new List<GameObject>();
    GameObject father;
    bool MoveandRemove;
    Vector2 scroll;
    string textFilter;
    bool show = true;
    bool filter;
    [MenuItem("MyTools/SimplifyTools %p")]
    public static void OpenWindow()
    {
        SimplifyTools _sim = (SimplifyTools)GetWindow(typeof(SimplifyTools));
        _sim.Show();
    }
    private void OnGUI()
    {
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 5), Color.gray);
        father = (GameObject)EditorGUILayout.ObjectField("Parent: ", father, typeof(GameObject), true);
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 5), Color.gray);
        EditorGUILayout.Space();
        if (GUILayout.Button("Add"))
        {
            var objs = Selection.gameObjects;
            for (int i = 0; i < objs.Length; i++)
            {
                if (!list.Contains(objs[i]))
                    list.Add(objs[i]);
            }
        }
        EditorGUILayout.Space();
        EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 5), Color.gray);

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Move To Parent"))
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (filter)
                {
                    if (list[i].name.Contains(textFilter))
                    {
                        list[i].transform.parent = father.transform;
                    }
                }
                else
                {
                    list[i].transform.parent = father.transform;
                }
            }
            if (MoveandRemove)
            {
                list.Clear();
            }
        }
        MoveandRemove = EditorGUILayout.Toggle("Move and Remove", MoveandRemove);
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.Space();

        EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 5), Color.gray);

        show = EditorGUILayout.Toggle("Show " + list.Count + " Objects: ", show);
        if (show)
        {

            EditorGUILayout.Space();
            EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 5), Color.gray);

            EditorGUILayout.BeginHorizontal();
            filter = EditorGUILayout.BeginToggleGroup("Filter By Name", filter);
            textFilter = EditorGUILayout.TextField(textFilter);
            EditorGUILayout.EndToggleGroup();

            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();
            EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 5), Color.gray);

            scroll = EditorGUILayout.BeginScrollView(scroll);
            for (int i = 0; i < list.Count; i++)
            {
                if (filter)
                {
                    if (list[i].name.Contains(textFilter))
                    {
                        EditorGUILayout.BeginHorizontal();
                        list[i] = (GameObject)EditorGUILayout.ObjectField("Object" + i + ": ", list[i], typeof(GameObject), true);
                        if (GUILayout.Button("Remove"))
                        {
                            list.RemoveAt(i);
                        }
                        EditorGUILayout.EndHorizontal();
                    }
                }
                else
                {
                    EditorGUILayout.BeginHorizontal();
                    list[i] = (GameObject)EditorGUILayout.ObjectField("Object" + i + ": ", list[i], typeof(GameObject), true);
                    if (GUILayout.Button("Remove"))
                    {
                        list.RemoveAt(i);
                    }
                    EditorGUILayout.EndHorizontal();
                }
            }
            EditorGUILayout.EndScrollView();
        }

        EditorGUI.DrawRect(GUILayoutUtility.GetRect(100, 5), Color.gray);
        EditorGUILayout.Space();
        if (GUILayout.Button("RemoveAll"))
        {
            // EditorGUILayout.Popup(0, new string[] { "Sure" }, "Cancel");
            list.Clear();
        }
    }

}
