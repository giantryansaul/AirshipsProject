using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(LevelEvent))]
public class LevelEventEditor : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);

        position = EditorGUI.PrefixLabel(position, GUIUtility.GetControlID(FocusType.Passive), label);

        var indent = EditorGUI.indentLevel;
        EditorGUI.indentLevel = 0;
		
        var launchEnemyRect = new Rect(position.x, position.y, 15, position.height);
        var launchAtShipsRect = new Rect(position.x + 17, position.y, 40, position.height);
        
        var showInstructionsRect = new Rect(position.x + 60, position.y, 20, position.height);
        var instructionsRect = new Rect(position.x + 82, position.y, 50, position.height);
        var instructionsScreenRect = new Rect(position.x + 140, position.y, 40, position.height);


        var launchEnemy = property.FindPropertyRelative("LaunchEnemy");
        var launchAtShips = property.FindPropertyRelative("LaunchAtShips");

        var showInstructions = property.FindPropertyRelative("ShowInstructions");
        var instructions = property.FindPropertyRelative("Instructions");
        var instructionsScreen = property.FindPropertyRelative("InstructionsScreen");
    
        
        EditorGUI.PropertyField(launchEnemyRect, launchEnemy, GUIContent.none);
        if (launchEnemy.boolValue)
            EditorGUI.PropertyField(launchAtShipsRect, launchAtShips, GUIContent.none);
        
        EditorGUI.PropertyField(showInstructionsRect, showInstructions, GUIContent.none);
        if (showInstructions.boolValue)
        {
            EditorGUI.PropertyField(instructionsRect, instructions, GUIContent.none);
            EditorGUI.PropertyField(instructionsScreenRect, instructionsScreen, GUIContent.none);
        }


        EditorGUI.indentLevel = indent;
		
        EditorGUI.EndProperty();
    }
}