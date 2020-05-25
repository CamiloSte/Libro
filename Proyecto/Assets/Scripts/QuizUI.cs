using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class QuizUI : MonoBehaviour
{
    [SerializeField] private Text m_question = null;
    [SerializeField] private List<OptionButton> m_buttonList = null;

    public void construct(Question q, System.Action<OptionButton> callback)
    {
        m_question.text = q.Text;

        for (int i = 0; i < m_buttonList.Count; i++)
        {
            m_buttonList[i].constutc(q.options[i], callback);
        }
    }

}

