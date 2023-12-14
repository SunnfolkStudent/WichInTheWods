using UnityEngine;

public class SwitchPage : MonoBehaviour
{
    private bool _hasHapend;
    private GameObject _gameObject;
    
    private Input_Controler _input;
   
    public GameObject[] background;
    public int index;

    void Start()
    {
        index = 0;
        _input = GetComponent<Input_Controler>();
    }
        

    void Update()
    {
        if(index >= Player.indexCount)
            index = Player.indexCount; 

        if(index < 0)
            index = 0 ;
        


        if(index == 0)
        {
            background[0].gameObject.SetActive(true);
        }

        if (!_hasHapend)
        {
            _hasHapend = true;
            switch (_input.moveDirection.x)
            {
                case > 0:
                    Next();
                    break;
                case < 0: 
                    Previous(); 
                    break;
            }
        }
        else if (_input.moveDirection.x == 0)
        {
            _hasHapend = false;
        }
        
    }

    private void Next()
    {
        index += 1;
    
        foreach (var t in background)
        {
            t.gameObject.SetActive(false);
            background[index].gameObject.SetActive(true);
        }
    }

    private void Previous()
    {
        index -= 1;
    
        for(int i = 0 ; i < background.Length; i++)
        {
            background[i].gameObject.SetActive(false);
            background[index].gameObject.SetActive(true);
        }
        
    }

    
}
