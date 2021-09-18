using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionManager : MonoBehaviour
{
    [SerializeField] GameObject[] instructionObjects;
    GameObject instructionObject;

    public void SpawnInstruction(int n)
    {
        if (n < 0 || n > instructionObjects.Length)
        {
            Debug.Log("Instruction object index out of range.");
            return;
        }

        GameObject obj = instructionObjects[n];
        Vector3 spawnPos = new Vector3(0, 0, 1);
        Quaternion rotation = Quaternion.identity;

        instructionObject = Instantiate(obj, spawnPos, rotation);
    }

    public void DestroyInstruction()
    {
        if (instructionObject?.gameObject != null)
        {
            Destroy(instructionObject.gameObject);
        }
    }
}
