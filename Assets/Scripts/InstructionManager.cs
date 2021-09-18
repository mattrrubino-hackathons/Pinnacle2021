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
        Vector3 spawnPos = new Vector3(0, 0, 0);
        Quaternion camRot = Camera.main.transform.rotation;
        Quaternion rotation = Quaternion.Euler(0f, camRot.y, 0f);

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
