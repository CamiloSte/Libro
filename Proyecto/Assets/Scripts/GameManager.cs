using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(AudioSource))]

public class GameManager : MonoBehaviour
{
    [SerializeField] private AudioClip m_correctSound = null;
    [SerializeField] private AudioClip m_incorrectSound = null;
    [SerializeField] private Color m_correctColor = Color.black;
    [SerializeField] private Color m_incorrectColor = Color.black;
    [SerializeField] private float m_waitTime = 0.0f;
    [SerializeField] public int PuntosCorrecto = 20;



    private QuizDB m_quizDB = null;
    private QuizUI m_quizUI = null;
    private AudioSource m_audioSource = null;

    private void Start()
    {
        m_quizDB = GameObject.FindObjectOfType<QuizDB>();
        m_quizUI = GameObject.FindObjectOfType<QuizUI>();
        m_audioSource = GetComponent<AudioSource>();
        nextQuestion();


    }
    private void nextQuestion()
    {
        m_quizUI.construct(m_quizDB.GetRandom(), GiveAnswer);

    }
    private void GiveAnswer(OptionButton optionButton)
    {
        StartCoroutine(GiveAnswerRoutine(optionButton));
    }
    private IEnumerator GiveAnswerRoutine(OptionButton optionButton)
    {
        if (m_audioSource.isPlaying)
            m_audioSource.Stop(); 

        m_audioSource.clip = optionButton.Option.correct ? m_correctSound : m_incorrectSound;
        optionButton.serColor(optionButton.Option.correct ? m_correctColor : m_incorrectColor);

        m_audioSource.Play();

        if (optionButton.Option.correct)
        {
            Puntuacion.Puntaje += PuntosCorrecto;
        }


        yield return new WaitForSeconds(m_waitTime);
        nextQuestion();
    }
}
