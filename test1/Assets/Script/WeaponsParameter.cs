using UnityEngine;

enum WeaponType
{
    empty = 0,
    Primary = 1,
    Sidearm = 2
}

public class WeaponsParameter : MonoBehaviour
{
    [SerializeField] WeaponType _weapon;
    [SerializeField] bool _isFire;
    float _nowtime;
    int _perMinute;
    float _perSecond;

    void Start()
    {
        _weapon = 0;
        _perMinute = 600;
        _isFire = false;
    }

    void FixedUpdate()
    {
        if (_nowtime < 1)
        {
            _nowtime += Time.deltaTime;
            _isFire = false;
        }
        else
        {
            _nowtime = 1;
            _isFire = true;
        }
    }
}
