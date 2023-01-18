using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FOV))]
public class EditorFOV : Editor
{

    

    private void OnSceneGUI()
    {
        FOV fov = (FOV)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fov.PFOV.position, Vector3.up, Vector3.forward, 360, fov.radius);

        Vector3 viewAngle01 = DirectionFromAngle(fov.PFOV.transform.eulerAngles.y, -fov.angle / 2);
        Vector3 viewAngle02 = DirectionFromAngle(fov.PFOV.eulerAngles.y, fov.angle / 2);

        Handles.color = Color.green;
        Handles.DrawLine(fov.PFOV.position, fov.PFOV.position + viewAngle01 * fov.radius);
        Handles.DrawLine(fov.PFOV.position, fov.PFOV.position + viewAngle02 * fov.radius);

        
        if (fov.CanSeeTarget)
        {
            Handles.color = Color.red;
            //Handles.DrawLine(fov.PFOV.position, fov.playerTarget.transform.position);
        }
        
    }

    private Vector3 DirectionFromAngle(float eulerY, float angleInDegrees)
    {
        angleInDegrees += eulerY;

        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }
    
}
