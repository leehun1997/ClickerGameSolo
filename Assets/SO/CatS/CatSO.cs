using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName ="CatSO",menuName ="ScriptableObject/Cat")]
public class CatSO : ScriptableObject
{
    //[SerializeField]
    public string CatName;
    public Sprite CatImage;
    public int level;
    public int Duration;
    public float CatClickPoint;
    public float CatPassivePoint;
    public float CatReturnTime;
    public ItemSO PreferItem;
}
