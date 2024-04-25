using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Author: LeVassar, Leland
 * Purpose: Literally just to turn some text on and off because Unity doesn't
 * know how to make their text not bleed through walls without mods.
 * Date Created: 4/24/24
 */

public class PopUpLevelText : MonoBehaviour
{
    //Initializes the text as off because this text bleeds through walls for some god forsaken reason
    private void Awake()
    {
        GetComponent<Renderer>().enabled = false;
    }

    //Detects if Player walks in
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            textShow();
        }
    }

    IEnumerator textShow()
    {
        //Makes the renderer turn back on then off again
        GetComponent<Renderer>().enabled = true;
        yield return new WaitForSeconds(10);
        GetComponent<Renderer>().enabled = false;
    }
}
