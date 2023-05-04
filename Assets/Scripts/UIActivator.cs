using UnityEngine;

public class UIActivator : MonoBehaviour
{
    
    string url;
    private Color basicColor = Color.green;
    private Color hoverColor = Color.red;
    private Renderer renderer;
    

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material.color = basicColor;
    }

    public GameObject[] uiPanels;

    private void OnMouseDown()
    {
        // Disable the first panel and enable the second panel when the second cube is clicked
        if (gameObject.name == "Cube1")
        {
            uiPanels[0].SetActive(true);
            uiPanels[1].SetActive(false);
            uiPanels[2].SetActive(false);
            uiPanels[3].SetActive(false);
        }
        if (gameObject.name == "Cube2")
        {
            uiPanels[0].SetActive(false);
            uiPanels[1].SetActive(true);
            uiPanels[2].SetActive(false);
            uiPanels[3].SetActive(false);
        }
        if (gameObject.name == "Cube3")
        {
            uiPanels[0].SetActive(false);
            uiPanels[1].SetActive(false);
            uiPanels[2].SetActive(true);
            uiPanels[3].SetActive(false);
        }
        if (gameObject.name == "Cube4")
        {
            uiPanels[0].SetActive(false);
            uiPanels[1].SetActive(false);
            uiPanels[2].SetActive(false);
            uiPanels[3].SetActive(true);
        }
    }


    void OnMouseEnter()
    {
        renderer.material.color = hoverColor;
       
    }

    void OnMouseExit()
    {
        renderer.material.color = basicColor;
       
    }

    public void OpenUrl(string url)
    {
        Application.OpenURL(url);
    } 
}
