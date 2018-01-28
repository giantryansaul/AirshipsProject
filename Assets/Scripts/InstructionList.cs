using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data/InstructionList", menuName = "InstructionList", order = 1)]
public class InstructionList : ScriptableObject {

    public List<Instruction> instructionList;

}
