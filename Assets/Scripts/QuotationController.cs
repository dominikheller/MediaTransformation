using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class QuotationController : MonoBehaviour
{
    /**
     * Canvas with quotes.
     **/
    public Text Quote;

    /**
     * Clue index for list of quotes.
     **/
    private int clueIndex;

    /**
    * Current scene name.
    **/
    string sceneName;

    /**
     * Hardcoded list of selected quotes.
     **/
    private string[] listOfQuotes = new string[7];

    /**
     * Inits variables.
     **/
    private void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        sceneName = currentScene.name;
        initListOfQuotes();
        clueIndex = gameObject.GetComponent<TriggerEventCounter>().clueIndex;
    }

    /**
     * Inits list.
     **/
    private void initListOfQuotes()
    {
        if (sceneName == "barn1")
        {
            listOfQuotes[1] = "'Die einsame, abgeschiedene Scheune im Wald'";
            listOfQuotes[2] = "'Sie raucht wie ein Schlot.'";
            listOfQuotes[3] = "'Überall liegen leere Bierdosen und Weinflaschen herum'";
            listOfQuotes[4] = "'Sie ist verschlossen.'";
            listOfQuotes[5] = "'Holz für eine weitere Scheune?'";
            listOfQuotes[6] = "'Sie ist nah am Wasser gebaut.'";
        }
        if (sceneName == "barn3")
        {
            listOfQuotes[1] = "'Todo: Insert suitable quote to QuotationController (1)'";
            listOfQuotes[2] = "'Todo: Insert suitable quote to QuotationController (2)'";
            listOfQuotes[3] = "'Todo: Insert suitable quote to QuotationController (3)'";
            listOfQuotes[4] = "'Todo: Insert suitable quote to QuotationController (4)'";
        }
    }


    private void Update()
    {
        if (clueIndex != gameObject.GetComponent<TriggerEventCounter>().clueIndex)
        {
            clueIndex = gameObject.GetComponent<TriggerEventCounter>().clueIndex;
            initQuote();
        }
    }


    /**
     * Sets quote text with delay.
     **/
    public void initQuote()
    {
        StartCoroutine(setQuote(listOfQuotes[clueIndex], 5));
    }

    IEnumerator setQuote(string quote, float delay)
    {
        Quote.text = quote;
        Quote.enabled = true;
        yield return new WaitForSeconds(delay);
        Quote.text = "";
    }
}
