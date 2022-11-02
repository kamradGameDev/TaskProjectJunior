using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Colors : MonoBehaviour
{
    // �� ����������� �������� ��� ��� ����� ���� � �� ����� ���������� ��� �� ����� ������� ����� ����� ������ �� ������ ��������� ������ 
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
