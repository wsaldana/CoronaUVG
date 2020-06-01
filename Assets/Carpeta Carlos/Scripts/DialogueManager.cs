using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    //public Animator animator;
    public Button ButtonJugar;
    public Button ButtonContinuar;
    public int contador;
    
    private Queue<string> sentences;
    void Start()
    {
        sentences = new Queue<string>();
    }


    public void StartDialogue(Dialogue dialogue)
    {
        //Debug.Log("Starting conversation with " + dialogue.name);
        //animator.SetBool("IsOpen", true);
        ButtonContinuar.gameObject.SetActive(true);
        nameText.text = dialogue.name;
        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        
        if (sentences.Count == 0)
        {
            
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //dialogueText.text = sentence;
        //Debug.Log(sentence);
    }
    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }
   public void EndDialogue()
    {
        
        contador += 1;
        //animator.SetBool("IsOpen", false);
        if (contador == 3) 
        {
            ButtonJugar.gameObject.SetActive(true);
            ButtonContinuar.gameObject.SetActive(false);
        } 
        // Debug.Log("End of the conversation");
    }

}
