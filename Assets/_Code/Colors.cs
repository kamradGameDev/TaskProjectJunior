using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{
    // not a full-fledged singleton since there is only one scene and you do not need to make sure that more than one reference to this instance of the class will not be created
    public static Colors instance { get; private set; }
    [SerializeField] private Color[] setOfColors;

    private void Awake()
    {
        if (!instance)
            instance = this;
    }

    public Color GetRandomColor() =>
        setOfColors[TRandom.RandomIndex(0, setOfColors.Length)];
}
