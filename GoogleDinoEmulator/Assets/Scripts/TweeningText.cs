using UnityEngine;
using UnityEngine.UI;

public class TweeningText : MonoBehaviour
{
    public int maxSize;
    public int minSize;
    public int increment;
    public Text m_Text;

    private bool flag = true;

    private void FixedUpdate()
    {
        if (flag)
        {
            if (m_Text.fontSize <= maxSize)
                m_Text.fontSize += increment;
            else
                flag = false;
        }
        else
        {
            if (m_Text.fontSize <= minSize)
                flag = true;
            else
                m_Text.fontSize -= increment;
        }
    }
}