using UnityEngine;
using System.Collections;

public class BackgroudScroller : MonoBehaviour {

    public float speed;
    public static BackgroudScroller current;

    private Renderer Ren;

    Vector2 pos = new Vector2(1.0f,1.0f);
	// Use this for initialization
	void Start () {
        current = this;
        Ren = GetComponent<Renderer>();
        int x = 10;
	}

    //Movimenta o background em relação ao jogador
    public void Go(Vector2 pSpeed) {
        pos.x += pSpeed.x*speed;
        pos.y += -pSpeed.y * speed;
        if (pos.magnitude > 1.0f)
        {
            pos -= new Vector2(1.0f, 1.0f);
        }

        Ren.material.mainTextureOffset = pos;
	}
}
