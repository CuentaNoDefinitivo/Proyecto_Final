using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform playerToFollowAndLook;
    [SerializeField] Vector3 ofset;

    Camera camera;

    private void Awake()
    {
        camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = playerToFollowAndLook.position + ofset;
        transform.LookAt(playerToFollowAndLook);
    }
    public void ChangeView(float size)
    {
        StartCoroutine(ChangeViewCoroutine(size));
    }
    public void ChangeView(float size, float durationTime)
    {
        StartCoroutine(ChangeViewCoroutine(size, durationTime));
    }
    IEnumerator ChangeViewCoroutine(float size)
    {
        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, size, 0.5f * Time.deltaTime);
        while (Mathf.Round(camera.orthographicSize * 100) != Mathf.Round(size * 100))
        {
            yield return new WaitForEndOfFrame();
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, size, 0.5f * Time.deltaTime);
        }
        camera.orthographicSize = size;
    }
    IEnumerator ChangeViewCoroutine(float size, float durationTime)
    {
        float startedTime = Time.realtimeSinceStartup; //cuándo empezó la habilidad
        float cameraOriginalSize = camera.orthographicSize; //vistaOriginalParaVolver


        while (Mathf.Round(camera.orthographicSize * 10) != Mathf.Round(size * 10)) //si vista actual no es size(aprox), entonces
        {
            camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, size, 0.95f * Time.deltaTime); //cambiar vista a un valor cercano a size(valor que hay que cambiar)

            if (Time.realtimeSinceStartup >= startedTime + durationTime) break; //si ya a pasado la duración de la habilidad dejar de seguir incrementando aunque no haya lleguado a size
            yield return new WaitForEndOfFrame(); //esperar al siguiente frame
        }
        if(Time.realtimeSinceStartup < startedTime + durationTime) camera.orthographicSize = size; //si no ha pasado la duración de la habilidad y a dejado de incrementar, forzar que la vista sea exactamente size


        while (Mathf.Round(camera.orthographicSize * 100) != Mathf.Round(cameraOriginalSize * 100)) // si no ha vuelto a size original, entonces...
        {
            if(Time.realtimeSinceStartup >= startedTime + durationTime) //si ya a pasado la duración de la habilidad
            {
                camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, cameraOriginalSize, 0.9f * Time.deltaTime); //reducir vista
                yield return new WaitForEndOfFrame(); //esperar al siguiente frame
            }
            else yield return new WaitForEndOfFrame(); // si no ha pasado la duración de la habilidad esperar al siguiente frame y preguntar otra vez
        }
        camera.orthographicSize = cameraOriginalSize; // al finar forzar que sea exactamente originalSize
    }
}
