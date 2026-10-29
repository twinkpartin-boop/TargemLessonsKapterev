using UnityEngine;

public class PlayerSurvival : Entity
{
    
    [SerializeField] private float hunger; 

    private static PlayerSurvival instance;

    public static PlayerSurvival Instance {  get { return instance; } }
    protected override void Awake()
    {
        base.Awake();
        instance = this;
    }

    // Update is called once per frame

}
