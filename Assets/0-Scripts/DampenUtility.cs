using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DampenUtility : MonoBehaviour
{

    private Vector3 offset;
    private float Dampening = 1f;
    

    public void ApplyDampening(Transform anObj, Vector3 aNewPos) {
        offset += aNewPos * Time.deltaTime;
        // Dampen current position to target position
        Vector3 oldPosition    = anObj.position;
        Vector3 targetPosition = anObj.position + offset;
        Vector3 newPosition    = Dampen3(oldPosition, targetPosition, Dampening, Time.deltaTime, 0.1f);
        anObj.position = newPosition;
        // Reduce offset by dampen amount
        offset -= newPosition - oldPosition;    
    }
    public void ApplyDampening2D(Transform anObj, Vector3 aNewPos, float aFixedZ) {
        offset += aNewPos * Time.deltaTime;
        offset = new Vector3(offset.x, offset.y, aFixedZ);
        // Dampen current position to target position
        Vector3 oldPosition    = new Vector3(anObj.position.x, anObj.position.y, aFixedZ) ;
        Vector3 targetPosition = anObj.position + offset;
        Vector3 targetPosition2D = new Vector3(targetPosition.x, targetPosition.y, aFixedZ);
        Vector3 newPosition    = Dampen3(oldPosition, targetPosition2D, Dampening, Time.deltaTime, 0.1f);
        anObj.position = newPosition;
        // Reduce offset by dampen amount
        offset -= newPosition - oldPosition;
    }
    
    public static float DampenFactor(float dampening, float elapsed)
	{
#if UNITY_EDITOR
		if (Application.isPlaying == false)
		{
			return 1.0f;
		}
#endif
		return 1.0f - Mathf.Exp(-dampening * elapsed);
	}

	public static float Dampen(float current, float target, float dampening, float elapsed)
	{
		var factor = DampenFactor(dampening, elapsed);

		return Mathf.LerpUnclamped(current, target, factor);
	}

	public static float Dampen(float current, float target, float dampening, float elapsed, float minStep)
	{
		current = Mathf.MoveTowards(current, target, minStep * elapsed);

		return Dampen(current, target, dampening, elapsed);
	}

	public static Quaternion Dampen(Quaternion current, Quaternion target, float dampening, float elapsed)
	{
		var factor = DampenFactor(dampening, elapsed);

		return Quaternion.Slerp(current, target, factor);
	}

	public static Quaternion Dampen(Quaternion current, Quaternion target, float dampening, float elapsed, float minStep)
	{
		var delta  = Quaternion.Angle(current, target);
		var factor = DampenFactor(dampening, elapsed) + Divide(minStep * elapsed, delta);
		
		return Quaternion.Slerp(current, target, factor);
	}

	public static Vector3 Dampen3(Vector3 current, Vector3 target, float dampening, float elapsed)
	{
		var factor = DampenFactor(dampening, elapsed);

		return Vector3.LerpUnclamped(current, target, factor);
	}

	public static Vector3 Dampen3(Vector3 current, Vector3 target, float dampening, float elapsed, float minStep)
	{
		current = Vector3.MoveTowards(current, target, minStep * elapsed);

		return Dampen3(current, target, dampening, elapsed);
	}

    public static float Divide(float a, float b)
	{
		return b != 0.0f ? a / b : 0.0f;
	}
}
