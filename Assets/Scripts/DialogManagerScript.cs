using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class DialogManagerScript : MonoBehaviour
{
    #region private members
    private Queue<string> sentences;
    private Queue<AudioClip> audioClips;
    private AudioSource _audio;
    #endregion

    #region public members
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    [Header("Do Something When Dialogue Done")]
    public UnityEvent _event;
    public bool isConversation;
    #endregion
   
    private void Start()
    {
        sentences = new Queue<string>();
        audioClips = new Queue<AudioClip>();
    }

    public void StartDialogue(Dialogue dialog)
    {
        _audio = dialog.audioSource;
        isConversation = true;
        animator.SetBool("IsOpen", true);
        nameText.text = dialog.name;
        audioClips.Clear();
        sentences.Clear();
        
        foreach (AudioClip audio in dialog.audioClips)
        {
            audioClips.Enqueue(audio);
        }
        
        foreach (string sentence in dialog.sentences)
        { 
            sentences.Enqueue(sentence);
        }
        DisplayNext();
    }

    public void DisplayNext()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            isConversation = false;
            return;
        }

        string sentence = sentences.Dequeue();
        dialogueText.text = sentence;
        if (audioClips.Count != 0)
        {
            if (_audio.isPlaying)
            {
                _audio.clip = audioClips.Dequeue();
                _audio.Stop();
                _audio.Play();
            }
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        _event?.Invoke();
    }
    
}
