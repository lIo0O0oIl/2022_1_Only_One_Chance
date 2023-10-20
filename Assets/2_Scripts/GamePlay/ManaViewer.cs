using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaViewer : MonoBehaviour
{
    [SerializeField] Mana mana;

    Slider sliderMana;
    void Start()
    {
        sliderMana = GetComponent<Slider>();
        StartCoroutine("NatureMana");
    }

    // Update is called once per frame
    void Update()
    {
        sliderMana.value = Mathf.Lerp(sliderMana.value, mana.CurrentMana / mana.MaxMana, Time.deltaTime * 10);      // 마나 자연스럽게 줄어들게
    }

    IEnumerator NatureMana()        // 마나가 계속해서 늘어나게
    {
        while (true)
        {
            if (mana.currentMana < mana.MaxMana) mana.currentMana += 0.2f;
            yield return new WaitForSeconds(0.1f);
        }
        /*sliderMana.value += 1;
        yield return new WaitForSeconds(1);*/
    }
}
