using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DevKit;

[CustomEditor(typeof(TextureScroller))]
public class TextureScrollerEditor : Editor
{
    TextureScroller scroller;

    private void Awake()
    {
        if (!scroller) {
            scroller = target as TextureScroller;
            scroller.InitializeImage();
        }
        //sub to editor event
        EditorApplication.playModeStateChanged += ModeChanged;
    }

    //---------------------editor related functions----------------------
    void ModeChanged(PlayModeStateChange playModeState)
    {
        if (playModeState == PlayModeStateChange.EnteredEditMode) {
            scroller.imgShower.material.SetTextureOffset("_MainTex", Vector2.zero);
        }
    }
}
