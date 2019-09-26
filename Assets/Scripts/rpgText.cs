using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rpgText : MonoBehaviour
{
    //Sjors you dimwit seperate this code so it'll have its own player input/movement/text recieving
    //also add comments

    //Get delegates to pass through the text messages
    public delegate void updateText(string text);
    public static event updateText newTextValue;

    //Track on which line of the txt file to be in
    private int lineCounter = -1;

    private string[] ImportedText;

    [Header("Required")]
    [Tooltip("This is a variable that requests a text file, this is required. Supported formatting: <color>, <i>, <speed=1>, etc.")]
    [SerializeField] TextAsset textFile;

    [Header("Optional:")]
    [Tooltip("With this you can log the entirety of the text file.")]
    [SerializeField] bool Active;

    public GameObject textbar, target;
    Vector3 savedPosition;

    // Start is called before the first frame update
    void Awake()
    {
        savedPosition = textbar.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (textFile != null)
        {
            ImportedText = textFile.ToString().Split("\n"[0]);

            if (Input.GetKeyDown("space") && ImportedText.Length > lineCounter)
            {
                if (Active && lineCounter >= 1)
                {

                    lineCounter++;
                    if (lineCounter < ImportedText.Length)
                    {
                        newTextValue.Invoke(ImportedText[lineCounter]);
                    }
                    else
                    {
                        Active = false;
                        textFile = null;
                        lineCounter = -1;
                        ImportedText = null;
                    }
                }
                else
                {
                    if (textFile != null)
                    {
                        StartCoroutine(waitForAppearance());
                    }
                }
            }
        }
        if (Active)
        {
            moveToGoal(textbar, target.transform.position);
        }
        else
        {
            moveToGoal(textbar, savedPosition);
        }

    }

    void moveToGoal(GameObject toBeMoved, Vector3 targetPosition)
    {
        toBeMoved.transform.position = Vector3.Lerp(toBeMoved.transform.position, targetPosition, .035f);
    }

    IEnumerator waitForAppearance()
    {
        newTextValue.Invoke("");
        Active = true;
        yield return new WaitForSeconds(.5f);
        lineCounter++;
        newTextValue.Invoke(ImportedText[lineCounter]);
    }

}
