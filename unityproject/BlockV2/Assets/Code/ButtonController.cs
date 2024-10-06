using UnityEngine;
using Es.InkPainter.Sample;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    MousePainter mousePainter;
    BlockController blockController;
    [SerializeField] GameObject blockOutline;
    [SerializeField] GameObject outlineSelector;
    [SerializeField] GameObject makeButtonToggle;
    [SerializeField] GameObject paintButtonToggle;
    [SerializeField] GameObject clearButtonToggle;
    [SerializeField] GameObject shareBlock;
    [SerializeField] GameObject mainButtonGroup;
    [SerializeField] GameObject popup1;
    [SerializeField] GameObject popup2;


    private RaycastHit raycastHit;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mousePainter = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<MousePainter>();
        blockController = GameObject.FindGameObjectWithTag("blockController").GetComponent<BlockController>();

        mousePainter.enabled = false;
        blockController.enabled = false;
        blockOutline.SetActive(false);
        outlineSelector.SetActive(true);
        shareBlock.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (!Physics.Raycast(ray, out raycastHit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log ("this should deselect buttons");
                outlineSelector.SetActive(true);
                makeButtonToggle.GetComponent<Button>().onClick.Invoke();
                paintButtonToggle.GetComponent<Button>().onClick.Invoke();
                clearButtonToggle.GetComponent<Button>().onClick.Invoke(); 

                shareBlock.SetActive(false);
                mainButtonGroup.SetActive(true);
                popup1.SetActive(false);
                popup2.SetActive(false);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)){
            popup2.SetActive(true);
        }
    }

    public void OnMakeOrClear()
    {
        blockOutline.SetActive(true);
        blockController.enabled = true;
        outlineSelector.GetComponent<OutlineSelection>().enabled = false;
    }

    public void OffMakeOrClear()
    {
        blockController.enabled = false;
        blockOutline.SetActive(false);
        outlineSelector.GetComponent<OutlineSelection>().enabled = true;
    }

    public void OnPaint() 
    {
        outlineSelector.GetComponent<OutlineSelection>().enabled = false;
        mousePainter.enabled = true;
    }

    public void OffPaint() 
    {
        mousePainter.enabled = false;
        outlineSelector.GetComponent<OutlineSelection>().enabled = true;
    }
}
