using UnityEngine;

public class SistemaArma : MonoBehaviour
{
    Vector2 mousePosi;
    Vector2 dirArma;

    float angle;

    [SerializeField] SpriteRenderer srGun;
    [SerializeField] float tempoEntreTiros = 0.2f;
    bool podeAtirar = true;

    [SerializeField] Transform pontoDeFogo;
    [SerializeField] GameObject tiro;

    void Update()
    {
        // Converte posição do mouse para o mundo 2D
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosi = new Vector2(mouseWorld.x, mouseWorld.y);
    }

    void FixedUpdate()
    {
        // Direção da arma até o mouse
        dirArma = mousePosi - new Vector2(transform.position.x, transform.position.y);

        // Ângulo de rotação
        angle = Mathf.Atan2(dirArma.y, dirArma.x) * Mathf.Rad2Deg - 90f;

        // Aplica rotação
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
