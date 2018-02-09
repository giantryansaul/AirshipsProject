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
        var launchAtShipsRect = new Rect(launchEnemyRect.x + launchEnemyRect.width + 2, position.y, 60, position.height);
        var topRect = new Rect(launchAtShipsRect.x + launchAtShipsRect.width, position.y, 15, position.height);
        var leftRect = new Rect(topRect.x + topRect.width, position.y, 15, position.height);
        var rightRect = new Rect(leftRect.x + leftRect.width, position.y, 15, position.height);
        var bottomRect = new Rect(rightRect.x + rightRect.width, position.y, 15, position.height);
        
        var showInstructionsRect = new Rect(bottomRect.x + bottomRect.width + 10, position.y, 20, position.height);
        var instructionsRect = new Rect(showInstructionsRect.x + showInstructionsRect.width + 1, position.y, 100, position.height);
        var instructionsScreenRect = new Rect(instructionsRect.x + instructionsRect.width + 3, position.y, 70, position.height);


        var launchEnemy = property.FindPropertyRelative("LaunchEnemy");
        var launchAtShips = property.FindPropertyRelative("LaunchAtShips");
        var top = property.FindPropertyRelative("Up");
        var left = property.FindPropertyRelative("Left");
        var right = property.FindPropertyRelative("Right");
        var bottom = property.FindPropertyRelative("Down");

        var showInstructions = property.FindPropertyRelative("ShowTutorial");
        var instructions = property.FindPropertyRelative("Tutorial");
        var instructionsScreen = property.FindPropertyRelative("TutorialScreen");
    
        
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