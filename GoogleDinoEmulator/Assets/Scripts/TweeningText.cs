using UnityEngine;
using UnityEngine.UI;

public class TweeningText : MonoBehaviour
{
    public int maxSize;
    public int minSize;
    public int increment;
    public Text m_Text;

    private bool flag = true;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
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