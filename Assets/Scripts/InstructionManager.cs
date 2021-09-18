using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionManager : MonoBehaviour
{
    [SerializeField] GameObject[] instructionObjects;
    [SerializeField] float instructionYOffset = -0.5f;
    Instruction instruction;

    public void SpawnInstruction(int n)
    {
        if (n < 0 || n > instructionObjects.Length)
        {
            Debug.Log("Instruction object index out of range.");
            return;
        }

        Transform cam = Camera.main.transform;
        Vector3 camRot = cam.eulerAngles;

        GameObject obj = instructionObjects[n];
        Vector3 spawnPos = cam.position + new Vector3(cam.forward.x, instructionYOffset, cam.forward.z);
        Quaternion rotation = Quaternion.Euler(0f , camRot.y, 0f);

        instruction = Instantiate(obj, spawnPos, rotation).GetComponent<Instruction>();
    }

    public void DestroyInstruction()
    {
        if (instruction)
        {
            Destroy(instruction.gameObject);
        }
    }

    public Instruction GetInstruction()
    {
        return instruction;
    }
}
