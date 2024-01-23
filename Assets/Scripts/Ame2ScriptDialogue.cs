using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Cinemachine.CinemachinePathBase;

public class Ame2ScriptDialogue : MonoBehaviour

{
    public string[] text;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject go = GameObject.FindGameObjectWithTag("DialogueBox");
            if (go == null)
                return;
            Dialogue dlg = go.GetComponent<Dialogue>();
            if (dlg == null)
                return;
            Debug.Log("Ouais");
            dlg.StartDialogue(text);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameObject go = GameObject.FindGameObjectWithTag("DialogueBox");
            if (go == null)
                return;
            Dialogue dlg = go.GetComponent<Dialogue>();
            if (dlg == null)
                return;

            dlg.SetText(new string[] { "" });
            dlg.SetWriting(false);
            dlg.SetVisible(false);
        }
    }

    private void SetDialogueBox(string[] _text, bool _bool)
    {
        
    }
}
