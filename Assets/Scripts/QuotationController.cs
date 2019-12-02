using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuotationController : MonoBehaviour
{
    /**
     * Canvas with quotes.
     **/
    public Text Quote;

    /**
     * Used as index in list of quotes.
     **/
    private int triggerCount;

    /**
     * Hardcoded list of selected quotes.
     **/
    private string[] listOfQuotes = new string[7];


    /**
     * Inits variables.
     **/
    private void Start()
    {
        initListOfQuotes();
        triggerCount = gameObject.GetComponent<TriggerEventCounter>().triggerCount;
    }

    /**
     * Inits list.
     **/
    private void initListOfQuotes()
    {
        listOfQuotes[1] = "'Die einsame Scheune am Meer oder die Scheune mitten im Reisfeld … Es gibt alle möglichen Scheunen'";
        listOfQuotes[2] = "'Natürlich wähle ich dabei die aus, bei denen kein großes Feuer entstehen kann.'";
        listOfQuotes[3] = "'Auch die Polizei macht nicht viel Aufhebens davon, wenn eine dieser mickrigen Scheunen brennt.'";
        listOfQuotes[4] = "'Sie hat keine Freunde, die sie um etwas bitten könnte.'";
        listOfQuotes[5] = "'Ich kenne sie ganz gut, sie hat keinen einzigen Pfennig.'";
        listOfQuotes[6] = "'Es ist eine richtig gute Scheune. Seit langem mal wieder eine, die sich abzubrennen lohnt.'";
    }


    private void Update()
    {
        if (triggerCount < gameObject.GetComponent<TriggerEventCounter>().triggerCount)
        {
            triggerCount = gameObject.GetComponent<TriggerEventCounter>().triggerCount;
            initQuote();
        }
    }


    /**
     * Sets quote text with delay.
     **/
    public void initQuote()
    {
        StartCoroutine(setQuote(listOfQuotes[triggerCount], 5));
    }

    IEnumerator setQuote(string quote, float delay)
    {
        Quote.text = quote;
        Quote.enabled = true;
        yield return new WaitForSeconds(delay);
    }
}
