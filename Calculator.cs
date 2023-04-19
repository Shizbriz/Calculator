using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Calculator : MonoBehaviour
{
    private Button button;
    private string eqnText = "";
    private TMP_InputField equationText;
    private TextMeshProUGUI solutionText;
    private Animator anim;
    private GameObject screen;

    private static string operand;
    private float current = 0;
    private float previous = 0;
   // string first;
    //string second;
    // Start is called before the first frame update
    void Start()
    {
       button = GetComponent<Button>();
       button.onClick.AddListener(WhenClicked);

        screen = GameObject.Find("Calculator Screen");
        anim = screen.GetComponent<Animator>();

        equationText = GameObject.Find("Input Field").GetComponent<TMP_InputField>();
        solutionText = GameObject.Find("Solution Text").GetComponent<TextMeshProUGUI>();
        }

    private void WhenClicked()
        {
        if (button.CompareTag("Power"))
            {
            Application.Quit();
            }
        else if (button.CompareTag("Clear"))
            {
            equationText.text = "";
            solutionText.text = "";
            }
        else if (button.CompareTag("Del"))
            {
            equationText.text = equationText.text.Remove(equationText.text.Length - 1);
            }
        else if (button.CompareTag("Equal"))
            {
            eqnText = equationText.text;
            
          string first = eqnText.Remove(eqnText.IndexOf(operand));
            string second = eqnText.Substring(eqnText.IndexOf(operand)+1);
          float result; 
            previous = float.Parse(first);
           current = float.Parse(second);
            Debug.Log(current);
            if(previous != 0 && operand != "" && current != 0)
                {
                switch (operand)
                    {
                    case "+": result = previous + current; break;
                    case "-": result = previous - current; break;
                    case "/": result = previous / current; break;
                    case "*": result = previous * current; break;
                    default: result = previous; break;
                    }
                solutionText.text = result.ToString();
                }
          
            anim.SetTrigger("Equal");
            }
        else if (button.CompareTag("Operand"))
            {
            if(solutionText.text != "")
                {
                equationText.text = solutionText.text;
                solutionText.text = "";
                }
            operand = button.transform.GetChild(0).GetComponent<Text>().text;
            equationText.text += operand;
            anim.SetTrigger("Other");
            }
        else
            {
            if (solutionText.text != "")
                {
                equationText.text = "";  
                solutionText.text = "";
                }
            equationText.text += button.transform.GetChild(0).GetComponent<Text>().text;
            anim.SetTrigger("Other");
            }
        }
   
}
