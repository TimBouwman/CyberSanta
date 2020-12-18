//author: Tim Bouwman
//Github: https://github.com/TimBouwman
using UnityEngine;

/// <summary>
/// 
/// </summary>
public class FlightController : MonoBehaviour
{
    #region Variables
    [SerializeField] private Transform inputObjectIndex = null;
    [SerializeField] private Transform inputObject = null;
    private Vector3 input = Vector3.zero;
    [Header("Movement")]
    [SerializeField] private float minMovementInput = 0.1f;
    [SerializeField] private float maxMovementInput = 0.3f;
    [SerializeField] private float movementSpeed = 5f;
    [Header("Pitch")]
    [SerializeField] private float minPitchInput = 0.1f;
    [SerializeField] private float maxPitchInput = 0.3f;
    [SerializeField] private float pitchSpeed = 5f;
    [Header("Yaw")]
    [SerializeField] private float minYawInput = 5f;
    [SerializeField] private float maxYawInput = 30f;
    private float maxYawInputQuaternion = 0f;
    [SerializeField] private float yawSpeed = 5f;

    [SerializeField] private Transform wheel = null;
    #endregion

    #region Unity Methods
    private void Start()
    {
        Setup();
    }

    private void Update()
    {
        wheel.localPosition = new Vector3(0, 0, inputObjectIndex.localPosition.z);
        wheel.GetChild(0).transform.localEulerAngles = new Vector3(0, 0, inputObjectIndex.localEulerAngles.z);

        input = inputObjectIndex.localPosition;

        //Movement(input.z, movementSpeed, minMovementInput, Multiplier(maxMovementInput, input.z));
        /*Pitch*/ Steering(input.z, pitchSpeed, minPitchInput, Vector3.right, Multiplier(maxPitchInput, input.y));
        /*Yaw*/   Steering(inputObjectIndex.localEulerAngles.z, -yawSpeed, minYawInput, Vector3.up, Multiplier(maxYawInputQuaternion, inputObjectIndex.localRotation.z));

        print(Multiplier(maxPitchInput, input.y));
    }
    #endregion

    #region Custom Methods
    private void Setup()
    {
        //change eulerangle.z to a quaternion value this is done to make the inspector more user friendly
        inputObjectIndex.localEulerAngles = new Vector3(0, 0, maxYawInput);
        maxYawInputQuaternion = inputObjectIndex.localRotation.z;
        inputObjectIndex.localEulerAngles = Vector3.zero;
    }

    private void Movement(float input, float speed, float min, float multiplier)
    {
        //if (input > min)
            this.transform.position += transform.forward * (speed * input) * Time.deltaTime;
    }
    private void Steering(float input, float speed, float min, Vector3 axis, float multiplier)
    {
        //if (input > min || input < -min)
            this.transform.Rotate(axis * (speed * multiplier) * Time.deltaTime);
    }

    private float Multiplier(float max, float input)
    {
        return Mathf.Clamp(1 / max * input, -1f, 1f);
    }

    /*
    private void Speed()
    {
        float z = inputObjectIndex.localPosition.z;
        float multiplier = 1 / maxPitchInput * z;

        if (z > minSpeedInput || z < -minSpeedInput)
            transform.Rotate(Vector3.right * (-movementSpeed * multiplier) * Time.deltaTime);
    }
    private void Pitch()
    {
        float y = inputObjectIndex.localPosition.y;
        float multiplier = 1 / maxPitchInput * y;

        if (y > minPitchInput || y < -minPitchInput)
            transform.Rotate(Vector3.right * (-pitchSpeed * multiplier) * Time.deltaTime);
    }
    private void Roll()
    {
        float z = inputObjectIndex.localEulerAngles.z;

        float multiplier = 1 / maxRollInputQuaternion * inputObjectIndex.localRotation.z;
        print(multiplier);

        if ((z > minRollInput && z < maxRollInput) || (z < 360 - minRollInput && z > -maxRollInput))
            transform.Rotate(Vector3.forward * (rollSpeed * multiplier) * Time.deltaTime);
    }*/
    #endregion
}