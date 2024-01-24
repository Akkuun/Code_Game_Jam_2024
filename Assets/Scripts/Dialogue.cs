using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI textComponent;

    private string[] text;
    private float textSpeed = 0.05f;
    private float m_speed = 16f;
    private bool isVisible = false;
    private bool isWriting = false;
    private float timer = 0f;
    private RectTransform rectTransform;

    public void SetText(string[] _text)
    {
        text = _text;
    }

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (rectTransform == null)
        {
            rectTransform = GetComponent<RectTransform>();
            return;
        }

        if (isVisible)
        {
            if (rectTransform.position.y <= 290)
                rectTransform.position += new Vector3(0, 1, 0) * m_speed;
        }
        else
        {
            if (rectTransform.position.y >= -200)
                rectTransform.position -= new Vector3(0, 1, 0)* m_speed;
        }
    }

    public void StartDialogue(string[] _text)
    {
        if (!isWriting)
        {
            text = _text;
            textComponent.text = "";
            isWriting = true;
            isVisible = true;
            StartCoroutine(TypeLine());
        }
    }

    public void StartDialogue()
    {
        if (!isWriting && timer <= 0)
        {
            textComponent.text = "";
            isWriting = true;
            isVisible = true;
            StartCoroutine(TypeLine());
        }
    }

    public void SetWriting(bool _bool)
    { 
        isWriting = _bool; 
    }

    public void SetVisible(bool _bool)
    {
        isVisible = _bool;
    }
    /*
    IEnumerator TypeLine()
    {
        for(int i = 0; i < text.Length; i++) 
        {
            if(i%2 == 0)
            {
                textComponent.color = new Color(255, 0, 0);
            }
            else
            {
                textComponent.color = new Color(0, 0, 0);
            }
            textComponent.text = "";
            foreach (char c in text[i].ToCharArray())
            {
                if (!isWriting)
                {
                    isWriting = false;
                    yield break;
                }
                if (c.ToString().Equals("#"))
                {
                    yield return new WaitForSeconds(textSpeed * 10);
                }
                else
                {
                    textComponent.text += c;
                    yield return new WaitForSeconds(textSpeed);
                }
            }
            yield return new WaitForSeconds(3);
        }
        isWriting = false;
    }*/

    IEnumerator TypeLine()
    {
        for (int i = 0; i < text.Length; i++)
        {

            textComponent.text = "";
            foreach (char c in text[i].ToCharArray())
            {
                if (!isWriting)
                {
                    isWriting = false;
                    yield break;
                }
                if (c.ToString().Equals("#"))
                {
                    float timer = 0;
                    while (timer < textSpeed * 10)
                    {
                        if (!isWriting)
                        {
                            isWriting = false;
                            yield break;
                        }
                        timer += Time.deltaTime;
                        yield return null;
                    }
                }
                else if (c.ToString().Equals("°"))
                {
                    textComponent.color = new Color(1, 0, 0);
                }
                else if (c.ToString().Equals("µ"))
                {
                    textComponent.color = new Color(0, 0, 0);
                }

                else if (c.ToString().Equals("£"))
                {
                    textComponent.color = new Color(0.08f, 0, 0.8f);
                }
                else
                {
                    textComponent.text += c;
                    float timer = 0;
                    while (timer < textSpeed)
                    {
                        if (!isWriting)
                        {
                            isWriting = false;
                            yield break;
                        }
                        timer += Time.deltaTime;
                        yield return null;
                    }
                }
            }
            float waitTimer = 0;
            while (waitTimer < 2)
            {
                if (!isWriting)
                {
                    isWriting = false;
                    yield break;
                }
                waitTimer += Time.deltaTime;
                yield return null;
            }
        }
        isWriting = false;
        isVisible = false;
    }

}
