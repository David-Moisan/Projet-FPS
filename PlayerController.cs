using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    //création d'une variable pour initialiser une vitesse de mouvement
    [SerializeField]
    private float speed = 3f;

    [SerializeField]
    private float mouseSensitivityX = 3f;
    [SerializeField]
    private float mouseSensitivityY = 3f;

    //création d'une référence pour utiliser le script PlayerMotor
    private PlayerMotor motor;

    private void Start()
    {
        motor = GetComponent<PlayerMotor>(); //Stockage du component PlayerMotor dans la variable motor
    }

    private void Update()
    {
        //Calculer la vélocité (vitesse) du mouvement de notre joueur
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 moveHorizontal = transform.right * xMov;
        Vector3 moveVertical = transform.forward * zMov;

        Vector3 velocity = (moveHorizontal + moveVertical).normalized * speed;

        motor.Move(velocity);

        //Calcule de la rotation du joueur en un Vector3
        float yRot = Input.GetAxisRaw("Mouse X");

        Vector3 rotation = new Vector3(0, yRot, 0) * mouseSensitivityX; //blocage de l'axe X et Z et seul l'axe Y va être modifié

        motor.Rotate(rotation);

        //Calcule de la rotation de la camera en un Vector3
        float xRot = Input.GetAxisRaw("Mouse Y");

        Vector3 cameraRotation = new Vector3(xRot, 0, 0) * mouseSensitivityY; //blocage de l'axe Y et Z et seul l'axe X va être modifié

        motor.RotateCamera(cameraRotation);
    }
}
