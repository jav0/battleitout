using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsMenu : MonoBehaviour
{
    
    public void ChangeSentitivity(float _value)
    {
        PlayerPrefs.SetFloat("Sensitivity", _value);
    }
}
