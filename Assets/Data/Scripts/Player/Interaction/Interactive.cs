using UnityEditor.SearchService;
using UnityEngine;

public class Interactive : MonoBehaviour
{
    public enum InteractiveType { _PICKABLE, _INTERACT_ONCE, _INTERACT_MULTI, _INDIRECT, _PANELINTERACTION };

    [SerializeField] private GameObject         DEACTIVATE, ACTIVATE;
    [SerializeField] internal int                levelChosen;
    [SerializeField] private bool               _isActive;
    [SerializeField] private InteractiveType    _type;
    [SerializeField] private Sprite             _icon;
    [SerializeField] private string             _requirementText;
    [SerializeField] private Interactive[]      _requirements;
    [SerializeField] private Interactive[]      _activationChain;
    [SerializeField] private string[]           _interactionTexts;
    [SerializeField] private Interactive[]      _interactionChain;

    [Range(10,30)][SerializeField] private float radius = 20f;
    [SerializeField] private bool _canShowGizmo         = true;
    [SerializeField] private LayerMask AILayer; 
    private bool _canSearch;
    private bool _isGemClean;


    private GameHandler                         Handler; 

    


    private Animator    _animator;
    private int         _curInteractionTextId;

    void Start()
    {
        _animator               = GetComponent<Animator>();
        _curInteractionTextId   = 0;

        Handler                 =  FindObjectOfType<GameHandler>(); 

    }
    private void Update()
    {
        //if (_canSearch) { GetAI(); }
        
    }

    public bool IsActive()
    {
        return _isActive;
    }

    public InteractiveType GetInteractiveType()
    {
        return _type;
    }

    public Sprite GetIcon()
    {
        return _icon;
    }

    public string GetRequirementText()
    {
        return _requirementText;
    }

    public string GetCurrentInteractionText()
    {
        return _interactionTexts[_curInteractionTextId];
    }

    public Interactive[] GetRequirements()
    {
        return _requirements;
    }

    private void Activate()
    {
        _isActive = true;

        if (_animator != null)
            _animator.SetTrigger("Activate");
    }

    private void GetAI()
    {
        // Check if the player is within the warning radius (Target layer optional)
        Collider[] aiHits = Physics.OverlapSphere(transform.position, radius, AILayer);
    
        if (aiHits.Length <= 0)
        {

            print("interaction works");
            ActivateFunctions();

        }
    }

    public void Interact()
    {
        if (_isActive)
        {
            if (_animator != null)
                _animator.SetTrigger("Interact");

            if (_type == InteractiveType._PICKABLE)
            {
                GetComponent<Collider>().enabled = false;
                gameObject.SetActive(false); // 

            }
            else if (_type == InteractiveType._INTERACT_ONCE)
                GetComponent<Collider>().enabled = false;
            else if (_type == InteractiveType._INTERACT_MULTI)
                _curInteractionTextId = (_curInteractionTextId + 1) % _interactionTexts.Length;

            else if(_type == InteractiveType._PANELINTERACTION)
            {
                _curInteractionTextId = (_curInteractionTextId + 1) % _interactionTexts.Length;
                //_curInteractionTextId = (_curInteractionTextId + 1) % _interactionTexts.Length;

                //ActivateDoorFunctions(); 

            }
            ProcessActivationChain();
            ProcessInteractionChain();
        }
    }

    private void ProcessActivationChain()
    {
        if (_activationChain != null)
        {
            for (int i = 0; i < _activationChain.Length; ++i)
                _activationChain[i].Activate();
        }
    }

    private void ProcessInteractionChain()
    {
        if (_interactionChain != null)
        {
            for (int i = 0; i < _interactionChain.Length; ++i)
                _interactionChain[i].Interact();
        }
    }

    private void ActivateFunctions()
    {
        // game object deactivate
        DEACTIVATE.SetActive(false);

        // game object activate
        ACTIVATE.SetActive(true);

        Destroy(this.gameObject); 


    }

    private void OnDrawGizmos()
    {
        if(_canShowGizmo)
        {
            Gizmos.color = Color.white;
            Gizmos.DrawWireSphere(transform.position,
            radius);
        }
      
    }
    
}
