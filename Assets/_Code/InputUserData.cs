using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using System.Threading.Tasks;

public class InputUserData : MonoBehaviour
{
    [SerializeField] private TMP_InputField inputTime, inputSpeedMove, inputDistanceToDissapearance;

    public async void StartNextCube()
    {
        if (inputTime.text.Length < 1 || inputSpeedMove.text.Length < 1 || inputDistanceToDissapearance.text.Length < 1)
            return;

        Cube cube = PoolManager.instance.GetItem(PoolManager.instance.Cubes);

        float time = Convert.ToSingle(inputTime.text);
        float speedMove = Convert.ToSingle(inputSpeedMove.text);
        float distanceToDissapearance = Convert.ToSingle(inputDistanceToDissapearance.text);

        inputTime.text = "";
        inputSpeedMove.text = "";
        inputDistanceToDissapearance.text = "";

        await Task.Delay(Convert.ToInt32(time) * 1000);

        cube.StartCube(speedMove, distanceToDissapearance);
    }
}
