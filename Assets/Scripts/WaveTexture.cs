using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    // Αυτά τα βλέπεις στον Inspector για να τα αλλάζεις
    public float scrollSpeedX = 0.05f;
    public float scrollSpeedY = 0.05f;

    private Renderer rend;

    void Start()
    {
        // Πάρε το Renderer component από αυτό το αντικείμενο
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        // Υπολόγισε το νέο offset βασισμένο στον χρόνο και την ταχύτητα
        float offsetX = Time.time * scrollSpeedX;
        float offsetY = Time.time * scrollSpeedY;

        // Εφάρμοσε το νέο offset στο υλικό
        // Το "_BaseMap" είναι το όνομα της κύριας υφής στο URP
        rend.material.SetTextureOffset("_BaseMap", new Vector2(offsetX, offsetY));
    }
}
