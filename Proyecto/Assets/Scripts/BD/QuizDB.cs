using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class QuizDB : MonoBehaviour
{
    [SerializeField] private List<Question> m_ListQuestion = null;

    public List<Question> m_backup = null;
    public string random1 = null;

    private void Awake()
    {
        m_backup = m_ListQuestion.ToList();
        GetRandom();

    }
    public Question GetRandom(bool remove = true)
    {
        if (m_ListQuestion.Count == 0)
            RestoreBackup();

        int index = Random.Range(0, m_ListQuestion.Count);

        if (!remove)
            return m_ListQuestion[index];

        Question q = m_ListQuestion[index];
        m_ListQuestion.RemoveAt(index);
        return q;
    }
    private void RestoreBackup()
    {
        m_ListQuestion = m_backup.ToList();
    }
}
