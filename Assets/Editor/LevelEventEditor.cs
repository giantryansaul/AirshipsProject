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
        var topRect = new Rect(position.x + 60, position.y, 15, position.height);
        var leftRect = new Rect(position.x + 75, position.y, 15, position.height);
        var rightRect = new Rect(position.x + 90, position.y, 15, position.height);
        var bottomRect = new Rect(position.x + 105, position.y, 15, position.height);
        
        var showInstructionsRect = new Rect(position.x + 130, position.y, 20, position.height);
        var instructionsRect = new Rect(position.x + 150, position.y, 50, position.height);
        var instructionsScreenRect = new Rect(position.x + 205, position.y, 40, position.height);


        var launchEnemy = property.FindPropertyRelative("LaunchEnemy");
        var launchAtShips = property.FindPropertyRelative("LaunchAtShips");
        var top = property.FindPropertyRelative("Up");
        var left = property.FindPropertyRelative("Left");
        var right = property.FindPropertyRelative("Right");
        var bottom = property.FindPropertyRelative("Down");

        var showInstructions = property.FindPropertyRelative("ShowInstructions");
        var instructions = property.FindPropertyRelative("Instructions");
        var instructionsScreen = property.FindPropertyRelative("InstructionsScreen");
    
        
        EditorGUI.PropertyField(launchEnemyRect, launchEnemy, GUIContent.none);
        if (launchEnemy.boolValue)
        {
            EditorGUI.PropertyField(launchAtShipsRect, launchAtShips, GUIContent.none);
            EditorGUI.PropertyField(topRect, top, GUIContent.none);
            EditorGUI.PropertyField(leftRect, left, GUIContent.none);
            EditorGUI.PropertyField(rightRect, right, GUIContent.none);
            EditorGUI.PropertyField(bottomRect, bottom, GUIContent.none);
        }
            
        
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