using UnityEngine;
using Es.InkPainter.Sample;

public class ButtonController : MonoBehaviour
{
    MousePainter mousePainter;
    BlockController blockController;
    [SerializeField] GameObject blockOutline;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mousePainter = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MousePainter>();
        blockController = GameObject.FindGameObjectWithTag("blockController").GetComponent<BlockController>();

        mousePainter.enabled = false;
        blockController.enabled = false;
        blockOutline.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnMakeOrClear()
    {
        blockOutline.SetActive(true);
        blockController.enabled = true;
    }

    public void OffMakeOrClear()
    {
        blockController.enabled = false;
        blockOutline.SetActive(false);
    }

    public void OnPaint() 
    {
        mousePainter.enabled = true;
    }

    public void OffPaint() 
    {
        mousePainter.enabled = false;
    }
}
